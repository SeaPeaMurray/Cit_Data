import requests
from time import sleep
from bs4 import BeautifulSoup

pos = input('What keyword? ')
city = input('In which city? ')
state = input('In which state? ***Use two letter state abbreviation.*** ')
count = input('How many pages to scrape?')
int_count = int(count)

def indeed():

	#Assert variables will execute
	errors = []
	if not type(pos) == str:
		errors.append('Position keyword must be a string.')
	if not type(city) == str:
		errors.append('City must be a string.')
	if not type(state) == str:
		errors.append('State must be a string.')
	assert not errors, 'The following errors occurred:\n {}'.format('\n'.join(errors))		
	location = city + '%2c+' + state  
	print('Scraping positions matching: ' + pos + ' in: ' + city + ', '+ state)
	sleep(3)

	# Execute requests.get and create BS4 object
	indeed_url = 'https://indeed.com/jobs?'
	myurl = indeed_url + 'q=' + pos + '&l=' +  location
	page_r = requests.get(myurl)
	page_soup = BeautifulSoup(page_r.content, 'html.parser')
	page_soup_entries = page_soup.find_all('h2', class_='jobtitle')
	page_soup_summaries = page_soup.find_all('span', class_='summary')
	print(page_soup_entries)

	for i in range(1, int_count - 1):
		if i == 1:
			myurl = indeed_url + 'q=' + pos + '&l=' +  location
		myurl = indeed_url.append('&start=' + str(i))
		page_r = requests.get(myurl)
		page_soup = BeautifulSoup(page_r.content, 'html.parser')
		page_soup_entries = page_soup.find_all('h2', class_='jobtitle')
		page_soup_summaries = page_soup.find_all('span', class_='summary')

	# page_r = requests.get(myurl)
	# 	indeed_url2 = indeed_url.append('&start=' + str(i))
	# for item in ps_entries:
	# 	print(item)
	# with open('scrape_output.txt', 'w') as file:
	# 	for line in page_soup.prettify():
	# 		file.write(line)


if __name__ == '__main__':
	indeed()