## Candidate Brief 

You are a developer for a company that sells movie DVDs.
The company website uses a third party datasource to manage its movies. The third party datasource is provided in MoviesLibrary.dll.

The following methods are provided in the third party datasource "MovieDataSource"

* GetAllData
* GetDataById
* Create
* Update

You will need to write a web based service (using C#.Net) which will be used by the company website to consume the third party datasource. This should be production ready code that can be supported.

This should be production ready code that can be supported.

This service should be able to perform the following:

1. Return movies in a sorted order by any of the movie attributes. (Except for the field "Cast")
2. Search across all fields within the movie.
3. Insert new movie
4. Update existing movie.

Note:  Calling the third party data source is costly and data only gets updated every 24 hours! Should you decide to use caching please dont use output caching.

#### NOTES

Please send completed response back as a 7z file which is under 5MB (dont need to include .net dependencies) (http://sourceforge.net/projects/sevenzip/files/7-Zip/9.20/7z920.msi/download?use_mirror=aarnet).

We can't provide any more information, so please make assumptions if you have any questions. 
If you like, you can include documentation/readme on these assumptions, please include in the 7z file.


#### HINTS

1. follow the brief!

2. You should use this opportunity to demonstrate that you have the technical knowledge to be successful in a senior developer .NET backend position.
Remember that a senior developer will be a person who is not just an "order taker" that does the work, but is someone who can provide input to design decisions, follow best practices, perform peer reviews, and mentoring other developers.