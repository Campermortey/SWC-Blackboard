Create Database LMS
go
use master;
Drop Database LMS  --wont let me drop database in same script as creating database?
go

Create Database LMS
go

use LMS
go

create table Student(
StudentId int identity(1,1) not null primary key, --is there a way to set this equal to userIDs with role mapping to student?
UserId varchar(128) not null foreign key (aspnetusers.Id), -- how do i set this as fk if user table does not yet exist?
FirstName varchar (20) not null,
LastName varchar (50),
Email varchar(40),
GradeLevel varchar(5),
--GPA decimal(4,3), Don't need this
)

create table Guardian(
GuardianId int identity(1,1) not null primary key, --or find some way to set this equal to userIDs with guardian/parent role.
UserId varchar(128) not null foreign key (aspnetusers.Id),
FirstName varchar (20) not null,
LastName varchar (50) not null,
Email varchar (40)
)

create table StudentGuardian
(GuardianId int Not Null,
StudentId int Not Null,
Constraint PK_StudentGuardian Primary Key(StudentId, GuardianId),

Constraint FK_StudentGuardian_Guardian Foreign Key (GuardianId)
References Guardian (GuardianId),

Constraint FK_StudentGuardian_Student Foreign Key (StudentId)
References Student (StudentId)
)

create table Teacher
(TeacherId int identity(1,1) not null primary key, 
UserId varchar(128) not null foreign key (aspnetusers.Id), -- once we have a User Table will set this as foreign key
FirstName varchar (20),
LastName varchar (50),
Email varchar(40),
--HireDate date,  --don't think we need these last two for now
--isTenured bit) -- ''
)

create table Department
( DepartmentId int identity(1,1) not null primary key,
DepartmentName varchar(20)
)

create table Course --naming course instead of class to avoid reserved word work arounds in C#
(CourseId int identity (1,1) not null primary key,
CourseName varchar (40) not null,
DepartmentId int not null,
Detail varchar(141), --avoiding reserved word Description
GradeLevel smallint,
Constraint FK_Course_Department Foreign Key (DepartmentId)
References Department (DepartmentID)
)

create table Section --this is a CourseTeacher bridge table
(SectionId int identity (1,1) not null primary key,
TeacherId int not null,
CourseId int not null,
Period int not null,
Room varchar(10),
Start date,  -- thinking start/finish combo can stand in for isArchived bit. discuss w/ Eric in terms of effect on performance
Finish date,
Constraint FK_Section_Teacher Foreign Key (TeacherId)
References Teacher (TeacherId),
Constraint FK_Section_Course Foreign Key (CourseId)
References Course (CourseId)
)

create table StudentSection --Class Roster and Student Schedule falls out from this table
(SectionId int not null,
StudentId int not null,
CumulativeGrade int, --hmmm, how is grade calculated... do we show a letter or a percentage?
Constraint PK_StudentSection Primary Key(SectionId, StudentId),
Constraint FK_StudentSection_Section Foreign Key (SectionId)
References Section (SectionId),
Constraint FK_StudentSection_Student Foreign Key (StudentId)
References Student (StudentId)
)

Create table AssignmentType
(AssignmentTypeId int identity (1,1) not null primary key,
Title varchar(25) not null,
TotalPoints int not null
)


Create table Assignment --cant decide if keep it simple and homework/quizzes/tests/essays are differentiated by Title given, or if want additional table and change this to assignment type. I don't think we want to standardize # of points per type of assignment so would just be list of names of possible gradebook entries.
(AssignmentId int identity (1,1) not null primary key,
SectionId int not null,  -- references courseID instead of section to reduce work for teachers teaching more than one section -will autopopulate multiple gradebooks- but reduces customization between classes. Ask Becky's opinion on this.
AssignmentTypeId int not null,
Title varchar (12),
Points int,
Detail varchar(141),
DueDate Date,
Constraint FK_Assignment_Section Foreign Key (SectionId)
References Section (SectionId),
Constraint FK_Assignment_AssignmentType Foreign Key (AssignmentTypeId)
References AssignmentType (AssignmentTypeId)
)

Create table GradebookEntry --Gradebook Entry/AssignmentScore
(AssignmentId int not null,
SectionId int not null,
StudentId int not null,
Score int,
Constraint PK_GradebookEntry Primary Key (AssignmentId, SectionId, StudentId),
Constraint FK_GradebookEntry_Assignment Foreign Key (AssignmentId)
References Assignment (AssignmentId),
Constraint FK_GradebookEntry_Section Foreign Key (SectionId)
References Section (SectionId),
Constraint FK_GradebookEntry_Student Foreign Key (StudentId)
References Student (StudentId)
)




