import requests
import json

r = requests.post('https://api.usaspending.gov/api/v2/bulk_download/list_agencies/')

f = r.text

# print(f['results'])
# with open('first_api.txt', 'wb') as file:
#  	file.write(f)
# dict(f)
print(json.dumps(f, sort_keys=True, indent=4))