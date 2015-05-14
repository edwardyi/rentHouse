--針對UserBase的資料表進行查詢,並輸出單一值,要下where語法(B.level=A.level))

select *,
(select distinct IsNull(LevelName,'無頭銜')
	from CHHRDB01.hrdb.dbo.JOB As B 
	where B.level=A.level )  '頭銜'
from  CHPUB.OM.UserBase As A 

--15秒
--select A.*,B.LevelName from CHPUB.OM.UserBase As A 
--left join CHHRDB01.hrdb.dbo.JOB As B on A.level = B.level
 

