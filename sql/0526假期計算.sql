
--國華寫法
SELECT    ID,userID, transDate,COUNT(*)
	FROM WORKFLOW.dbo.QcNCMR A
	LEFT JOIN [CHPUB].[BM].[Calendar] B
	ON B.setDate BETWEEN A.transDate AND GETDATE()
	WHERE cldID = 'CLD00001'
	GROUP BY ID,userID, transDate
	ORDER BY ID

--查詢出有輸入日期有哪些。
SELECT userID,transDate,COUNT(*) FROM(
	SELECT transDate,userID
	FROM WORKFLOW.dbo.QcNCMR
	GROUP BY transDate,userID
)A LEFT JOIN 
(
	SELECT setDate
	FROM [CHPUB].[BM].[Calendar]
	WHERE cldYear='2015' 
	AND cldID = 'CLD00001' 
)B
ON B.setDate
BETWEEN A.transDate AND GETDATE()	
GROUP BY A.transDate,A.userID
