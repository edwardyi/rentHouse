
--cast�g�k:�N�쥻�ƭ�����������ର�r���X
Declare @s varchar(50)
set @s = '' --�S����l�ƴN�|�X�{Null����
SELECT  @s = @s + cast(muNodeID As varchar(10))+';'  FROM CHPUB.BM.MainMenu WHERE muParentId = 410
select @s


--�w�q��X�r��(cursor�g�k) =>�S���g���\
Declare @output varchar(10),
	@row varchar(5)

DECLARE cursorTest CURSOR
For SELECT  muNodeID  FROM CHPUB.BM.MainMenu WHERE muParentId = 410
--�[�J�O����
OPEN cursorTest
FETCH NEXT FROM cursorTest INTO @row
	WHILE(@@FETCH_STATUS =0)
	Begin
		--Print @row
		set @output =  @row +  ';' + @output 
		Fetch next from cursorTest into @output
	END

	--WHILE (@@FETCH_STATUS <> -1)
	--BEGIN
	--	If (@@FETCH_STATUS <> -2)
	--	Begin
	--		set @output = @output + ';' + @row 
	--		--Print @row
	--	End
	--	Fetch next from cursorTest into @output
		
	--		--SET @output = @output + @row  +';'
	--END
--��������O����
CLOSE cursorTest
DEALLOCATE cursorTest 

--�p�G���ȴN���
If @output <> ''
BEGIN
	Select @output
END




--@@FETCH_STATUS
--The FETCH statement was successful.
--The FETCH statement failed or the row was beyond the result set.
--The row fetched is missing.
