USE [OnlinePOSdb]
GO
/****** Object:  StoredProcedure [dbo].[p_Membership_Fd]    Script Date: 22/6/2022 5:12:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

--mc

ALTER  PROCEDURE [dbo].[p_Membership_Fd] 
  @ID integer=0,
  @Person_Name nvarchar(50)=''
--WITHENCRYPTION
AS
   set nocount on

  set @Person_Name=isnull(rtrim(ltrim(@Person_Name)),'')

  select a.*, f.code as updatebyPerson_Name
  from o_Membership a  left join o_user f on a.ID=f.ID   
  where 
               (isnull(@Person_Name,'')='' or a.Person_Name=@Person_Name) and
               (isnull(@ID,0)=0 or a.ID=@ID) and
               (isnull(@Person_Name,'')<>'' or isnull(@ID,0)<>0)
return 0









