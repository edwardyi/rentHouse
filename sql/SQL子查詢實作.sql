--�w��UserBase����ƪ�i��d��,�ÿ�X��@��,�n�Uwhere�y�k(B.level=A.level))

select *,
(select distinct IsNull(LevelName,'�L�Y��')
	from CHHRDB01.hrdb.dbo.JOB As B 
	where B.level=A.level )  '�Y��'
from  CHPUB.OM.UserBase As A 

--15��
--select A.*,B.LevelName from CHPUB.OM.UserBase As A 
--left join CHHRDB01.hrdb.dbo.JOB As B on A.level = B.level
 

