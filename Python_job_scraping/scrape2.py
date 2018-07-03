import requests
from time import sleep
from bs4 import BeautifulSoup

def indeed():

	#Create variables from input
	pos = input('What keyword?')
	city = input('Which city?')
	state = input('Which state? Use two letter abbreviation.')

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
	if True:
		print(page_soup.head)
	return page_soup


# if __name__ == '__main__':

indeed()