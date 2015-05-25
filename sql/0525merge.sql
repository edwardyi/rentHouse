IF OBJECT_ID('tempdb.dbo.#TempBigHouse','U') IS NOT NULL
	DROP TABLE #TempBigHouse
IF OBJECT_ID('tempdb.dbo.#TempReturnHouse','U') IS NOT NULL
	DROP TABLE #TempReturnHouse
CREATE TABLE #TempBigHouse(
	ProductName NVARCHAR(50),
	InventoryNum INT
)
CREATE TABLE #TempReturnHouse(
	ProductName NVARCHAR(50),
	ReturnNum INT
)
INSERT INTO #TempBigHouse
   SELECT '中文書',10
INSERT INTO #TempBigHouse
   SELECT '英文書',5
INSERT INTO #TempBigHouse
   SELECT '法文書',1
   
INSERT INTO #TempReturnHouse
   SELECT '中文書',5
INSERT INTO #TempReturnHouse
   SELECT '英文書',-5
INSERT INTO #TempReturnHouse
   SELECT '日文書',6   
--將兩張表 MERGE
--當兩張表有資料 MERGE 時，且 庫存量 加上 進退貨量 等於零時，則刪除資料
--當兩張表有資料 MERGE 時，將 庫存量 加上 進退貨量 更新到 庫存量
--當兩張表沒有資料 MERGE 時，將 進退貨倉庫 的資料新增到 大倉庫 中
MERGE INTO #TempBigHouse A
	USING #TempReturnHouse B
	ON A.ProductName = B.ProductName
WHEN MATCHED AND(A.InventoryNum+B.ReturnNum=0) THEN
	DELETE
WHEN MATCHED THEN
	UPDATE SET A.InventoryNum =  A.InventoryNum + B.ReturnNum
WHEN NOT MATCHED THEN
    INSERT VALUES( B.ProductName, B.ReturnNum);
    
    
 SELECT * FROM #TempBigHouse
 
