
--		Table : dbo.Movies	

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Movies') AND type in (N'U'))
	Begin
		DROP TABLE dbo.Movies
	End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Movies
(
	MovieId bigint Identity(1,1) NOT NULL ,
	ReleaseDate Date NOT NULL,
	Duration Time(0) NOT NULL,
	--Genere varchar(30) null , -- additional properties ignored.
	--Rating varchar(30) null ,
	DateAdded Datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
	CONSTRAINT PK_Movies PRIMARY KEY (MovieId)
) 
GO

--		Table : dbo.Titles

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Titles') AND type in (N'U'))
	Begin
		DROP TABLE dbo.Titles
	End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Titles
(
	TitleId bigint Identity(1,1) NOT NULL ,
	MovieId bigint NOT NULL ,
	[Language] Varchar(10) NOT NULL,	
	Title nVarchar(1000) NOT NULL,	
	[Description] nVarchar(max) NULL,
	DateAdded Datetime2 NOT NULL DEFAULT SYSUTCDATETIME(),
	CONSTRAINT PK_Titles PRIMARY KEY (TitleId)
) 
GO

--		Table : dbo.Watched

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.Watched') AND type in (N'U'))
	Begin
		DROP TABLE dbo.Watched
	End
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Watched
(
	TitleId bigint Identity(1,1) NOT NULL ,
	StartedAt  Datetime NOT NULL DEFAULT GetDate(),
	StoppedAt  Datetime NULL ,
	CONSTRAINT PK_Watched PRIMARY KEY (TitleId)
) 
GO


select getdate() - getdate() as Duration 