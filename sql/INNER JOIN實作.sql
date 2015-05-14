

Select *,B.empName from FLOWSYS.OM.DefaultSubstitute As A 
inner join CHPUB.OM.UserBase As B on A.fromUserID = B.userID

--另一種寫法
--Select *,(select empName from CHPUB.OM.UserBase As B where A.fromUserID=B.userID) from 
--FLOWSYS.OM.DefaultSubstitute As A

