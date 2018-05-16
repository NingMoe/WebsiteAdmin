IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ReadCount]
@tableName nvarchar(2000),
@condition nvarchar(2000) -- 查询条件 (注意: 不要加 where) 
AS 
	DECLARE @strSQL  nvarchar(4000) 
        --查询总数
	IF @condition ='''' 
		SET @strSQL = ''SELECT COUNT(*) FROM ''+ @tableName 	
	ELSE 
		SET @strSQL = ''SELECT COUNT(*) FROM ''+ @tableName +'' WHERE ''+@condition 
	EXEC (@strSQL)
' 
END


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadPageList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ReadPageList]
@tableName varchar(2000),--多表的话用  Table1 Inner JOIN Table2 ON Table1.Field=Table2.Field
@fields varchar(2000),
@pageSize int, 
@currentPage int,   
@fieldName nvarchar(50), 
@orderType bit,  -- 设置排序类型, 0降序  1升序
@condition varchar(max) -- 查询条件 (注意: 不要加 where) 
AS 
	DECLARE @strSQL varchar(max) 
	DECLARE @strTmp varchar(110)
	DECLARE @strOrder varchar(400) 
	DECLARE @whereCondition varchar(max)
	DECLARE @andCondition varchar(max)
	--条件处理
	IF @condition=''''
		BEGIN
			SET @whereCondition=''''
			SET @andCondition=''''
		END
	ELSE
		BEGIN
			SET @whereCondition='' WHERE ''+@condition
			SET @andCondition='' AND ''+@condition
		END
		
	--多表连接字段处理
	DECLARE @noPrefixFieldName nvarchar(50)
    IF CHARINDEX(''.'',@fieldName)>0
		SET @noPrefixFieldName=SUBSTRING(@fieldName,CHARINDEX(''.'',@fieldName)+1,LEN(@fieldName))
	ELSE
		SET @noPrefixFieldName=@fieldName
	--排序处理
	IF @orderType = 0 
		BEGIN 
			SET @strTmp = ''< (SELECT MIN'' 
			SET @strOrder = '' ORDER BY '' + REPLACE(@fieldName,'','','' DESC ,'') +'' DESC''
		END 
	ELSE 
		BEGIN 
			SET @strTmp = ''> (SELECT MAX''
			SET @strOrder = '' ORDER BY '' + REPLACE(@fieldName,'','','' ASC ,'') +'' ASC''
		END 
	--分页	
	IF CHARINDEX('','',@fieldName)=0
		BEGIN		
			IF @currentPage = 1 
				SET @strSQL = ''SELECT TOP '' + CAST(@pageSize AS nvarchar(10)) +'' ''+@fields+ '' FROM '' +@tableName + @whereCondition + '' '' + @strOrder 

			ELSE 
				SET @strSQL = ''SELECT TOP '' + CAST(@pageSize AS nvarchar(10)) +'' ''+@fields+ '' FROM ''+ @tableName + '' WHERE '' + @fieldName + @strTmp + ''('' + @noPrefixFieldName + '') FROM (SELECT TOP '' + CAST((@currentPage-1)*@pageSize AS nvarchar(10)) +'' ''+ @fieldName + '' FROM '' + @tableName + @whereCondition+ @strOrder + '') AS tblTmp) '' + @andCondition + '' '' + @strOrder 
		END
	ELSE
		BEGIN
			IF @currentPage = 1 
				SET @strSQL = ''SELECT TOP '' + CAST(@pageSize AS nvarchar(10)) +'' ''+@fields+ '' FROM '' +@tableName + @whereCondition + @strOrder
			ELSE 
				SET @strSQL = ''SELECT ''+@fields + '' FROM (SELECT ROW_NUMBER() OVER(''+@strOrder+'' ) AS [RowID],''+@fields+'' FROM(SELECT ''+@fields+'' FROM ''+@tableName+@whereCondition+'' ) AS TEMP1)AS TEMP WHERE [RowID] BETWEEN ''+CAST((@currentPage-1)*@pageSize+1 AS nvarchar(10))+'' AND ''+CAST(@currentPage*@pageSize AS nvarchar(10))
		END
	EXEC (@strSQL)
' 
END


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddUserFriend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[AddUserFriend]
@friendID int,
@friendName nvarchar(50),
@userID int,
@userName nvarchar(50)
AS 
	INSERT INTO UserFriend([FriendID],[FriendName],[UserID],[UserName]) VALUES(@friendID,@friendName,@userID,@userName)
	SELECT @@identity
' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteUserFriend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[DeleteUserFriend]
@strID nvarchar(800),
@userID int
AS 
	IF @strID=''''
		RETURN	
	IF @userID=0
		EXEC (''DELETE FROM UserFriend WHERE [ID] IN(''+@strID+'')'')
	ELSE
		EXEC (''DELETE FROM UserFriend WHERE [ID] IN(''+@strID+'') AND [UserID]=''+@userID)
' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadUserFriend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ReadUserFriend]
@id int,
@userID int
AS 
	IF @userID=0
		SELECT [ID],[FriendID],[FriendName],[UserID],[UserName] FROM UserFriend WHERE [ID]=@id
	ELSE
		SELECT [ID],[FriendID],[FriendName],[UserID],[UserName] FROM UserFriend WHERE [ID]=@id AND [UserID]=@userID
' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadUserFriendByFriendID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ReadUserFriendByFriendID]
@friendID int,
@userID int
AS 
	IF @userID=0
		SELECT [ID],[FriendID],[FriendName],[UserID],[UserName] FROM UserFriend WHERE [FriendID]=@friendID
	ELSE
		SELECT [ID],[FriendID],[FriendName],[UserID],[UserName] FROM UserFriend WHERE [FriendID]=@friendID AND [UserID]=@userID

' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadUserFriendIDList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ReadUserFriendIDList]
@strID nvarchar(400),
@userID int
AS
	IF @strID=''''
		RETURN	
	EXEC(''SELECT [ID] FROM UserFriend WHERE [ID] IN(''+@strID+'') AND [UserID]=''+@userID)
' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchUserFriendList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchUserFriendList]
@condition nvarchar(4000)
AS 
	IF @condition=''''
		SELECT [ID],[FriendID],[FriendName],[UserID],[UserName] FROM UserFriend 
	ELSE
		EXEC(''SELECT [ID],[FriendID],[FriendName],[UserID],[UserName] FROM UserFriend WHERE ''+ @condition)

' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateUserFriend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[UpdateUserFriend]
@id int,
@friendName nvarchar(50)
AS 
	UPDATE UserFriend Set [FriendName]=@friendName WHERE [ID]=@id
' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteMenu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DeleteMenu]
@id int
AS 
	 DECLARE @temp int
	 SELECT @temp=COUNT(*) FROM Menu WHERE [FatherID]=@id 
	 IF @temp=0
	 	DELETE FROM Menu WHERE [ID]=@id
		
' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoveDownMenu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[MoveDownMenu]
@id int
AS 
	DECLARE @tempID int
	DECLARE @tempOrderID int
	DECLARE @orderID int
	DECLARE @fatherID int
	SELECT @orderID=[OrderID],@fatherID=[FatherID] FROM Menu WHERE [ID]=@id
	SELECT TOP 1 @tempID=[ID],@tempOrderID=[OrderID] FROM Menu WHERE [OrderID]>@orderID AND [FatherID]=@fatherID ORDER BY [OrderID] ASC

	IF @tempID is null
		RETURN		
	ELSE
		BEGIN
		UPDATE Menu SET [OrderID]=@tempOrderID WHERE [ID]=@id
		UPDATE Menu SET [OrderID]=@orderID WHERE [ID]=@tempID
		END
' 
END





IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoveUpMenu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[MoveUpMenu]
@id int
AS 
	DECLARE @tempID int
	DECLARE @tempOrderID int
	DECLARE @orderID int
	DECLARE @fatherID int
	SELECT @orderID=[OrderID],@fatherID=[FatherID] FROM Menu WHERE [ID]=@id
	SELECT TOP 1 @tempID=[ID],@tempOrderID=[OrderID] FROM Menu WHERE [OrderID]<@orderID AND [FatherID]=@fatherID ORDER BY [OrderID] DESC

	IF @tempID is null
		RETURN		
	ELSE
		BEGIN
		UPDATE Menu SET [OrderID]=@tempOrderID WHERE [ID]=@id
		UPDATE Menu SET [OrderID]=@orderID WHERE [ID]=@tempID
		END
' 
END





IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadMenuAllList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ReadMenuAllList]
AS
	SELECT [ID],[FatherID],[OrderID],[MenuName],[MenuImage],[URL],[Date],[IP] FROM Menu ORDER BY [OrderID] ASC,ID ASC
' 
END





IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateMenu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[UpdateMenu]
@id int,
@fatherID int,
@orderID int,
@menuName nvarchar(50),
@menuImage int,
@uRL nvarchar(50)
AS 
	UPDATE Menu Set [FatherID]=@fatherID,[OrderID]=@orderID,[MenuName]=@menuName,[MenuImage]=@menuImage,[URL]=@uRL WHERE [ID]=@id
' 
END





IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddMenu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[AddMenu]
@fatherID int,
@orderID int,
@menuName nvarchar(50),
@menuImage int,
@uRL nvarchar(50),
@date datetime,
@iP nvarchar(50)
AS 
	INSERT INTO Menu([FatherID],[OrderID],[MenuName],[MenuImage],[URL],[Date],[IP]) VALUES(@fatherID,@orderID,@menuName,@menuImage,@uRL,@date,@iP)	
		SELECT @@identity
' 
END


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadArticleClassAllList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ReadArticleClassAllList]
AS
	SELECT [ID],[FatherID],[OrderID],[ClassName],[Description],[IsSystem] FROM ArticleClass ORDER BY [OrderID] ASC,ID ASC
' 
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteArticle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[DeleteArticle]
@strID nvarchar(800)
AS 
	IF @strID=''''
		RETURN	
	EXEC (''DELETE FROM Article WHERE [ID] IN(''+@strID+'')'')
' 
END


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadArticleListByArticleID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReadArticleListByArticleID]
@strArticleID NVARCHAR(200)
AS
EXEC(''SELECT  [ID],[Title]  FROM  [Article] WHERE [ID] IN(''+@strArticleID+'')'')
' 
END


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateArticle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[UpdateArticle]
@id int,
@title nvarchar(200),
@classID nvarchar(100),
@isTop int,
@author nvarchar(50),
@resource nvarchar(50),
@keywords nvarchar(100),
@url nvarchar(200),
@photo nvarchar(100),
@summary ntext,
@content ntext
AS 
	UPDATE Article Set [Title]=@title,[ClassID]=@classID,[IsTop]=@isTop,[Author]=@author,[Resource]=@resource,[Keywords]=@keywords,[Url]=@url,[Photo]=@photo,[Summary]=@summary,[Content]=@content WHERE [ID]=@id
