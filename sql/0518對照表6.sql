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
	WHERE 
		B.countB <> ''
	AND
		A.countA = 1
	AND 
		B.countB = 1