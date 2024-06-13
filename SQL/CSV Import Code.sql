use Flex_Trainer

--IMPORTS--
BULK INSERT USERS
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\USERS.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT ADMIN1
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\ADMIN1.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT GYMOWNER
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\GYMOWNER.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT GYM
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\GYM.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT MEMBER1
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\MEMBER1.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT TRAINER
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\TRAINER.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT WORKOUTPLAN
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\WORKOUTPLAN.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT EXERCISE
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\EXERCISE.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT EXERCISEDESCRIPTION
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\EXERCISEDESCRIPTION.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT WORKOUTPLANHASEXERCISE
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\WORKOUTPLANHASEXERCISE.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT TRAINERWORKOUTPLAN
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\TRAINERWORKOUTPLAN.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT DIETPLAN
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\DIETPLAN.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT MEAL
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\MEAL.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT MEALPLAN
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\MEALPLAN.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT ALLERGENS
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\ALLERGENS.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT HAS
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\HAS.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT APPOINTMENT
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\APPOINTMENT.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT FEEDBACK
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\FEEDBACK.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT TRAINERREGISTRATIONREQUEST
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\TRAINERREGISTRATIONREQUEST.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT MEMBERREGISTRATIONREQUEST
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\MEMBERREGISTRATIONREQUEST.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

BULK INSERT GYMREGISTRATIONREQUEST
FROM 'C:\Users\zainb\Desktop\uni\Semester 4\DB Lab\Project\WindowsFormsApp1\sheets\GYMREGISTRATIONREQUEST.csv'
WITH
(
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
);

	select* from USERS
	select* from MEMBER1
	select* from ADMIN1
	select* from GYMOWNER
	select* from TRAINER
	select* from GYM
	select* from WORKOUTPLAN
	select* from EXERCISE
	select* from EXERCISEDESCRIPTION
	select* from WORKOUTPLANHASEXERCISE
	select* from TRAINERWORKOUTPLAN
	select* from MEAL
	select* from MEALPLAN
	select* from ALLERGENS
	select* from DIETPLAN
	select* from HAS
	select* from APPOINTMENT
	select* from FEEDBACK
	select* from GYMREGISTRATIONREQUEST
	select* from MEMBERREGISTRATIONREQUEST
	select* from TRAINERREGISTRATIONREQUEST
	select* from logs;