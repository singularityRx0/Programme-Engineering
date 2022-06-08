CREATE TABLE o_Membership 
(	ID varchar(50),
	Person_Name varchar(50),
	Identity_Card_Number varchar(50),
	Phone_Number varchar(50),
	E_Mail varchar(50),
	Set_Password varchar(50),
	Membership_Type varchar(50),
	Total_Points int,
	Rebate_Percetage float,
	Expiry_Date datetime,
);

INSERT INTO o_Membership 
VALUES ('0128628711', 'liew zi hao', '000523121603', '0128628711', 'helloworld1234525@gmail.com', 'password12345' ,'monthly', '20', '0.2', '2022-5-23 17:23:44'),
		('0146771399', 'Christabel', '0054851349841', '0146771399', 'gi@gmail.com', 'password122545' ,'yearly', '50', '0.3', '2022-5-11 13:25:44'),
		('01131428559', 'Nicholas', '0005823121103', '01131428559', 'uwu@gmail.com', 'password4326345' ,'monthly', '100', '0.2', '2022-5-05 11:30:02');

SELECT * FROM o_Membership
