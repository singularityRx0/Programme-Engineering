USE [OnlinePOSdb]
GO
/****** Object:  StoredProcedure [dbo].[p_Membership_Src]    Script Date: 22/6/2022 5:12:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[p_Membership_Src] 
  @searchtext nvarchar(100) ,
      @PageRow int,
    @PageIndex int
  --WITHENCRYPTION
AS
  set nocount on
             

	
  declare @PageCount int,@RowCount int,@Rows int,
          @StartRow int

		  set @searchtext='%'+trim(@searchtext)+'%'


  select @RowCount=count(a.ID)
  from o_Membership a
     where 
                 (isnull(a.Person_Name,'') like @searchtext or
                 isnull(a.Identity_Card_Number,'') like @searchtext) and
                 isnull(a.Phone_Number,'') like @searchtext and
                 isnull(a.E_Mail,'') like @searchtext and
				         isnull(a.Uniq_ID,'') like @searchtext and
                 isnull(a.Set_Password,'') like @searchtext and
                 (isnull(a.Membership_Type,'') like @searchtext or
                 isnull(a.Total_Points,'') like @searchtext) and
				 (isnull(a.Rebate_Percentage,'') like @searchtext or 
				 isnull(a.Expiry_Date,'') like @searchtext)

             



     select @RowCount=isnull(@RowCount,0)
  select @Pagecount=convert(int,@RowCount/@PageRow)

  if @RowCount-(@Pagecount*@PageRow)>0 set @Pagecount=@Pagecount+1

   
  if @PageIndex>@PageCount select @PageIndex=1
  
  if @PageCount=0 select @Pageindex=0

  select @StartRow=(@PageIndex-1) * @PageRow  + 1

  if @RowCount=0
  begin
    set @StartRow=1
  end 


    select ROW_NUMBER() OVER(ORDER BY a.Person_Name) as seq, 
	    a.ID,a.Person_Name,a.Identity_Card_Number,a.Phone_Number,a.E_Mail,
                     a.Uniq_ID,a.Set_Password,a.Membership_Type,a.Total_Points,a.Rebate_Percentage,
					 a.Expiry_Date
   from o_Membership a
     where 
                 (isnull(a.Person_Name,'') like @searchtext or
                 isnull(a.Identity_Card_Number,'') like @searchtext) and
                 isnull(a.Phone_Number,'') like @searchtext and
                 isnull(a.E_Mail,'') like @searchtext and
				         isnull(a.Uniq_ID,'') like @searchtext and
                 isnull(a.Set_Password,'') like @searchtext and
                 (isnull(a.Membership_Type,'') like @searchtext or
                 isnull(a.Total_Points,'') like @searchtext) and
				 (isnull(a.Rebate_Percentage,'') like @searchtext or 
				 isnull(a.Expiry_Date,'') like @searchtext)
			
	order by seq
	  OFFSET (@StartRow-1) ROWS FETCH NEXT @PageRow ROWS ONLY 
  
  

  select @PageIndex=isnull(@PageIndex,0)
  select @Pagecount=isnull(@Pagecount,0)

  
  
  select @Pagecount as pagecount,@StartRow as StartRow,
         @PageIndex as Pageindex,@Rowcount as ResultCount



    return 0
			 
return 0










