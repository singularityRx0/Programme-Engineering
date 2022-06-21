CREATE TABLE o_Membership 
(	ID int,
	Person_Name nvarchar(50),
	Identity_Card_Number nvarchar(50),
	Phone_Number nvarchar(50),
	E_Mail nvarchar(50),
 	Uniq_ID nvarchar(50),
	Set_Password nvarchar(50),
	Membership_Type nvarchar(50),
	Total_Points nvarchar(50),
	Rebate_Percetage nvarchar(50),
	Expiry_Date nvarchar(50),
 	UpdateBy int,
 	UpdateAt dattime,
 	CreatedAt datetime,
);


SELECT * FROM o_Membership
