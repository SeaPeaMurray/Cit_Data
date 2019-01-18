import class_script
import time

print("Project Scorpion basic tool.\n\nThis program takes a USASPending .csv file and cleans + joins work and contract vehicle information for the user.")
print("\nEnter the file name with the location relative to the Python script's location.\nAn example of the file location would look like so:\n\n_Data/TREAS/api_bulk_listmonthlyfiles/2015_020_Contracts_Full_20181212_1.csv\n")

contract_file = input("Entire file location: ")

# Merely for testing purposes
contract_file_ = '_Data/TREAS/api_bulk_listmonthlyfiles/2015_020_Contracts_Full_20181212_1.csv'

spend_obj = class_script.usaspendingobj()

spend_obj.read(contract_file_)

joined_obj = spend_obj.join_vehicle_work('_Data/TREAS/ContractVehicles.csv', '_Data/TREAS/Work.csv')

final = joined_obj.modify_bool()
print('\nThis is a preview of the spreadsheet:\n\n', final.joined_fiscal_bool.head(), '\n')

# Test the columns that have failed converting 'False'
# print(final.joined_fiscal_bool['township_local_government'][:10])

to_excel = input('Would you like the file converted to an Excel spreadsheet? ')
if str(to_excel).lower() == 'yes' or str(to_excel).lower() == 'y':
	print('\nThis process can take a few minutes depending on the machine.\n')
	final.joined_fiscal_bool.to_excel('output.xlsx', index=False)
	print('Excel file generated.')
if str(to_excel).lower() != 'yes' and str(to_excel).lower() != 'y':
	print('\nScript completed without Excel file.')