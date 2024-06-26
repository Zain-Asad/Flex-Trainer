create database Flex_Trainer
use Flex_Trainer

CREATE TABLE USERS (
    USERID INT PRIMARY KEY IDENTITY(1,1),
    USERNAME VARCHAR(50) UNIQUE,
    PASSWORD1 VARCHAR(100),
    EMAIL VARCHAR(100),
    PHONENO VARCHAR(50)
);

CREATE TABLE ADMIN1 (
    ADMINID INT PRIMARY KEY IDENTITY(1,1),
    USERID INT UNIQUE,
    FOREIGN KEY (USERID) REFERENCES USERS(USERID)
);

CREATE TABLE GYMOWNER (
    OWNERID INT PRIMARY KEY IDENTITY(1,1),
    USERID INT UNIQUE,
    FOREIGN KEY (USERID) REFERENCES USERS(USERID)
);

CREATE TABLE GYM (
    GYMID INT PRIMARY KEY IDENTITY(1,1),
    GYMNAME VARCHAR(100),
    LOCATION1 VARCHAR(100),
    CONTACTNUMBER VARCHAR(20),
    EMAIL VARCHAR(100),
    OWNERID INT,
    FOREIGN KEY (OWNERID) REFERENCES GYMOWNER(OWNERID)
);

CREATE TABLE MEMBER1 (
    GYMID INT,
    FOREIGN KEY (GYMID) REFERENCES GYM(GYMID),
    MEMBERID INT PRIMARY KEY IDENTITY(1,1),
    USERID INT UNIQUE,
    FOREIGN KEY (USERID) REFERENCES USERS(USERID)
);

CREATE TABLE TRAINER (
    TRAINERID INT PRIMARY KEY IDENTITY(1,1),
    USERID INT UNIQUE,
    SPECIALIZATION VARCHAR(100),
    EXPERIENCE INT,
    GYMID INT,
    FOREIGN KEY (USERID) REFERENCES USERS(USERID),
    FOREIGN KEY (GYMID) REFERENCES GYM(GYMID)
);

CREATE TABLE WORKOUTPLAN (
    PLANID INT PRIMARY KEY IDENTITY(1,1),
    TRAINERID INT,
    PLANNAME VARCHAR(100),
    PLANDESCRIPTION TEXT,
    CREATIONDATE DATE,
   FOREIGN KEY (TRAINERID) REFERENCES USERS(UserID)
);

CREATE TABLE EXERCISE (
    EXERCISE_ID INT PRIMARY KEY IDENTITY(1,1),
    EXERCISENAME VARCHAR(100),
    MUSCLEGROUP VARCHAR(50)
);

CREATE TABLE EXERCISEDESCRIPTION (
    EXDESCRIPTIONID INT PRIMARY KEY IDENTITY(1,1),
    PLANID INT,
    EXERCISEID INT,
    SETS1 INT,
    REPS INT,
    RESTINTERVAL INT,
    FOREIGN KEY (EXERCISEID) REFERENCES EXERCISE(EXERCISE_ID),
    FOREIGN KEY (PLANID) REFERENCES WORKOUTPLAN(PLANID)
);

CREATE TABLE WORKOUTPLANHASEXERCISE (
    PLANID INT,
    EXERCISEID INT,
    PRIMARY KEY (PLANID, EXERCISEID),
    FOREIGN KEY (PLANID) REFERENCES WORKOUTPLAN(PLANID),
    FOREIGN KEY (EXERCISEID) REFERENCES EXERCISE(EXERCISE_ID)
);


CREATE TABLE TRAINERWORKOUTPLAN (
    TRAINERID INT,
    PLANID INT,
    GENERATEDDATE DATE,
    PRIMARY KEY (TRAINERID, PLANID),
    FOREIGN KEY (TRAINERID) REFERENCES USERS(UserID),
    FOREIGN KEY (PLANID) REFERENCES WORKOUTPLAN(PLANID)
);


CREATE TABLE DIETPLAN (
    DIETID INT PRIMARY KEY IDENTITY(1,1),
    TRAINERID INT,
    PLANNAME VARCHAR(100),
    PLANDESCRIPTION TEXT,
    CREATIONDATE DATE,
    FOREIGN KEY (TRAINERID) REFERENCES USERS(UserID)
);

