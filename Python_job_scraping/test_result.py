from bs4 import BeautifulSoup
import indeed_todf as todf

with open('scrape_output.txt') as file:
	soup = BeautifulSoup(file, 'html.parser')


no_ad_list = [div for div in soup.find_all('div') if div.get('data-tn-component') == 'organicJob']

# print(no_ad_list)
# print(len(no_ad_list))

def exc(result):
# 	return result.h2.a.get('title')
	return result.span.a
	# return type(result)

# print(list(map(exc, no_ad_list)))
# print(list(map(todf.doconvert, no_ad_list)))

print(list(map(exc, no_ad_list)))