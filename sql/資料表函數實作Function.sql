-- 0514�w�q��ƪ��Ѽ�
-- �ǤJ�r��M���Φr��
DECLARE @targetStr Varchar(10),
        @splitChar Varchar(1)
-- �]��
SET @targetStr = 'A;B;C;D;E'
SET @splitChar = ';'
--��ƪ��D�餺�e
DECLARE @i int

--�P�_�O�_�Ȧs��ƪ�s�b�A�Y�s�b�N�R���Ȧs����ƪ�
If OBJECT_ID('tempdb.dbo.#ReturnTable','U') is Not null
	drop table #ReturnTable
--�إߦ^��table
CREATE TABLE #ReturnTable(
	Id int,
	SplitStr varchar(5)
)
--�p�ƾ�
Set @i = 1

--�n�[Begin�MEND:�@��while�j�骺�϶�
while(LEN(@targetStr)>1)
Begin
	 --��X
	 Declare @output varchar(5)
	 set @output = SUBSTRING(@targetStr,1,CHARINDEX(@splitChar,@targetStr)-1)
	 --SELECT SUBSTRING(@targetStr,1, CHARINDEX(@splitChar,@targetStr)-1)
	 --�]�w�U�@�Ӧr��
	 SET @targetStr = RIGHT(@targetStr,LEN(@targetStr)-CharIndex(@splitChar,@targetStr))
	 --SELECT LEN(@targetStr)
	 
	INSERT INTO #ReturnTable(Id,SplitStr) values(@i,@output)
	set @i = @i +1
	select LEN(@targetStr)
	--if LEN(@targetStr) <1
	--	set @output = @targetStr
	--BEGIN
	--	INSERT INTO #ReturnTable(Id,SplitStr) values(@i,@output)
	--END
END

 



select * from #ReturnTable

--�P�_�O�_�Ȧs��ƪ�s�b�A�Y�s�b�N�R���Ȧs����ƪ�
If OBJECT_ID('tempdb.dbo.#ReturnTable','U') is Not null
	drop table #ReturnTable




--CHARINDEX �N�ھڿ�J���ƧǳW�h�������ާ@�C
--LTRIM (�r��): �N�Ҧ��r��_�Y���ťղ����C
--RTRIM (�r��): �N�Ҧ��r�굲�����ťղ����C

--select CHARINDEX(@splitChar,@targetStr)
--�p�G�����ȴN�[�J�Ȧs����ƪ�

--while(CHARINDEX(@splitChar,@targetStr)>0)
--	---Insert into #ReturnTable(data)
--	select Str = LTRIM(rtrim(Substring(@targetStr,1,CHARINDEX(@splitChar,@targetStr) -1)))
--	set @targetStr = SUBSTRING(@targetStr,CHARINDEX(@splitChar,@targetStr)+1,LEN(@targetStr))
--	set @i = @i +1


