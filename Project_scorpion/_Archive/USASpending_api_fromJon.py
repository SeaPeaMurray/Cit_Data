# "https://api.usaspending.gov/api/v2/spending/" 
params =  {"agency": 22, "fiscal_year": 2016, "type": "contracts"}

import requests

r = requests.post("https://api.usaspending.gov/api/v2/bulk_download/list_monthly_files//", data=params)

print(r.json()['monthly_files'][0]['url'])