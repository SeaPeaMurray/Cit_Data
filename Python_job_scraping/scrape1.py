import requests
from bs4 import BeautifulSoup

position = 'python'
location = 'chantilly%2c+va'
indeed_url = 'https://indeed.com/jobs?'
myurl = indeed_url + 'q=' + position + '&l=' +  location
page_r = requests.get(myurl)
page_soup = BeautifulSoup(page_r.content, 'html.parser')
with open('scrape_output.txt', 'w') as file:
	for line in page_soup.prettify():
		file.write(line)
# print(page_soup.find_all())
# with open()