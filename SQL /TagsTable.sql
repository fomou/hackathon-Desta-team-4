-- Fichier TagsTable.sql
-- insertion de données pour DB Desta

begin TRANSACTION;

CREATE SCHEMA TagsTable;
SET search_path to TagsTable;

INSERT INTO TagType VALUES 
 	(1,'Automotive', 'Descriptive', 20021-11-11 13:23:44),
 	(2, 'Business Services', 'Descriptive', 20021-11-11 13:23:44),
 	(3, 'Computers & Electronics', 'Descriptive', 20021-11-11 13:23:44),
 	(4, 'Construction & Contractors', 'Descriptive', 20021-11-11 13:23:44),
 	(5, 'Education', 'Descriptive', 20021-11-11 13:23:44),
 	(6, 'Entertainment', 'Descriptive', 20021-11-11 13:23:44),
 	(7, 'Food & Dining', 'Descriptive', 20021-11-11 13:23:44),
 	(8, 'Health & Lifestyle', 'Descriptive', 20021-11-11 13:23:44),
 	(9, 'Home & Garden', 'Descriptive', 20021-11-11 13:23:44),
 	(10, 'Legal & Financial', 'Descriptive', 20021-11-11 13:23:44);


INSERT INTO TagPurpose VALUES
	(01, 'Volunteering', 'Interest', 20021-11-11 13:23:44),
	(02, 'Work opportunities', 'Interest', 20021-11-11 13:23:44),	
	(03, 'Community Event', 'Interest', 20021-11-11 13:23:44),
	(04, 'Promotion / Sale', 'Interest', 20021-11-11 13:23:44);


commit;