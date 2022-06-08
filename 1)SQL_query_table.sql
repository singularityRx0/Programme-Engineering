CREATE TABLE o_Membership 
(	ID int,
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

SELECT * FROM o_Membership
