Flex Trainer Application

The Flex Trainer Application is a comprehensive gym management system built using Windows Forms
for the frontend and Microsoft SQL Server for the backend. 

It provides interfaces tailored for various user roles including Admins, Members, Trainers, and Gym Owners.

You will need to install:
	- Microsoft SQL Server and Sequel Server Management Studio
	- Visual Studio 2019 or later

Create a Visual Studio Project and add the repository files into the folder.

Open SQL Server Management Studio and connect to the local server, open the
Database_Creation.sql and run the commands to create the database.

For data entry, based off of personal preference, either use the manual import file or the
csv import file to import data into the database.

For the CSV Import, you will need to change the file paths within the code to the paths where
you have stored the files.

Then, connect the Database to your Visual Studio Project, and run the project by ensuring that the 
entrypoint is Validation in Program.cs.

For the application to communicate with the database, change the connection string in apps.config to whatever
connection string your connection has, this is shown whenever you connect a database to your project.

This was a work in progress and was made for a university project, so it lacks in aesthetics and there are a
lot of bugs to be resolved, but I feel this is a good skeleton if one decides to work with this for 
learning.