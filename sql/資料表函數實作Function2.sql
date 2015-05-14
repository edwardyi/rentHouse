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
-- Description:	字串分割函數練習
-- =============================================
CREATE FUNCTION [dbo].[fnEdwardTest]
( 
    @targetStr VARCHAR(10), --目標字串
	@splitChar VARCHAR(1)   --分割字串
)
RETURNS 
@TempTable TABLE         --資料表:顯示分割字符
(
    Id Int,
    SplitStr VARCHAR(5)
) 
AS
BEGIN
	DELETE @TempTable	
	DECLARE
		@i Int = 1,         -- 計數器
		@output varchar(5)
	--設值要記得要加set阿XD
    set @targetStr = @targetStr + @splitChar
	while(LEN(@targetStr)>1)
	Begin
		--設定output
		set @output = SubString(@targetStr,1,CharIndex(@splitChar,@targetStr)-1)
		--重設targetStr
		set @targetStr = RIGHT(@targetStr,LEN(@targetStr)-CHARINDEX(@splitChar,@targetStr))
		--寫入暫存的資料表
		INSERT INTO @TempTable(Id,SplitStr) values(@i,@output)
		--計數器加1
		set @i = @i +1
	End
	Return
END

	

GO

IF object_id(N'fnEdwardTest', N'TF') IS NOT NULL
    DROP FUNCTION fnEdwardTest
GO

