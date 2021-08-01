For the questions please check Questions.PNG file

Steps to run : 

1-In package manager console add the connection string to the environment vars
	-$env:VouchersConnectionString = "{your connection string}"

2-Set Vouchers.Dal project to be the startup

3-In package manager console run update-database command

4-Update the connection string in app.settings for the web application and VouchersMigrationClient

5- Set VouchersMigrationClient to be the startup project 

6-Run the project 

7- Set the web application as the startup

8-Run