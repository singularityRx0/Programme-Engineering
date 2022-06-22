USE [OnlinePOSdb]
GO
/****** Object:  StoredProcedure [dbo].[p_Membership_Updt]    Script Date: 22/6/2022 5:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[p_Membership_Updt] 
  @ID int output,
  @Person_Name nvarchar(50),
  @Identity_Card_Number nvarchar(50),
  @Phone_Number nvarchar(50),
  @E_mail nvarchar(50),
  @Uniq_ID nvarchar(50),
  @Set_Password nvarchar(50),
  @Membership_Type nvarchar(50),
  @Total_Points nvarchar(50),
  @Rebate_Percentage nvarchar(50),
  @Expiry_Date nvarchar(50),
  @UpdateBy int,
  @Action nvarchar(10)

 --WITHENCRYPTION 
AS
   set nocount on

   select @Person_Name=ltrim(rtrim(@Person_Name))
   set @Identity_Card_Number=isnull(rtrim(ltrim(@Identity_Card_Number)),'')
   set @Phone_Number=isnull(rtrim(ltrim(@Phone_Number)),'')
   set @E_mail=isnull(rtrim(ltrim(@E_mail)),'')
   set @Uniq_ID=isnull(rtrim(ltrim(@Uniq_ID)),'')
   set @Set_Password=isnull(rtrim(ltrim(@Set_Password)),'')
   set @Membership_Type=isnull(rtrim(ltrim(@Membership_Type)),'')
   set @Total_Points=isnull(rtrim(ltrim(@Total_Points)),'')
   set @Rebate_Percentage=isnull(rtrim(ltrim(@Rebate_Percentage)),'')
   set @Expiry_Date=isnull(rtrim(ltrim(@Expiry_Date)),'')

   declare @R integer
   /***********delete*********************/
   if @Action='DEL'
   begin
       exec @R=p_o_userobjectpermission_chk @Updateby,235
	   if @@ERROR<>0 or @R<>0
	   begin
			  return 1
	   end

     if exists(select * from o_Invoice where o_customerID=@ID)
     begin
       RAISERROR('[Error] p_Membership_Updt-51 [Description] Used in o_Invoice. [Action] Please try again.',16,1)
       return 1
     end


     Delete from o_Membership where ID=@ID
     if @@error<>0 or @@rowcount=0    
     begin
       RAISERROR('[Error] p_Membership_Updt-5 [Description] Cannot delete Debtor record. [Action] Please try again.',16,1)
       return 1
     end
     return 0
   end
/***********validate value*********************/   
   if @Person_Name='' or @Person_Name is null
   begin  
       RAISERROR('[Error] p_Membership_Updt-2 [Description] Invalid Code. [Action] Please try again.',16,1)
       return 1
   end 

   if isnull(@Identity_Card_Number,'')=''
   begin  
        RAISERROR('[Error] p_Membership_Updt-1 [Description] Invalid Description. [Action] Please try again.',16,1)
        return 1
   end 


/*******new******************/
   if @Action='NEW'
   begin
        exec @R=p_o_userobjectpermission_chk @Updateby,237
	   if @@ERROR<>0 or @R<>0
	   begin
			  return 1
	   end

	  if exists(select * from o_Membership where Person_Name=@Person_Name)
      begin  
        RAISERROR('[Error] p_Membership_Updt-1 [Description] Invalid Code2. [Action] Please try again.',16,1)
        return 1
     end 

     begin transaction
     select @ID=0       
     exec @r=p_o_GetNewId 'o_customerID',@ID output
     if @r<>0  or @ID=0 or @ID is null
     begin
             RAISERROR('[Error] p_Membership_Updt-5 [Description] Cannot get new id for id. [Action] Please try again.',16,1)
             rollback transaction
             return 1
     end     
 
     insert into o_Membership(Id,Person_Name,Identity_Card_Number,Phone_Number,E_Mail,Uniq_ID,Set_Password,Membership_Type,Total_Points,Rebate_Percentage,Expiry_Date,UpdateBy,UpdateAt,CreatedAt)
         values (@Id,@Person_Name,@Identity_Card_Number,@Phone_Number,@E_mail,@Uniq_ID,@Set_Password,@Membership_Type,@Total_Points,@Rebate_Percentage,@Expiry_Date,@UpdateBy,getdate(),getdate())
     if @@error<>0 or @@rowcount=0    
     begin
       RAISERROR('[Error] p_Membership_Updt-3 [Description] Cannot insert member record. [Action] Please try again.',16,1)
       rollback transaction
       return 1
     end
     commit transaction
     return 0
   end 
/***********update*******************/
   if @Action='UPDATE'
   begin
       exec @R=p_o_userobjectpermission_chk @Updateby,236
	   if @@ERROR<>0 or @R<>0
	   begin
			  return 1
	   end

    if exists(select * from o_Membership where Person_Name=@Person_Name and ID<>@ID)
      begin  
        RAISERROR('[Error] p_Membership_Updt-1 [Description] Invalid Code2. [Action] Please try again.',16,1)
        return 1
     end 

     update o_Membership set Person_Name=@Person_Name,Identity_Card_Number=@Identity_Card_Number,
                           Phone_Number=@Phone_Number,E_Mail=@E_mail,Uniq_ID=@Uniq_ID,Set_Password=@Set_Password,
                             Membership_Type=@Membership_Type,Total_Points=@Total_Points,
           Rebate_Percentage=@Rebate_Percentage, Expiry_Date=@Expiry_Date, UpdateBy=@UpdateBy, UpdateAt=getdate()
           
         where ID=@ID
     if @@error<>0 or @@rowcount=0    
     begin
       RAISERROR('[Error] p_Membership_Updt-4 [Description] Cannot update Member record. [Action] Please try again.',16,1)
       return 1
     end
     return 0
            
   end 
   return 0
