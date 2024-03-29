/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Lavoratori
	(
	ID uniqueidentifier NOT NULL,
	Nome nvarchar(255) NULL,
	Cognome nvarchar(255) NULL,
	DataDiNascita datetime NULL,
	Tipo int NULL,
	Retribuzione float(53) NULL,
	DataDiAssunzione datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Lavoratori ADD CONSTRAINT
	PK_Lavoratori PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Lavoratori SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
