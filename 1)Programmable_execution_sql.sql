USE [OnlinePOSdb]
GO
/******Object: StoredProcedure [dbo].[o_Membership_Fd]*****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[p_o_Membership]
	@ID integer = 0
AS
	SET NOCOUNT ON
	SELECT a.*
	FROM o_Membership a
	WHERE a.ID=@ID
	RETURN 0