CREATE TABLE MEAL (
    MEALID INT PRIMARY KEY IDENTITY(1,1),
    MEALNAME VARCHAR(100),
    NUTRITION VARCHAR(255)
);

CREATE TABLE MEALPLAN (
    DIETID INT,
    MEALID INT,
    PRIMARY KEY (DIETID, MEALID),
    FOREIGN KEY (DIETID) REFERENCES DIETPLAN(DIETID),
    FOREIGN KEY (MEALID) REFERENCES MEAL(MEALID)
);

CREATE TABLE ALLERGENS (
    ALLERGENID INT PRIMARY KEY IDENTITY(1,1),
    ALLERGENNAME VARCHAR(100)
);

CREATE TABLE HAS (
	HASID INT PRIMARY KEY IDENTITY(1,1),
    MEALID INT,
    ALLERGENID INT,
    FOREIGN KEY (MEALID) REFERENCES MEAL(MEALID),
    FOREIGN KEY (ALLERGENID) REFERENCES ALLERGENS(ALLERGENID)
);

CREATE TABLE APPOINTMENT (
    APPOINTMENTID INT PRIMARY KEY IDENTITY(1,1),
    TRAINERID INT,
    MEMBERID INT,
    LOCATION1 VARCHAR(50),
    DURATION VARCHAR(50),
    DATE1 DATE,
    TIME1 TIME,
    STATUS1 VARCHAR(50),
    FOREIGN KEY (TRAINERID) REFERENCES TRAINER(TRAINERID),
    FOREIGN KEY (MEMBERID) REFERENCES MEMBER1(MEMBERID)
);

CREATE TABLE FEEDBACK (
    FEEDBACKID INT PRIMARY KEY IDENTITY(1,1),
    TRAINERID INT,
    MEMBERID INT,
    RATING INT,
    COMMENT TEXT,
    DATE1 DATE,
    FOREIGN KEY (TRAINERID) REFERENCES TRAINER(TRAINERID),
    FOREIGN KEY (MEMBERID) REFERENCES MEMBER1(MEMBERID)
);

CREATE TABLE GYMMEMBERSHIP (
    MEMBERSHIPID INT PRIMARY KEY IDENTITY(1,1),
    USERID INT,
    GYMID INT,
    MEMBERSHIPTYPE VARCHAR(50),
    STARTDATE DATE,
    ENDDATE DATE,
    PAYMENTSTATUS VARCHAR(50),
    FOREIGN KEY (USERID) REFERENCES USERS(USERID),
    FOREIGN KEY (GYMID) REFERENCES GYM(GYMID)
);

CREATE TABLE TRAINERREGISTRATIONREQUEST (
    REQUESTID INT PRIMARY KEY IDENTITY(1,1),
    GYMOWNERID INT,
    TRAINERID INT,
    REQUESTDATE DATE,
    APPROVALSTATUS VARCHAR(50),
    APPROVALDATE DATE,
    FOREIGN KEY (GYMOWNERID) REFERENCES GYMOWNER(OWNERID),
    FOREIGN KEY (TRAINERID) REFERENCES TRAINER(TRAINERID)
);

CREATE TABLE MEMBERREGISTRATIONREQUEST (
    REQUESTID INT PRIMARY KEY IDENTITY(1,1),
    MEMBERID INT,
    REQUESTDATE DATE,
    APPROVALSTATUS VARCHAR(50),
    APPROVALDATE DATE,
    OWNERID INT,
    FOREIGN KEY (MEMBERID) REFERENCES MEMBER1(MEMBERID),
    FOREIGN KEY (OWNERID) REFERENCES GYMOWNER(OWNERID)
);

CREATE TABLE GYMREGISTRATIONREQUEST (
    REQUESTID INT PRIMARY KEY IDENTITY(1,1),
    GYMID INT,
    REQUESTDATE DATE,
    APPROVALSTATUS VARCHAR(50),
    APPROVALDATE DATE,
    ADMINID INT,
    FOREIGN KEY (GYMID) REFERENCES GYM(GYMID),
    FOREIGN KEY (ADMINID) REFERENCES ADMIN1(ADMINID)
);

CREATE TABLE LOGS (
    LOGID INT PRIMARY KEY IDENTITY(1,1),
    TABLE_NAME VARCHAR(50),
    ACTION VARCHAR(50),
    USERID INT,
    UPDATE_DATE DATETIME
);


CREATE TRIGGER TR_USERS_LOGS
ON USERS
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'USERS';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @USERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @USERID = i.USERID
            FROM inserted i
            INNER JOIN deleted d ON i.USERID = d.USERID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @USERID = i.USERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @USERID = d.USERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, @USERID, GETDATE());
END;

CREATE TRIGGER TR_ADMIN1_LOGS
ON ADMIN1
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'ADMIN1';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @ADMINID INT = 0;
    DECLARE @USERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @ADMINID = i.ADMINID, @USERID = i.USERID
            FROM inserted i
            INNER JOIN deleted d ON i.ADMINID = d.ADMINID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @ADMINID = i.ADMINID, @USERID = i.USERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @ADMINID = d.ADMINID, @USERID = d.USERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, @USERID, GETDATE());
END;

CREATE TRIGGER TR_GYMOWNER_LOGS
ON GYMOWNER
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'GYMOWNER';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @OWNERID INT = 0;
    DECLARE @USERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @OWNERID = i.OWNERID, @USERID = i.USERID
            FROM inserted i
            INNER JOIN deleted d ON i.OWNERID = d.OWNERID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @OWNERID = i.OWNERID, @USERID = i.USERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @OWNERID = d.OWNERID, @USERID = d.USERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, @USERID, GETDATE());
END;

CREATE TRIGGER TR_GYM_LOGS
ON GYM
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'GYM';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @GYMID INT = 0;
    DECLARE @OWNERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @GYMID = i.GYMID, @OWNERID = i.OWNERID
            FROM inserted i
            INNER JOIN deleted d ON i.GYMID = d.GYMID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @GYMID = i.GYMID, @OWNERID = i.OWNERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @GYMID = d.GYMID, @OWNERID = d.OWNERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, @OWNERID, GETDATE());
END;

CREATE TRIGGER TR_MEMBER1_LOGS
ON MEMBER1
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'MEMBER1';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @MEMBERID INT = 0;
    DECLARE @USERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @MEMBERID = i.MEMBERID, @USERID = i.USERID
            FROM inserted i
            INNER JOIN deleted d ON i.MEMBERID = d.MEMBERID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @MEMBERID = i.MEMBERID, @USERID = i.USERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @MEMBERID = d.MEMBERID, @USERID = d.USERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, @USERID, GETDATE());
END;


CREATE TRIGGER TR_TRAINER_LOGS
ON TRAINER
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'TRAINER';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @TRAINERID INT = 0;
    DECLARE @USERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @TRAINERID = i.TRAINERID, @USERID = i.USERID
            FROM inserted i
            INNER JOIN deleted d ON i.TRAINERID = d.TRAINERID;
        END
		        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @TRAINERID = i.TRAINERID, @USERID = i.USERID
            FROM inserted i;
       END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @TRAINERID = d.TRAINERID, @USERID = d.USERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, @USERID, GETDATE());
END;


CREATE TRIGGER TR_WORKOUTPLAN_LOGS
ON WORKOUTPLAN
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'WORKOUTPLAN';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @PLANID INT = 0;
    DECLARE @TRAINERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @PLANID = i.PLANID, @TRAINERID = i.TRAINERID
            FROM inserted i
            INNER JOIN deleted d ON i.PLANID = d.PLANID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @PLANID = i.PLANID, @TRAINERID = i.TRAINERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @PLANID = d.PLANID, @TRAINERID = d.TRAINERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, @TRAINERID, GETDATE());
END;


CREATE TRIGGER TR_EXERCISE_LOGS
ON EXERCISE
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'EXERCISE';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @EXERCISE_ID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @EXERCISE_ID = i.EXERCISE_ID
            FROM inserted i
            INNER JOIN deleted d ON i.EXERCISE_ID = d.EXERCISE_ID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @EXERCISE_ID = i.EXERCISE_ID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @EXERCISE_ID = d.EXERCISE_ID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_EXERCISEDESCRIPTION_LOGS
ON EXERCISEDESCRIPTION
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'EXERCISEDESCRIPTION';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @EXDESCRIPTIONID INT = 0;
    DECLARE @PLANID INT = 0;
    DECLARE @EXERCISEID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @EXDESCRIPTIONID = i.EXDESCRIPTIONID, @PLANID = i.PLANID, @EXERCISEID = i.EXERCISEID
            FROM inserted i
            INNER JOIN deleted d ON i.EXDESCRIPTIONID = d.EXDESCRIPTIONID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @EXDESCRIPTIONID = i.EXDESCRIPTIONID, @PLANID = i.PLANID, @EXERCISEID = i.EXERCISEID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @EXDESCRIPTIONID = d.EXDESCRIPTIONID, @PLANID = d.PLANID, @EXERCISEID = d.EXERCISEID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_WORKOUTPLANHASEXERCISE_LOGS
ON WORKOUTPLANHASEXERCISE
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'WORKOUTPLANHASEXERCISE';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @PLANID INT = 0;
    DECLARE @EXERCISEID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @PLANID = i.PLANID, @EXERCISEID = i.EXERCISEID
            FROM inserted i
            INNER JOIN deleted d ON i.PLANID = d.PLANID AND i.EXERCISEID = d.EXERCISEID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @PLANID = i.PLANID, @EXERCISEID = i.EXERCISEID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @PLANID = d.PLANID, @EXERCISEID = d.EXERCISEID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;

CREATE TRIGGER TR_TRAINERWORKOUTPLAN_LOGS
ON TRAINERWORKOUTPLAN
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'TRAINERWORKOUTPLAN';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @TRAINERID INT = 0;
    DECLARE @PLANID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @TRAINERID = i.TRAINERID, @PLANID = i.PLANID
            FROM inserted i
            INNER JOIN deleted d ON i.TRAINERID = d.TRAINERID AND i.PLANID = d.PLANID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @TRAINERID = i.TRAINERID, @PLANID = i.PLANID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @TRAINERID = d.TRAINERID, @PLANID = d.PLANID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_DIETPLAN_LOGS
ON DIETPLAN
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'DIETPLAN';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @DIETID INT = 0;
    DECLARE @TRAINERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @DIETID = i.DIETID, @TRAINERID = i.TRAINERID
            FROM inserted i
            INNER JOIN deleted d ON i.DIETID = d.DIETID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @DIETID = i.DIETID, @TRAINERID = i.TRAINERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @DIETID = d.DIETID, @TRAINERID = d.TRAINERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_MEAL_LOGS
ON MEAL
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'MEAL';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @MEALID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @MEALID = i.MEALID
            FROM inserted i
            INNER JOIN deleted d ON i.MEALID = d.MEALID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @MEALID = i.MEALID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @MEALID = d.MEALID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_MEALPLAN_LOGS
ON MEALPLAN
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'MEALPLAN';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @DIETID INT = 0;
    DECLARE @MEALID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @DIETID = i.DIETID, @MEALID = i.MEALID
            FROM inserted i
            INNER JOIN deleted d ON i.DIETID = d.DIETID AND i.MEALID = d.MEALID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @DIETID = i.DIETID, @MEALID = i.MEALID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @DIETID = d.DIETID, @MEALID = d.MEALID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;

CREATE TRIGGER TR_ALLERGENS_LOGS
ON ALLERGENS
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'ALLERGENS';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @ALLERGENID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @ALLERGENID = i.ALLERGENID
            FROM inserted i
            INNER JOIN deleted d ON i.ALLERGENID = d.ALLERGENID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @ALLERGENID = i.ALLERGENID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @ALLERGENID = d.ALLERGENID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_HAS_LOGS
ON HAS
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'HAS';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @MEALID INT = 0;
    DECLARE @ALLERGENID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @MEALID = i.MEALID, @ALLERGENID = i.ALLERGENID
            FROM inserted i
            INNER JOIN deleted d ON i.MEALID = d.MEALID AND i.ALLERGENID = d.ALLERGENID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @MEALID = i.MEALID, @ALLERGENID = i.ALLERGENID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @MEALID = d.MEALID, @ALLERGENID = d.ALLERGENID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;



CREATE TRIGGER TR_APPOINTMENT_LOGS
ON APPOINTMENT
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'APPOINTMENT';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @APPOINTMENTID INT = 0;
    DECLARE @TRAINERID INT = 0;
    DECLARE @MEMBERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @APPOINTMENTID = i.APPOINTMENTID, @TRAINERID = i.TRAINERID, @MEMBERID = i.MEMBERID
            FROM inserted i
            INNER JOIN deleted d ON i.APPOINTMENTID = d.APPOINTMENTID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @APPOINTMENTID = i.APPOINTMENTID, @TRAINERID = i.TRAINERID, @MEMBERID = i.MEMBERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @APPOINTMENTID = d.APPOINTMENTID, @TRAINERID = d.TRAINERID, @MEMBERID = d.MEMBERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;



CREATE TRIGGER TR_FEEDBACK_LOGS
ON FEEDBACK
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'FEEDBACK';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @FEEDBACKID INT = 0;
    DECLARE @TRAINERID INT = 0;
    DECLARE @MEMBERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @FEEDBACKID = i.FEEDBACKID, @TRAINERID = i.TRAINERID, @MEMBERID = i.MEMBERID
            FROM inserted i
            INNER JOIN deleted d ON i.FEEDBACKID = d.FEEDBACKID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @FEEDBACKID = i.FEEDBACKID, @TRAINERID = i.TRAINERID, @MEMBERID = i.MEMBERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @FEEDBACKID = d.FEEDBACKID, @TRAINERID = d.TRAINERID, @MEMBERID = d.MEMBERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;



CREATE TRIGGER TR_GYMMEMBERSHIP_LOGS
ON GYMMEMBERSHIP
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'GYMMEMBERSHIP';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @MEMBERSHIPID INT = 0;
    DECLARE @USERID INT = 0;
    DECLARE @GYMID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @MEMBERSHIPID = i.MEMBERSHIPID, @USERID = i.USERID, @GYMID = i.GYMID
            FROM inserted i
            INNER JOIN deleted d ON i.MEMBERSHIPID = d.MEMBERSHIPID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @MEMBERSHIPID = i.MEMBERSHIPID, @USERID = i.USERID, @GYMID = i.GYMID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @MEMBERSHIPID = d.MEMBERSHIPID, @USERID = d.USERID, @GYMID = d.GYMID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_TRAINERREGISTRATIONREQUEST_LOGS
ON TRAINERREGISTRATIONREQUEST
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'TRAINERREGISTRATIONREQUEST';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @REQUESTID INT = 0;
    DECLARE @GYMOWNERID INT = 0;
    DECLARE @TRAINERID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @REQUESTID = i.REQUESTID, @GYMOWNERID = i.GYMOWNERID, @TRAINERID = i.TRAINERID
            FROM inserted i
            INNER JOIN deleted d ON i.REQUESTID = d.REQUESTID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @REQUESTID = i.REQUESTID, @GYMOWNERID = i.GYMOWNERID, @TRAINERID = i.TRAINERID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @REQUESTID = d.REQUESTID, @GYMOWNERID = d.GYMOWNERID, @TRAINERID = d.TRAINERID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_MEMBERREGISTRATIONREQUEST_LOGS
ON MEMBERREGISTRATIONREQUEST
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
DECLARE @TABLE_NAME VARCHAR(50) = 'MEMBERREGISTRATIONREQUEST';
DECLARE @ACTION VARCHAR(50) = '';
DECLARE @REQUESTID INT = 0;
DECLARE @MEMBERID INT = 0;
DECLARE @OWNERID INT = 0;
IF EXISTS (SELECT * FROM inserted)
BEGIN
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SET @ACTION = 'UPDATE';
        SELECT @REQUESTID = i.REQUESTID, @MEMBERID = i.MEMBERID
        FROM inserted i
        INNER JOIN deleted d ON i.REQUESTID = d.REQUESTID;
        SELECT @OWNERID = m.OWNERID
        FROM MEMBERREGISTRATIONREQUEST m
        WHERE m.REQUESTID = @REQUESTID;
    END
    ELSE
    BEGIN
        SET @ACTION = 'INSERT';
        SELECT @REQUESTID = i.REQUESTID, @MEMBERID = i.MEMBERID
        FROM inserted i;
        SELECT @OWNERID = m.OWNERID
        FROM MEMBERREGISTRATIONREQUEST m
        WHERE m.REQUESTID = @REQUESTID;
    END
END
ELSE
BEGIN
    SET @ACTION = 'DELETE';
    SELECT @REQUESTID = d.REQUESTID, @MEMBERID = d.MEMBERID
    FROM deleted d;
    SELECT @OWNERID = m.OWNERID
    FROM MEMBERREGISTRATIONREQUEST m
    WHERE m.REQUESTID = @REQUESTID;
END

INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


