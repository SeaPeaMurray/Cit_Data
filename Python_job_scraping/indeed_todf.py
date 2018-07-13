# import pandas as pd
from bs4 import BeautifulSoup

def doconvert(result):
	indeed_dict = {}
	
	# Title
	indeed_dict[title] = result.h2.a.get('title')

	# Location
	indeed_dict[loc] = result.find(class_ = 'location').contents[0]

	# Summary
	indeed_dict[summ] = result.tr.td.div.find(class_ = 'summary').contents

	# Experiencelist
	indeed_dict[exp] = result.tr.td.div.find(class_ = 'experienceList').contents

	# Listing age
	indeed_dict[age] = result.tr.td.find(class_ = 'date').contents

	# job link
	indeed_dict[link] = 'www.indeed.com' + result.h2.a.get('href')

	# Company
	try:
		indeed_dict[comp] = result.span.a.contents
	except:
		pass

	# Populate dictionary
	# indeed_dict[title_tag] = [comp_tag, loc_tag, sum_tag, exp_tag, age_tag, link_tag]

	# return comp_tag
	return indeed_dict