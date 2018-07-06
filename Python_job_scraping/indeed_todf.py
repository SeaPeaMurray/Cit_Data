# import pandas as pd
from bs4 import BeautifulSoup

def doconvert(result):
	# indeed_dict = {}
	
	# Title
	title_tag = result.h2.a.get('title')

	# Company
	# comp_tag = result.span.a.contents

	# Location
	loc_tag = result.find(class_ = 'location').contents[0]

	# Summary
	# sum_tag = result.tr.td.div.find(class_ = 'summary').contents

	# Experiencelist
	# exp_tag = result.tr.td.div.find(class_ = 'experienceList').contents

	# Listing age
	# age_tag = result.tr.td.find(class_ = 'date').contents

	# job link
	# link_tag = 'www.indeed.com' + result.h2.a.get('href')

	# Populate dictionary
	# indeed_dict[title_tag] = [comp_tag, loc_tag, sum_tag, exp_tag, age_tag, link_tag]

	return title_tag, loc_tag
	# return indeed_dict