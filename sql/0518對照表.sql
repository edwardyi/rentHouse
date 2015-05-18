select * from CHPUB.dbo.Departs where company = 1000 order by dept
select * from bpmsvr.[AgilePoint].[dbo].[CX_OU] where SITE_ID = '100' order by RANK
select dept,COUNT(*) from CHPUB.dbo.Departs where company = 1000  
group by dept order by dept
select rank,COUNT(*) from bpmsvr.[AgilePoint].[dbo].[CX_OU] where SITE_ID = '100'
group by rank order by rank
--判斷是否暫存資料表存在，若存在就刪除暫存的資料表
If OBJECT_ID('tempdb.dbo.#OutDept','U') is Not null
	drop table #OutDept
If OBJECT_ID('tempdb.dbo.#OutRank','U') is Not null
	drop table #OutRank
--建立回傳table
CREATE TABLE #OutDept(
	dept varchar(10),
	deptNo varchar(10),
	deptNoName varchar(20)
)

CREATE TABLE #OutRank(
	RANK varchar(10),
	OU_ID varchar(10),
	OU_NAME varchar(20)
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
--Where
--	A.countA = B.countB
OPEN output_cursor
Fetch next from output_cursor into @dept,@countA,@rank,@countB
	while(@@FETCH_STATUS = 0)
	Begin
		--SELECT  @countA , @countB
		IF @countA = @countB
		 INSERT INTO #OutRank(RANK,OU_ID,OU_NAME)
		 SELECT 
			  RANK,OU_ID,OU_NAME
		  FROM
			bpmsvr.[AgilePoint].[dbo].[CX_OU] 
		  WHERE 
			RANK = @rank
			AND
			SITE_ID='100'
		  INSERT INTO #OutDept( dept,deptNo,deptnOName )
		  SELECT 
				 dept,deptNo,deptnOName 
			  FROM 
				  CHPUB.dbo.Departs
			  WHERE 
				  dept = @dept
				  AND company = 1000 
				  AND bpmDept=1
		  
		 
	
		--select @dept,@countA,@rank,@countB
		--Print @output
		--Set @output = @output + @row + ';'
		--要再將指標往後移
		FETCH NEXT FROM output_cursor INTO  @dept,@countA,@rank,@countB
	End
Close output_cursor
deallocate output_cursor

select * from #OutDept
select * from #OutRank
--判斷是否暫存資料表存在，若存在就刪除暫存的資料表
If OBJECT_ID('tempdb.dbo.#OutDept','U') is Not null
	drop table #OutDept
If OBJECT_ID('tempdb.dbo.#OutRank','U') is Not null
	drop table #OutRank
--select @output

--where B.rank <> ''
--group by A.dept


