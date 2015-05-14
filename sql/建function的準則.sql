--T-SQL
--1. 宣告變數用Declare
--2. Set和Select是一樣的
--3. #:暫存Table(使用完之後要drop掉)=>釋放記憶體
--4. 在sql檔案中先模擬設值與傳值到函數中。
--5. 建立function時，按右鍵=>編寫函數至指令碼為=>Create至=>新增查詢編輯視窗
--6. 建立後，要立刻修改函數的名稱，怕會將之前的程式碼複寫掉。

DECLARE
	@nowNum VARCHAR(10),
	@runNumLen INT
    set @nowNum = '2'
    set @runNumLen = 10
    
	DECLARE @refValue VARCHAR(16)
	SET @refValue = REPLICATE('0', (@runNumLen-LEN(@nowNum)))+ @nowNum
    select @refValue 
    
    
    
SELECT CHPUB.[dbo].[fnFormatZero]('2', 10)



--CREATE TABLE #Temp
--(
--)

--DROP TABLE #Temp