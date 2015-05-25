;WITH findFather(muNodeID,muParentId,sText,sValue,programDes,sysID,menuGroup,level,ColOrder)
AS(
	SELECT muNodeID,muParentId,sText,sValue,programDes,sysID,menuGroup,0,CONVERT(VARCHAR,muNodeID)
	FROM CHPUB.BM.MainMenu
	WHERE muParentId = 0
	UNION ALL
	SELECT A.muNodeID,
	       A.muParentId,
	       A.sText,
	       A.sValue,
	       A.programDes,
	       A.sysID,
	       A.menuGroup,
	       level+1,
	       CONVERT(VARCHAR,B.ColOrder +'-'+CONVERT(VARCHAR,A.muNodeID))
	FROM CHPUB.BM.MainMenu A,findFather B
	WHERE A.muParentId = B.muNodeID 
	
)
SELECT REPLICATE('   ',level)+sText,sValue,programDes,sysID,menuGroup,level FROM findFather
ORDER BY ColOrder
--SELECT * FROM CHPUB.BM.MainMenu
