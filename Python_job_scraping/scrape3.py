import requests
import pandas as pd
from time import sleep
from bs4 import BeautifulSoup
import indeed_todf

print("""This script requires the following libraries to function:\n
	requests, pandas, time, bs4.\n
	Use pip to install them if they are not installed.""")
sleep(1)

pos = input('What keyword? ')
city = input('In which city? ')
state = input('In which state?\n***Use two letter state abbreviation.*** ')
count = input('How many pages to scrape?\n***Exceeding true number of results pages will create duplicates.*** ')
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
	collection_list = []
	print('Scraping {} pages of positions matching: '.format(count) + pos + ' in: ' + city + ', '+ state + '.')
	sleep(2)

	# Crawl off of each page per int_count
	for i in range(1, int_count + 1):
		soup_list = []
		if i == 1:
			myurl = indeed_url + 'q=' + pos + '&l=' +  location
			page_r = requests.get(myurl)
			page_soup = BeautifulSoup(page_r.content, 'html.parser')
			for item in page_soup.find_all('div'):
				if item.get('data-tn-component') == 'organicJob':
					soup_list.append(item)
			collection_list += soup_list
		else:
			myurl = indeed_url + 'q=' + pos + '&l=' + location + '&start=' + str(i)
			page_r = requests.get(myurl)
			page_soup = BeautifulSoup(page_r.content, 'html.parser')
			for item in page_soup.find_all('div'):
				if item.get('data-tn-component') == 'organicJob':
					soup_list.append(item)
			collection_list += soup_list
	
	# print(len(collection_list))
	# print(collection_list[0]) # Remove these later
	return collection_list
	# print(indeed_todf.doconvert(collection_list))

if __name__ == '__main__':
	indeed()


	# with open('scrape_output.txt', 'w') as file:
	# 	for line in page_soup_entries.prettify():
	# 		file.write(line)
	# 	for line in page_soup.summaries.prettify():
	# 		file.write(line)

		# for item in page_soup.find_all('div'):
    #   		if item.get('data-tn-component') == 'organicJob':
    #   		    soup_list.append(item)


# # Company
# company_tag = item[i].span.a.contents

# # Title
# title_tag = item[i].h2.a.get('title')

# # Location
# location_tag = item[i].find(class_ = 'location').contents

# # Summary
# summary_tag = item[i].tr.td.div.find(class_ = 'summary').contents

# # Experiencelist
# item[i].tr.td.div.find(class_ = 'experienceList').contents

# # Listing age
# item[i].tr.td.find(class_ = 'date').contents

# # job link
# link = 'www.indeed.com' + item[i].h2.a.get('href')