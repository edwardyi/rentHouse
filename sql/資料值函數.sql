
--cast寫法:將原本數值類型的欄位轉為字串輸出
Declare @s varchar(50)
set @s = '' --沒有初始化就會出現Null的值
SELECT  @s = @s + cast(muNodeID As varchar(10))+';'  FROM CHPUB.BM.MainMenu WHERE muParentId = 410
select @s


--定義輸出字串(cursor寫法) =>沒有寫成功
Declare @output varchar(10),
	@row varchar(5)

DECLARE cursorTest CURSOR
For SELECT  muNodeID  FROM CHPUB.BM.MainMenu WHERE muParentId = 410
--加入記憶體
OPEN cursorTest
FETCH NEXT FROM cursorTest INTO @row
	WHILE(@@FETCH_STATUS =0)
	Begin
		--Print @row
		set @output =  @row +  ';' + @output 
		Fetch next from cursorTest into @output
	END

	--WHILE (@@FETCH_STATUS <> -1)
	--BEGIN
	--	If (@@FETCH_STATUS <> -2)
	--	Begin
	--		set @output = @output + ';' + @row 
	--		--Print @row
	--	End
	--	Fetch next from cursorTest into @output
		
	--		--SET @output = @output + @row  +';'
	--END
--關閉釋放記憶體
CLOSE cursorTest
DEALLOCATE cursorTest 

--如果有值就顯示
If @output <> ''
BEGIN
	Select @output
END




--@@FETCH_STATUS
--The FETCH statement was successful.
--The FETCH statement failed or the row was beyond the result set.
--The row fetched is missing.
