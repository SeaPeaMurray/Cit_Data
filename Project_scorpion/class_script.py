import numpy as np
import pandas as pd
import re
import requests

class usaspendingobj:

	def __init__(self):
		print("Project Scorpion Alpha instance created.\n")

	def api_req(self):
		
		params =  {"agency": 22, "fiscal_year": 2016, "type": "contracts"}
		r = requests.post("https://api.usaspending.gov/api/v2/bulk_download/list_monthly_files//", data=params)
		self.api_link = r.json()['monthly_files'][0]['url']

	# def unzip(self):

	def read(self, csv):
		cols = list(pd.read_csv(csv, low_memory=False).columns)
		dates = [col for col in cols if re.search(r'date/b', col) is not None]
		df = pd.read_csv(csv, parse_dates=dates, infer_datetime_format=True, low_memory=False)
		df.loc[:, 'period_of_performance_start_date'] = pd.to_datetime(df['period_of_performance_start_date'], errors='coerce')
		self.original = df
		print("CSV file:\n {} loaded into memory.\n".format(csv))

	def join_vehicle_work(self, vehicle, work):
		self.vehicle = pd.read_csv(vehicle, names=['parent_award_id', 'contract_vehicle'])
		self.work = pd.read_csv(work)
		self.work.columns = ['parent_award_id', 'award_id_piid', 'work']
		join_vehicle = pd.merge(self.original, self.vehicle, on='parent_award_id', how='left')
		self.joined = pd.merge(join_vehicle, self.work, on=['parent_award_id', 'award_id_piid'], how='left')
		self.joined_fiscal = self.joined
		self.joined_fiscal['fiscal_year'] = pd.to_datetime(self.joined['action_date'])
		fiscal_year = []
		for date in self.joined_fiscal['fiscal_year']:
			if date.month > 9:
				fiscal_year.append(date.year + 1)
			else:
				fiscal_year.append(date.year)
		self.joined_fiscal['fiscal_year'] = pd.Series(fiscal_year, index=self.joined.index)
		return self
		
	def modify_bool(self):
		bool_list = []
		for col in self.joined_fiscal:
			if col != 'fiscal_year':
				if len(self.joined_fiscal[col].unique()) == 2 and self.joined_fiscal[col].dtype != '<M8[ns]':
					if 't' and 'f' in self.joined_fiscal[col].unique():
						bool_list.append(str(col))
					if len(self.joined_fiscal[col].unique()) < 2 and self.joined_fiscal[col].dtype != '<M8[ns]':
						for val in ['t', 'true', 'T', 'True']:
							if val in self.joined_fiscal[col].unique():
								self.joined_fiscal.loc[:, col] = True
						for val in ['f', 'false', 'F', 'False']:
							if 'f' in self.joined_fiscal[col].unique():
								self.joined.fiscal.loc[:, col] = False
						
		for name in bool_list:
			self.joined_fiscal_bool = self.joined_fiscal
			self.joined_fiscal_bool.loc[:, name] = pd.get_dummies(self.joined_fiscal[name]).astype('bool')['t']

		return self