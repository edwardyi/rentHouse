

Select *,B.empName from FLOWSYS.OM.DefaultSubstitute As A 
inner join CHPUB.OM.UserBase As B on A.fromUserID = B.userID

--�t�@�ؼg�k
--Select *,(select empName from CHPUB.OM.UserBase As B where A.fromUserID=B.userID) from 
--FLOWSYS.OM.DefaultSubstitute As A

