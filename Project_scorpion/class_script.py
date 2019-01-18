import numpy as np
import pandas as pd
import re

class usaspendingobj:

	def __init__(self, csv):
		cols = list(pd.read_csv(csv).columns)
		dates = [col for col in cols if re.search(r'date/b', col) is not None]
		df = pd.read_csv(csv, parse_dates=dates, infer_datetime_format=True)
		df.loc[:, 'period_of_performance_start_date'] = pd.to_datetime(df['period_of_performance_start_date'], errors='coerce')
		self.original = df

	def join_vehicle_work(self, vehicle, work):
		# print(self.original)
		self.vehicle = pd.read_csv(vehicle, names=['parent_award_id', 'contract_vehicle'])
		self.work = pd.read_csv(work)
		self.work.columns = ['parent_award_id', 'award_id_piid', 'work']
		self.join_vehicle = pd.merge(self.original, self.vehicle, on='parent_award_id', how='left')
		self.join_vw = pd.merge(self.join_vehicle, self.work, on=['parent_award_id', 'award_id_piid'], how='left')

	def namespace(self):
		self.test = self.original.head()

myobj = usaspendingobj('_Data/TREAS/api_bulk_listmonthlyfiles/2015_020_Contracts_Full_20181212_1.csv')


myobj.join_vehicle_work('_Data/TREAS/ContractVehicles.csv', '_Data/TREAS/Work.csv')

# print(myobj.original.head(1))
# print(joined.join_vw.head())
# print(type(joined.vehicle))
# print(dir(myobj))
print(myobj.join_vw)