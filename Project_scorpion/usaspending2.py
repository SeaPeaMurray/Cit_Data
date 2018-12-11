import requests

params = {"detail": 
			{"country": "deu"}
		}

params2 = {
    "time_period": [
        {
            "start_date": "2001-01-01",
            "end_date": "2001-01-31"
        }
    ]
}

r = requests.post('https://api.usaspending.gov/api/v2/federal_accounts/', data=params)

print(r.content)