' 
END


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddArticle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[AddArticle]
@title nvarchar(200),
@classID nvarchar(100),
@isTop int,
@author nvarchar(50),
@resource nvarchar(50),
@keywords nvarchar(100),
@url nvarchar(200),
@photo nvarchar(100),
@summary ntext,
@content ntext,
@date datetime
AS 
	INSERT INTO Article([Title],[ClassID],[IsTop],[Author],[Resource],[Keywords],[Url],[Photo],[Summary],[Content],[Date]) VALUES(@title,@classID,@isTop,@author,@resource,@keywords,@url,@photo,@summary,@content,@date)
	SELECT @@identity
' 
END


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchArticleList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchArticleList]
@condition nvarchar(4000)
AS 
	IF @condition=''''
		SELECT [ID],[Title],[ClassID],[IsTop],[Author],[Resource],[Keywords],[Url],[Photo],[Summary],[Content],[Date] FROM Article 
	ELSE
		EXEC(''SELECT [ID],[Title],[ClassID],[IsTop],[Author],[Resource],[Keywords],[Url],[Photo],[Summary],[Content],[Date] FROM Article WHERE ''+ @condition)

' 
END





IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadArticle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ReadArticle]
@id int
AS 
	SELECT [ID],[Title],[ClassID],[IsTop],[Author],[Resource],[Keywords],[Url],[Photo],[Summary],[Content],[Date] FROM Article WHERE [ID]=@id
' 
END