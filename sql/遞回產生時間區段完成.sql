USE [C:\USERS\TW018008\DOCUMENTS\GITHUB\RENTHOUSE\APP_DATA\RENTHOUSE1.MDF]
GO
/****** Object:  StoredProcedure [dbo].[createTempTimeRecursiveTable]    Script Date: 05/25/2015 09:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[createTempTimeRecursiveTable]
	/*
	不用Declare
	*/	
	@start DATETIME,
	@end DATETIME
AS
BEGIN
   /* SET NOCOUNT ON */
	IF OBJECT_ID('tempdb.dbo.#TempTimeTable','U') IS NOT NULL
	DROP TABLE #TempTimeTable
CREATE TABLE #TempTimeTable(
	StartTime DATETIME,
	EndTime DATETIME
)

INSERT INTO #TempTimeTable
	SELECT @start,@end
	
--SELECT * FROM #TempTimeTable

;WITH TimeRecursive(StartTime,EndTime,flag,interval) 
AS
(
	SELECT DATEADD(MONTH,0,StartTime),
		   DATEADD(MONTH,1,StartTime),
		   0,
		   0
    FROM #TempTimeTable
	
	UNION ALL
	-- WHERE 條件式用結束日期大於開始日期來生成時間區段
	SELECT DATEADD(MONTH,flag+1,A.StartTime),
		   DATEADD(MONTH,flag+2,A.StartTime),
		   flag+1,
		   DATEDIFF(month,A.StartTime,A.EndTime)-2 AS interval
	FROM #TempTimeTable A, TimeRecursive B
	WHERE A.EndTime >= B.StartTime and B.flag <= B.interval
)
SELECT LEFT(CONVERT(VARCHAR,StartTime,111),7) AS startTime,
	   LEFT(CONVERT(VARCHAR,EndTime,111),7) AS endTime 
FROM TimeRecursive
	
	RETURN
	
END



