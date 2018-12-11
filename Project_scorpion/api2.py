import requests

new_dict = {
			"managing_agency": "Department of Treasury",
			"keywords": "citizant",
			"place_of_performance_scope": "domestic"
			}

r = requests.post('https://api.usaspending.gov/api/v2/federal_accounts/', data=new_dict)

print(r.content)

# import json
# with open('data.json', 'w') as outfile:
#     json.dump(r, outfile)

# Check out postman API tool