import requests

# r = requests.post('https://api.usaspending.gov/api/v2/financial_balances/agencies?funding_agency=775&fiscal_year=2017', data=api_req)
r = requests.get('https://api.usaspending.gov/api/v2/references/agency/456/')
print(r.text)


