USE [master]
GO

CREATE DATABASE SWC_LMS;
GO

USE SWC_LMS;
GO

CREATE LOGIN lmsapp WITH Password = 'abc123';
CREATE USER lmsapp for LOGIN lmsapp;

-- your user and role tables will be generated by the ASP.NET Identity
-- any table that references "UserId" will be pointed at the User table
-- that is automatically generated, create your aspnet identity tables 
-- before running this part of the script!

CREATE TABLE Class (
	ClassId int identity(1,1) not null primary key,
	UserId nvarchar(128) not null foreign key references AspNetUsers(Id), -- instructor
	Name varchar(50) not null,
	GradeLevel tinyint not null,
	IsArchived bit not null default(0),
	[Subject] varchar(50) not null,
	StartDate date not null,
	EndDate date not null,
	[Description] varchar(255) null
)
GO

CREATE TABLE Roster(
	RosterId int identity(1,1) not null primary key,
	ClassId int not null foreign key references Class(ClassId),
	UserId nvarchar(128) not null foreign key references AspNetUsers(Id),
	IsDeleted bit not null default(0)
)
GO

CREATE TABLE Assignment(
	AssignmentId int identity(1,1) not null primary key,
	ClassId int not null foreign key references Class(ClassId),
	Name varchar(50) not null,
	PossiblePoints int not null,
	DueDate date not null,
	[Description] varchar(255)
)
GO

CREATE TABLE Grade(
	RosterId int not null,
	AssignmentId int not null,
	Points int null,
	Score decimal(5,2) null,
	primary key (RosterId, AssignmentId)
)
GO

CREATE TABLE Parents(
	ParentId nvarchar(128) not null foreign key references AspNetUsers(Id),
	ChildId nvarchar(128) not null foreign key references AspNetUsers(Id)
	primary key (ParentId, ChildId)
)
GO