import requests
import pandas as pd
from time import sleep
from bs4 import BeautifulSoup

pos = input('What keyword? ')
city = input('In which city? ')
state = input('In which state? ***Use two letter state abbreviation.*** ')
count = input('How many pages to scrape? ***Exceeding true number of results pages will create duplicates.***')
int_count = int(count)

def indeed():

	#Assert variables will execute without errors
	errors = []
	if not type(pos) == str:
		errors.append('Position keyword must be a string.')
	if not type(city) == str:
		errors.append('City must be a string.')
	if not type(state) == str:
		errors.append('State must be a string.')
	if not type(int_count) == int:
		errors.append('Use an integer to select number of pages.')
	assert not errors, 'The following errors occurred:\n {}'.format('\n'.join(errors))		
	
	# User feedback + execute requests.get and create BS4 object on proper link
	location = city + '%2c+' + state  
	indeed_url = 'https://indeed.com/jobs?'
	print('Scraping {} positions matching: '.format(count) + pos + ' in: ' + city + ', '+ state)
	sleep(2)

	for i in range(1, int_count):
		soup_list = []
		if i == 1:
			myurl = indeed_url + 'q=' + pos + '&l=' +  location
			page_r = requests.get(myurl)
			page_soup = BeautifulSoup(page_r.content, 'html.parser')
			for item in page_soup.find_all('div'):
				if item.get('data-tn-component') == 'organicJob':
					soup_list.append(item)

			# page_soup_entries = page_soup.find_all('h2', class_='jobtitle')
			# page_soup_summaries = page_soup.find_all('span', class_='summary')
			# indeed_dict[page_soup_entries] = page_soup_summaries
			# print(type(page_soup_entries), type(page_soup_summaries))
		else:
			myurl = indeed_url + 'q=' + pos + '&l=' + location + '&start=' + str(i)
			page_r = requests.get(myurl)
			page_soup = BeautifulSoup(page_r.content, 'html.parser')
			for item in page_soup.find_all('div'):
				if item.get('data-tn-component') == 'organicJob':
					soup_list.append(item)

			# page_soup_entries = page_soup.find_all('h2', class_='jobtitle')
			# page_soup_summaries = page_soup.find_all('span', class_='summary')
			# indeed_dict[page_soup_entries] = page_soup_summaries
	print(len(soup_list))
	# with open('scrape_output.txt', 'w') as file:
	# 	for line in page_soup_entries.prettify():
	# 		file.write(line)
	# 	for line in page_soup.summaries.prettify():
	# 		file.write(line)

		# for item in page_soup.find_all('div'):
    #   		if item.get('data-tn-component') == 'organicJob':
    #   		    soup_list.append(item)
    		    

# # Company
# item[i].span.a.contents

# # Title
# item[i].h2.a.get('title')

# # Location
# item[i].find(class_ = 'location').contents

# # Summary
# item[i].tr.td.div.find(class_ = 'summary').contents

# # Experiencelist
# item[i].tr.td.div.find(class_ = 'experienceList').contents

# # Listing age
# item[i].tr.td.find(class_ = 'date').contents

# # job link
# link = 'www.indeed.com' + item[i].h2.a.get('href')

if __name__ == '__main__':
	indeed()