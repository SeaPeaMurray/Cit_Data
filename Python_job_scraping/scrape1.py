import requests
from bs4 import BeautifulSoup

position = 'python'
location = 'chantilly%2c+va'
indeed_url = 'https://indeed.com/jobs?'
myurl = indeed_url + 'q=' + position + '&l=' +  location
page_r = requests.get(myurl)
page_soup = BeautifulSoup(page_r.text, 'html.parser')
print(page_soup.prettify())
print(page_soup.find_all())