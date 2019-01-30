##############################################



##############################################

Project Scorpion Alpha - stand alone version instructions

Designed by Clayton Murray, Jon Rock, and Matt Fioretti

Requirements: Python3, and libraries: pandas, numpy, re, requests, zipfile. Installing the Anaconda package will provide all necessary libraries. See https://www.anaconda.com/distribution/ for version and download.

The program hits the usaspending.gov API, pulls a zip file with the necessary restrictions, compiles data into a dataframe, and then converts the cleaned and joined information into an Excel file. The process can take up to five minutes on slower machines, but it is automated.

