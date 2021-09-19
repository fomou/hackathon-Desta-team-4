-- Fichier TagsTable.sql
-- insertion de données pour DB Desta

begin TRANSACTION;

INSERT INTO [DestaNationConnect].[dbo].[TagType]  (Name, Description, CreationDate) VALUES 
	('Why', 'description de what is a tag of type WHY', getdate() ),
	('What', 'description de what is a tag of WHAT', getdate() );

INSERT INTO [DestaNationConnect].[dbo].TagPurpose (Name, Description, CreationDate) VALUES
	('Interest', 'description de what is a tag of type Interest', getdate() ),
	('Descriptive', 'description de what is a tag of Descriptive', getdate() );

INSERT INTO [DestaNationConnect].[dbo].Tag (TagTypeId, AuthorId, Name, Description, CreationDate)  VALUES 
	(1, NULL, 'Volunteering', 'Interest WHY tag about .......', getdate() ),
	(1, NULL, 'Work opportunities', 'Interest WHY tag about .......', getdate() ),	
	(1, NULL, 'Community Event', 'Interest WHY tag about .......', getdate() ),
	(1, NULL, 'Promotion / Sale', 'Interest WHY tag about .......', getdate() ),
 	(2, NULL, 'Automotive', 'Descriptive WHAT tag about ...', getdate()),
 	(2, NULL, 'Business Services', 'Descriptive WHAT tag about ...', getdate()),
 	(2, NULL, 'Computers & Electronics', 'Descriptive WHAT tag about ...', getdate()),
 	(2, NULL, 'Construction & Contractors', 'Descriptive WHAT tag about ...', getdate()),
 	(2, NULL, 'Education', 'Descriptive WHAT tag about ...', getdate() ),
 	(2, NULL, 'Entertainment', 'Descriptive WHAT tag about ...', getdate() ),
 	(2, NULL, 'Food & Dining', 'Descriptive WHAT tag about ...', getdate() ),
 	(2, NULL, 'Health & Lifestyle', 'Descriptive WHAT tag about ...', getdate() ),
 	(2, NULL, 'Home & Garden', 'Descriptive WHAT tag about ...', getdate() ),
 	(2, NULL, 'Legal & Financial', 'Descriptive WHAT tag about ...', getdate() );

commit;

/*
DECLARE @sql NVARCHAR(max)=''

SELECT @sql += ' Drop table ' + QUOTENAME(TABLE_SCHEMA) + '.'+ QUOTENAME(TABLE_NAME) + '; '
FROM   INFORMATION_SCHEMA.TABLES
WHERE  TABLE_TYPE = 'BASE TABLE'

Exec Sp_executesql @sql


Drop table [dbo].[TagType]
Drop table [dbo].[Post]
Drop table [dbo].[PostTag]
Drop table [dbo].[Business]
Drop table [dbo].[OAuthProvider]
Drop table [dbo].[User]
*/