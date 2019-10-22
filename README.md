# JobService



## :page_with_curl: Description
This project contains a job sheduling and performing service which handles REST jobs and Stored Procedure jobs. It is set up to easly add new kind of jobs. Hangfire uses its own dashboard. But in this project I created a custom dashboard to schedule and fire the custom jobs (REST and SP jobs). Logging goes thru GELF -> Graylog and can be dockerized whith Docker, docker-compose or Jenkins.

## :warning: JobService.Dashboard requires the Razor Generator extension
This extension will update the HTML, CSS and JS files to a DLL which will be used by Hangfire to include inside its dashboard. 

## :hammer_and_wrench: Tools used
* Hangfire
* Swashbuckle
* GELF
* Docker (compose)
* Jenkins
* Entity Framework
* Shuttle Specification
* Cronos
* Razor Generator

## Licence
My code is open source and free to use without any contact. Feel free to copy & pasta :plate_with_cutlery: