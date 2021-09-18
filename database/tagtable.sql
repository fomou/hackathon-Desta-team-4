-- Fichier TagsTable.sql
-- insertion de données pour DB Desta

begin TRANSACTION;

CREATE SCHEMA TagsTable;
SET search_path to TagsTable;

INSERT INTO TagType VALUES 
 	(1,'Automotive', 'Descriptive', getdate()),
 	(2, 'Business Services', 'Descriptive', getdate()),
 	(3, 'Computers & Electronics', 'Descriptive', getdate()),
 	(4, 'Construction & Contractors', 'Descriptive', getdate()),
 	(5, 'Education', 'Descriptive', getdate() ),
 	(6, 'Entertainment', 'Descriptive', getdate() ),
 	(7, 'Food & Dining', 'Descriptive', getdate() ),
 	(8, 'Health & Lifestyle', 'Descriptive', getdate() ),
 	(9, 'Home & Garden', 'Descriptive', getdate() ),
 	(10, 'Legal & Financial', 'Descriptive', getdate() );


INSERT INTO TagPurpose VALUES
	(01, 'Volunteering', 'Interest', getdate() ),
	(02, 'Work opportunities', 'Interest', getdate() ),	
	(03, 'Community Event', 'Interest', getdate() ),
	(04, 'Promotion / Sale', 'Interest', getdate() );


commit;