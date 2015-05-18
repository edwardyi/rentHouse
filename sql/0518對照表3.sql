If OBJECT_ID('tempdb.dbo.#OutResult','U') is Not null
	drop table #OutResult
--建立回傳table
CREATE TABLE #OutResult(
	OU_ID varchar(10),
	deptNo varchar(10)
)
--迴圈
Declare @dept varchar(10),
		@countA int ,
		@rank varchar(10),
		@countB int
Declare output_cursor CURSOR
	FOR SELECT * FROM 
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
    OPEN output_cursor
Fetch next from output_cursor into @dept,@countA,@rank,@countB
	while(@@FETCH_STATUS = 0)
		Begin
		INSERT INTO #OutResult(OU_ID,deptNo)
		select B.OU_ID,A.deptNo from CHPUB.dbo.Departs AS A,bpmsvr.[AgilePoint].[dbo].[CX_OU] AS B  
		 where dept = @dept and RANK = @dept
		 and A.company=1000
		 and A.bpmDept =1
		 and B.SITE_ID ='100'
		FETCH NEXT FROM output_cursor INTO  @dept,@countA,@rank,@countB
		End
Close output_cursor
deallocate output_cursor    
SELECT * FROM #OutResult
If OBJECT_ID('tempdb.dbo.#OutResult','U') is Not null
	drop table #OutResult