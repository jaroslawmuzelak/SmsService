# SmsService

Configuration with Docker for Windows:

1. Creade folder named DockerShared on C partition.
2. Go to Docker for Windows settings -> Resources -> File sharing and add C: and C:/DockerShared. Restart Docker for Windows
3. Navigate to project folder using PowerShell and type 'docker-compose up -d'. Containsers should start.
4. Open SmsService solution, go to SmsService.API project and open Startup.cs 
	a) Comment 48 line (options.UseMySql(Configuration["ConnectionString"]);)
	b) Uncomment 49 line (options.UseMySql("Server=host.docker.internal;Database=sms_service;Uid=root;Pwd=root;");)
5. Open Package Manager Console in visual studio and type Update-Database. Database should have been updated with initial data.
6. To check logs for sent SMSes in PowerShell:
	a) type 'docker ps' and copy SmsService container ID
	b) type 'docker exec -it [ID] bash'
	c) navigate to /var/log/smsservice. Logs are in smsservice.log file
	d) to exit docker container and return to PowerShell press CTRL+D
	
7. To kill all containers type 'docker kill $(docker ps -a -q)' or kill one by one using 'docker kill [ID]' command


If you want using API in debug mode (in Visual Studio), follow 1-5 steps, but in 3 step type 'docker-compose up'. After 5 step, press CTRL+C in PowerShell and reverse step 4 (uncomment 48 line and comment 49 line). Now simply start project in visual studio.
