CREATE DATABASE PracticeDB;
USE PracticeDB;
CREATE TABLE PracticeTable2
( Name varchar(50),
email varchar(100),
address varchar(100)
)
SELECT * FROM PracticeTable2;
INSERT INTO PracticeTable2 VALUES ('Sumitom', 'sumitomshome@gmail.com', 'Kolkata');
INSERT INTO PracticeTable2 VALUES ('Aniket', 'aniket228@gmail.com', 'Kolkata');
INSERT INTO PracticeTable2 VALUES ('Aniket', 'aniket228@gmail.com', 'Kolkata');
SELECT DISTINCT * INTO PracticeTableNewlyCreated FROM PracticeTable2;
SELECT * FROM PracticeTableNewlyCreated;