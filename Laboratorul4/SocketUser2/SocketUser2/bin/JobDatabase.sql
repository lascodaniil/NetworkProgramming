
IF DB_ID('StudentsJobDb') IS NOT NULL 
BEGIN
	DROP DATABASE StudentsJobDB;
END
GO

GO
CREATE DATABASE StudentsJobDB
GO

USE [StudentsJobDB]

IF OBJECT_ID(N'Student',N'U') IS NOT NULL
	DROP TABLE Student
ELSE
	CREATE TABLE Student
	(
		Id BIGINT  IDENTITY(1,1) NOT NULL UNIQUE,
		FirstName NVARCHAR(255) NOT NULL,
		LastName NVARCHAR(255)NOT NULL,
		Email NVARCHAR(255) NOT NULL UNIQUE, 
		University NVARCHAR(255) NOT NULL UNIQUE,
		BirthDate DATETIME2 NOT NULL,
		RegisterDate DATETIME2 DEFAULT GETDATE(),
		PRIMARY KEY (Id)
	);	

IF OBJECT_ID(N'Author',N'U') IS NOT NULL
	DROP TABLE Author
ELSE
CREATE TABLE Author
	(
		Id BIGINT IDENTITY (1,1) NOT NULL,
		FirstName NVARCHAR (255) NOT NULL,
		LastName NVARCHAR(255) NOT NULL,
		City NVARCHAR(255) NOT NULL,
		Contact NVARCHAR(255) NOT NULL,
		PhoneNumber NVARCHAR(255) NOT NULL
		PRIMARY KEY(Id)
	);

IF OBJECT_ID(N'Job',N'U') IS NOT NULL
	DROP TABLE Job
ELSE
CREATE TABLE Job
	(
		Id BIGINT IDENTITY (1,1) NOT NULL,
		AuthorId BIGINT NOT NULL,
		Title NVARCHAR(255) NOT NULL,
		City NVARCHAR(255) NOT NULL,
		Contact NVARCHAR(255) NOT NULL,
		PostDate DATETIME ,
		EndDate DATETIME ,
		PRIMARY KEY(Id),
		FOREIGN KEY(AuthorId) REFERENCES [Author](Id) ON DELETE CASCADE
	);

IF OBJECT_ID(N'StudentJob',N'U') IS NOT NULL
	DROP TABLE StudentJob
ELSE
CREATE TABLE StudentJob
	(
		Id BIGINT IDENTITY (1,1) NOT NULL,
		StudentId BIGINT NOT NULL,
		JobId BIGINT NOT NULL,
		PRIMARY KEY(Id),
		FOREIGN KEY(StudentId) REFERENCES [Student](Id) ON DELETE CASCADE,
		FOREIGN KEY(JobId) REFERENCES [Job](Id) ON DELETE CASCADE,
	);
                                                                                                                                                                                                                                                                                                                                                                                                             