CREATE TRIGGER TR_GYMREGISTRATIONREQUEST_LOGS
ON GYMREGISTRATIONREQUEST
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    DECLARE @TABLE_NAME VARCHAR(50) = 'GYMREGISTRATIONREQUEST';
    DECLARE @ACTION VARCHAR(50) = '';
    DECLARE @REQUESTID INT = 0;
    DECLARE @GYMID INT = 0;
    DECLARE @ADMINID INT = 0;

    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        IF EXISTS (SELECT * FROM deleted)
        BEGIN
            SET @ACTION = 'UPDATE';
            SELECT @REQUESTID = i.REQUESTID, @GYMID = i.GYMID, @ADMINID = i.ADMINID
            FROM inserted i
            INNER JOIN deleted d ON i.REQUESTID = d.REQUESTID;
        END
        ELSE
        BEGIN
            SET @ACTION = 'INSERT';
            SELECT @REQUESTID = i.REQUESTID, @GYMID = i.GYMID, @ADMINID = i.ADMINID
            FROM inserted i;
        END
    END
    ELSE
    BEGIN
        SET @ACTION = 'DELETE';
        SELECT @REQUESTID = d.REQUESTID, @GYMID = d.GYMID, @ADMINID = d.ADMINID
        FROM deleted d;
    END

    INSERT INTO LOGS (TABLE_NAME, ACTION, USERID, UPDATE_DATE)
    VALUES (@TABLE_NAME, @ACTION, NULL, GETDATE());
END;


-- procedures

CREATE PROCEDURE RegisterGymOwner
    @Username VARCHAR(50),
    @Password1 VARCHAR(100),
    @Email VARCHAR(100),
    @PhoneNo VARCHAR(50),
    @GymName VARCHAR(100),
    @Location1 VARCHAR(100),
    @ContactNumber VARCHAR(20),
    @GymEmail VARCHAR(100)
AS
BEGIN
    DECLARE @UserID INT;
    DECLARE @OwnerID INT;
    DECLARE @GymID INT;
    INSERT INTO USERS (Username, Password1, Email, PhoneNo)
    VALUES (@Username, @Password1, @Email, @PhoneNo);
    SET @UserID = SCOPE_IDENTITY();
    INSERT INTO GYMOWNER (USERID)
    VALUES (@UserID);
    SET @OwnerID = SCOPE_IDENTITY();
    INSERT INTO GYM (GYMNAME, LOCATION1, CONTACTNUMBER, EMAIL, OWNERID)
    VALUES (@GymName, @Location1, @ContactNumber, @GymEmail, @OwnerID);
    SET @GymID = SCOPE_IDENTITY();
    INSERT INTO GYMREGISTRATIONREQUEST (GYMID, REQUESTDATE, APPROVALSTATUS, APPROVALDATE, ADMINID)
    VALUES (@GymID, GETDATE(), 'Pending', NULL, NULL);
END;

CREATE PROCEDURE RegisterTrainer
	@Username VARCHAR(50),
	@Password1 VARCHAR(100),
	@Email VARCHAR(100),
	@PhoneNo VARCHAR(50),
	@Specialization VARCHAR(100),
	@Experience INT,
	@gymid INT,
	@GymOwnerID INT
	AS
	BEGIN
	DECLARE @UserID INT;
	DECLARE @TrainerID INT;
	INSERT INTO USERS (Username, Password1, Email, PhoneNo)
	VALUES (@Username, @Password1, @Email, @PhoneNo);
	SET @UserID = SCOPE_IDENTITY();
	INSERT INTO TRAINER (USERID, SPECIALIZATION, EXPERIENCE, GYMID)
	VALUES (@UserID, @Specialization, @Experience, @gymid);
	SET @TrainerID = SCOPE_IDENTITY();
	INSERT INTO TRAINERREGISTRATIONREQUEST (GYMOWNERID, TRAINERID, REQUESTDATE, APPROVALSTATUS)
	VALUES (@GymOwnerID, @TrainerID, GETDATE(), 'Pending');
END;

CREATE PROCEDURE RegisterMember
@Username VARCHAR(50),
@Password1 VARCHAR(100),
@Email VARCHAR(100),
@PhoneNo VARCHAR(50),
@GymID INT
AS
BEGIN
DECLARE @UserID INT;
DECLARE @MemberID INT;
INSERT INTO USERS (Username, Password1, Email, PhoneNo)
VALUES (@Username, @Password1, @Email, @PhoneNo);

SET @UserID = SCOPE_IDENTITY();

INSERT INTO MEMBER1 (GYMID, USERID)
VALUES (@GymID, @UserID);

SET @MemberID = SCOPE_IDENTITY();

INSERT INTO MEMBERREGISTRATIONREQUEST (MEMBERID, REQUESTDATE, APPROVALSTATUS)
VALUES (@MemberID, GETDATE(), 'Pending');
END;

CREATE PROCEDURE UpdateTrainerRegistrationRequest
@RequestID INT,
@ApprovalStatus VARCHAR(50),
@ApprovalDate DATE
AS
BEGIN
UPDATE TRAINERREGISTRATIONREQUEST
SET APPROVALSTATUS = @ApprovalStatus, APPROVALDATE = @ApprovalDate
WHERE REQUESTID = @RequestID
END

CREATE PROCEDURE UpdateMemberRegistrationRequest
@RequestID INT,
@ApprovalStatus VARCHAR(50),
@ApprovalDate DATE
AS
BEGIN
UPDATE MEMBERREGISTRATIONREQUEST
SET APPROVALSTATUS = @ApprovalStatus, APPROVALDATE = @ApprovalDate
WHERE REQUESTID = @RequestID
END

CREATE PROCEDURE UpdateGymRegistrationRequest
@RequestID INT,
@ApprovalStatus VARCHAR(50),
@ApprovalDate DATE
AS
BEGIN
UPDATE GYMREGISTRATIONREQUEST
SET APPROVALSTATUS = @ApprovalStatus, APPROVALDATE = @ApprovalDate
WHERE REQUESTID = @RequestID
END

CREATE PROCEDURE DeleteGymRegistrationRequest
@RequestID INT
AS
BEGIN
DECLARE @GymID INT
DECLARE @OwnerID INT
DECLARE @UserID INT
SELECT @GymID = GYMID FROM GYMREGISTRATIONREQUEST WHERE REQUESTID = @RequestID
SELECT @OwnerID = OWNERID FROM GYM WHERE GYMID = @GymID
SELECT @UserID = USERID FROM GYMOWNER WHERE OWNERID = @OwnerID
DELETE FROM GYMREGISTRATIONREQUEST WHERE REQUESTID = @RequestID
DELETE FROM GYM WHERE GYMID = @GymID
DELETE FROM GYMOWNER WHERE OWNERID = @OwnerID
DELETE FROM USERS WHERE USERID = @UserID
END

CREATE PROCEDURE DeleteMemberRegistrationRequest
@RequestID INT
AS
BEGIN
DECLARE @MemberID INT
DECLARE @UserID INT
SELECT @MemberID = MEMBERID FROM MEMBERREGISTRATIONREQUEST WHERE REQUESTID = @RequestID
SELECT @UserID = USERID FROM MEMBER1 WHERE MEMBERID = @MemberID
DELETE FROM MEMBERREGISTRATIONREQUEST WHERE REQUESTID = @RequestID
DELETE FROM MEMBER1 WHERE MEMBERID = @MemberID
DELETE FROM USERS WHERE USERID = @UserID
END

CREATE PROCEDURE DeleteTrainerRegistrationRequest
@RequestID INT
AS
BEGIN
DECLARE @TrainerID INT
DECLARE @UserID INT
SELECT @TrainerID = TRAINERID FROM TRAINERREGISTRATIONREQUEST WHERE REQUESTID = @RequestID
SELECT @UserID = USERID FROM TRAINER WHERE TRAINERID = @TrainerID
DELETE FROM TRAINERREGISTRATIONREQUEST WHERE REQUESTID = @RequestID
DELETE FROM TRAINER WHERE TRAINERID = @TrainerID
DELETE FROM USERS WHERE USERID = @UserID
END

CREATE PROCEDURE createWorkoutPlan
    @TRAINERID INT,
    @PLANNAME VARCHAR(100),
    @PLANDESCRIPTION TEXT,
    @EXERCISELIST VARCHAR(MAX) -- These will be comma separated values
