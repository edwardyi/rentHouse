USE [CHPUB]
GO

/****** Object:  UserDefinedFunction [dbo].[fnAdvMgOU]    Script Date: 05/14/2015 14:31:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--url:http://stackoverflow.com/questions/2290770/how-do-i-drop-a-function-if-it-already-exists

IF object_id(N'fnEdwardTest', N'TF') IS NOT NULL
    DROP FUNCTION fnEdwardTest
GO

-- =============================================
-- Author:		Edward
-- Create date: 2015/05/14
-- Description:	�r����Ψ�ƽm��
-- =============================================
CREATE FUNCTION [dbo].[fnEdwardTest]
( 
    @targetStr VARCHAR(10), --�ؼЦr��
	@splitChar VARCHAR(1)   --���Φr��
)
RETURNS 
@TempTable TABLE         --��ƪ�:��ܤ��Φr��
(
    Id Int,
    SplitStr VARCHAR(5)
) 
AS
BEGIN
	DELETE @TempTable	
	DECLARE
		@i Int = 1,         -- �p�ƾ�
		@output varchar(5)
	--�]�ȭn�O�o�n�[set��XD
    set @targetStr = @targetStr + @splitChar
	while(LEN(@targetStr)>1)
	Begin
		--�]�woutput
		set @output = SubString(@targetStr,1,CharIndex(@splitChar,@targetStr)-1)
		--���]targetStr
		set @targetStr = RIGHT(@targetStr,LEN(@targetStr)-CHARINDEX(@splitChar,@targetStr))
		--�g�J�Ȧs����ƪ�
		INSERT INTO @TempTable(Id,SplitStr) values(@i,@output)
		--�p�ƾ��[1
		set @i = @i +1
	End
	Return
END

	

GO

IF object_id(N'fnEdwardTest', N'TF') IS NOT NULL
    DROP FUNCTION fnEdwardTest
GO

