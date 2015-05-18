SELECT 
		RANK,OU_ID,OU_NAME,*

	FROM 
		bpmsvr.[AgilePoint].[dbo].[CX_OU] 
	WHERE 
		RANK = 'U0100'
	AND
		SITE_ID='100'
--要加上company為1000的條件限制
SELECT 
		dept,deptNo,deptnOName,*
   
	FROM 
		CHPUB.dbo.Departs 
	WHERE 
		dept = 'A2322'
	AND 
	   bpmDept =1
	AND 
		company = 1000

SELECT * FROM 
(
	SELECT 
		dept,COUNT(*) AS countA  
	FROM 
		CHPUB.dbo.Departs 
	WHERE 
		company = 1000 
		AND bpmDept=1
	GROUP BY 
		dept
)A
LEFT JOIN 
(
	SELECT 
		RANK,COUNT(*) AS countB  
	FROM 
		bpmsvr.[AgilePoint].[dbo].[CX_OU] 
	WHERE 
		SITE_ID = '100'
	GROUP BY 
		RANK
)B
ON
	A.dept = B.RANK
	