AS
BEGIN
    INSERT INTO WORKOUTPLAN (TRAINERID, PLANNAME, PLANDESCRIPTION, CREATIONDATE)
    VALUES (@TRAINERID, @PLANNAME, @PLANDESCRIPTION, GETDATE())

    DECLARE @PLANID INT = SCOPE_IDENTITY()

    INSERT INTO WORKOUTPLANHASEXERCISE (PLANID, EXERCISEID)
    SELECT @PLANID, VALUE
    FROM STRING_SPLIT(@EXERCISELIST, ',')

    INSERT INTO TRAINERWORKOUTPLAN (TRAINERID, PLANID, GENERATEDDATE)
    VALUES (@TRAINERID, @PLANID, GETDATE())

    INSERT INTO EXERCISEDESCRIPTION (PLANID, EXERCISEID, SETS1, REPS, RESTINTERVAL)
    SELECT @PLANID, E.EXERCISE_ID, 3, 12, 60 
    FROM EXERCISE E
    WHERE E.EXERCISE_ID IN (SELECT VALUE FROM STRING_SPLIT(@EXERCISELIST, ','))
        AND NOT EXISTS (
            SELECT 1
            FROM EXERCISEDESCRIPTION
            WHERE PLANID = @PLANID AND EXERCISEID = E.EXERCISE_ID
        )
END

CREATE PROCEDURE createDietPlan
    @TRAINERID INT,
    @PLANNAME VARCHAR(100),
    @PLANDESCRIPTION TEXT,
    @MEALLIST VARCHAR(MAX),  -- comma-separated list of meal IDs
    @ALLERGENLIST VARCHAR(MAX)  -- comma-separated list of allergen IDs
AS
BEGIN
    INSERT INTO DIETPLAN (TRAINERID, PLANNAME, PLANDESCRIPTION, CREATIONDATE)
    VALUES (@TRAINERID, @PLANNAME, @PLANDESCRIPTION, GETDATE())

    DECLARE @DIETID INT = SCOPE_IDENTITY()

    INSERT INTO MEALPLAN (DIETID, MEALID)
    SELECT @DIETID, CONVERT(INT, VALUE)
    FROM STRING_SPLIT(@MEALLIST, ',')

    DECLARE @MEALLIST_TABLE TABLE (MEALID INT)
    INSERT INTO @MEALLIST_TABLE
    SELECT CONVERT(INT, VALUE)
    FROM STRING_SPLIT(@MEALLIST, ',')

    DECLARE @ALLERGENLIST_TABLE TABLE (ALLERGENID INT)
    INSERT INTO @ALLERGENLIST_TABLE
    SELECT CONVERT(INT, VALUE)
    FROM STRING_SPLIT(@ALLERGENLIST, ',')

    INSERT INTO HAS (MEALID, ALLERGENID)
    SELECT ML.MEALID, AL.ALLERGENID
    FROM @MEALLIST_TABLE ML
    CROSS JOIN @ALLERGENLIST_TABLE AL
END

CREATE PROCEDURE giveFeedback
    @TRAINERID INT,
    @MEMBERID INT,
    @RATING INT,
    @COMMENT TEXT,
    @DATE1 DATE = NULL
AS
BEGIN
    IF @DATE1 IS NULL
        SET @DATE1 = GETDATE()

    INSERT INTO FEEDBACK (TRAINERID, MEMBERID, RATING, COMMENT, DATE1)
    VALUES (@TRAINERID, @MEMBERID, @RATING, @COMMENT, @DATE1)
END

CREATE PROCEDURE CreateAppointment
    @TRAINERID INT,
    @MEMBERID INT,
    @LOCATION1 VARCHAR(50),
    @DURATION VARCHAR(50),
    @DATE1 DATE,
    @TIME1 TIME,
    @STATUS1 VARCHAR(50)
AS
BEGIN
    INSERT INTO APPOINTMENT (TRAINERID, MEMBERID, LOCATION1, DURATION, DATE1, TIME1, STATUS1)
    VALUES (@TRAINERID, @MEMBERID, @LOCATION1, @DURATION, @DATE1, @TIME1, @STATUS1)

END

CREATE PROCEDURE updateAppointmentStatus
    @APPOINTMENTID INT,
    @STATUS1 VARCHAR(50)
AS
BEGIN
    UPDATE APPOINTMENT
    SET STATUS1 = @STATUS1
    WHERE APPOINTMENTID = @APPOINTMENTID
END

CREATE PROCEDURE updateAppointmentTime
    @APPOINTMENTID INT,
    @TIME1 TIME
AS
BEGIN
    UPDATE APPOINTMENT
    SET TIME1 = @TIME1
    WHERE APPOINTMENTID = @APPOINTMENTID
END