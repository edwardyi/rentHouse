-- 0514定義函數的參數
-- 傳入字串和分割字元
DECLARE @targetStr Varchar(10),
        @splitChar Varchar(1)
-- 設值
SET @targetStr = 'A;B;C;D;E'
SET @splitChar = ';'
--函數的主體內容
DECLARE @i int

--判斷是否暫存資料表存在，若存在就刪除暫存的資料表
If OBJECT_ID('tempdb.dbo.#ReturnTable','U') is Not null
	drop table #ReturnTable
--建立回傳table
CREATE TABLE #ReturnTable(
	Id int,
	SplitStr varchar(5)
)
--計數器
Set @i = 1
-- 在分割字串的最後面加上分號，讓剩下的字串能顯示出來
Set @targetStr = @targetStr + @splitChar

--要加Begin和END:作為while迴圈的區塊(if條件判斷也是)
while(LEN(@targetStr)>1)
Begin
	 --輸出
	 Declare @output varchar(5)
	 set @output = SUBSTRING(@targetStr,1,CHARINDEX(@splitChar,@targetStr)-1)
	 --SELECT SUBSTRING(@targetStr,1, CHARINDEX(@splitChar,@targetStr)-1)
	 --設定下一個字串(取右方剩下的字串=全部扣除輸出的字串得到剩下長度)
	 SET @targetStr = RIGHT(@targetStr,LEN(@targetStr)-CharIndex(@splitChar,@targetStr))
	 
	 --SELECT LEN(@targetStr)
	 
	INSERT INTO #ReturnTable(Id,SplitStr) values(@i,@output)
	set @i = @i +1
	
END

 



select * from #ReturnTable

--判斷是否暫存資料表存在，若存在就刪除暫存的資料表
If OBJECT_ID('tempdb.dbo.#ReturnTable','U') is Not null
	drop table #ReturnTable








--CHARINDEX 將根據輸入的排序規則執行比較操作。
--LTRIM (字串): 將所有字串起頭的空白移除。
--RTRIM (字串): 將所有字串結尾的空白移除。

--select CHARINDEX(@splitChar,@targetStr)
--如果有找到值就加入暫存的資料表中

--while(CHARINDEX(@splitChar,@targetStr)>0)
--	---Insert into #ReturnTable(data)
--	select Str = LTRIM(rtrim(Substring(@targetStr,1,CHARINDEX(@splitChar,@targetStr) -1)))
--	set @targetStr = SUBSTRING(@targetStr,CHARINDEX(@splitChar,@targetStr)+1,LEN(@targetStr))
--	set @i = @i +1


