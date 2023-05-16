--
-- Create a database using `MYSQL_DATABASE` placeholder
--
CREATE DATABASE IF NOT EXISTS `meter-reading`;
USE `meter-reading`;


CREATE TABLE Accounts (
AccountId int,
FirstName  varchar(25),
LastName varchar(25)
);


CREATE TABLE MeterReading (
    ReadingId int NOT NULL AUTO_INCREMENT,
    MeterReadValue int NOT NULL,
    AccountId int NOT NULL, 
    MeterReadingDateTime DATETIME NOT NULL,
    PRIMARY KEY (ReadingId)  
);


-- -#SHOW VARIABLES LIKE "secure_file_priv";
-- -#SHOW VARIABLES LIKE "local_infile";
-- -LOAD DATA INFILE 'Test_Accounts.csv'
-- -INTO TABLE Accounts
-- -FIELDS TERMINATED BY ','
-- -ENCLOSED BY '"'
-- -LINES TERMINATED BY '\n'
-- -IGNORE 1 ROWS;

Insert  
  INTO Accounts
VALUES 
(2344,'Tommy','Test'),
(2233,'Barry','Test'),
(8766,'Sally','Test'),
(2345,'Jerry','Test'),
(2346,'Ollie','Test'),
(2347,'Tara','Test'),
(2348,'Tammy','Test'),
(2349,'Simon','Test'),
(2350,'Colin','Test'),
(2351,'Gladys','Test'),
(2352,'Greg','Test'),
(2353,'Tony','Test'),
(2355,'Arthur','Test'),
(2356,'Craig','Test'),
(6776,'Laura','Test'),
(4534,'JOSH','Test'),
(1234,'Freya','Test'),
(1239,'Noddy','Test'),
(1240,'Archie','Test'),
(1241,'Lara','Test'),
(1242,'Tim','Test'),
(1243,'Graham','Test'),
(1244,'Tony','Test'),
(1245,'Neville','Test'),
(1246,'Jo','Test'),
(1247,'Jim','Test'),
(1248,'Pam','Test');

