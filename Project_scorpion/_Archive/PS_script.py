import numpy as np
import pandas as pd

class USASpending:
	def __init__(self, name):
		self.file = pd.read_csv(name)

USASpending('_Data/TREAS/api_bulk_listmonthlyfiles/2015_020_Contracts_Full_20181212_1.csv')