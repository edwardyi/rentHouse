select B.empName,* from 
FLOWSYS.OM.DefaultSubstitute A left join CHPUB.OM.UserBase B on 
A.fromUserID = B.userID OR
A.toUserID1 = B.userID OR
A.toUserID2 = B.userID OR
A.toUserID3 = B.userID