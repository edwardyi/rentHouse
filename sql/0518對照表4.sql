SELECT 
		*
	FROM 
		bpmsvr.[AgilePoint].[dbo].[CX_OU] 
	WHERE 
		SITE_ID = '100'
		and OU_ID='131C110'
	
SELECT 
		*
	FROM 
		CHPUB.dbo.Departs 
	WHERE 
		company = 1000 
		AND bpmDept=1
	    AND deptNo = 'D2011067'


SELECT 
		dept,COUNT(*) AS countA  
	FROM 
		CHPUB.dbo.Departs 
	WHERE 
		company = 1000 
		AND bpmDept=1
	GROUP BY 
		dept


SELECT 
		RANK,COUNT(*) AS countB  
	FROM 
		bpmsvr.[AgilePoint].[dbo].[CX_OU] 
	WHERE 
		SITE_ID = '100'
	GROUP BY 
		RANK