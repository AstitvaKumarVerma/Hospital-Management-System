-----------------------------------------------Patient Table------------------------------------------
create table HmsPatientsTable (
	PatientId int Identity(1,1) Primary Key,
	PatientName varchar(50) Not Null,
	PatientDOB Date Not Null,
	PatientPhone varchar(20) unique Not Null,
	PatientEmail varchar(100) Not Null,
	PatientPassword varchar(20) Not Null,
	Gender varchar(20) Not Null,
	FatherName varchar(50) Not Null,
	MaritalStatus varchar(20) Not Null,
	BloodGroup varchar(20),                       
	Symptoms varchar(256),
	Diagnosis varchar(256),
	IsActive bit default 1,
	IsDeleted bit default 0,
	CreatedBy varchar(50) Not Null,
	CreatedOn DateTime Not Null,
	UpdatedBy varchar(50),
	UpdatedOn DateTime,
	DeletedBy varchar(50),
	DeletedOn DateTime,
)

-----------------------------------------------Doctor Table------------------------------------------
Create table HmsDoctorsTable(
	DoctorId int Identity(1,1) Primary Key,
	DoctorName varchar(50) Not Null,
	DoctorPhone varchar(20) Not Null,
	DoctorDOB Date Not Null,
	DoctorEmail varchar(100) Not Null,
	DoctorPassword varchar(20) Not Null,
	Gender varchar(20) Not Null,
	IsActive bit default 1,
	IsDeleted bit default 0,
	CreatedBy varchar(50) Not Null,
	CreatedOn DateTime Not Null,
	UpdatedBy varchar(50),
	UpdatedOn DateTime,
	DeletedBy varchar(50),
	DeletedOn DateTime,
)

-----------------------------------------Provider Availability Table-----------------------------------
Create table HmsProviderAvailabilityTable(
	Id int Identity(1,1) Primary Key,
	DateAvailable DateTime not null,
	TimeSlots Time Not NUll,
	BookedBy int Foreign Key References HmsPatientsTable(PatientId),
	ProviderId int Foreign Key References HmsDoctorsTable(doctorId),
	IsBooked bit default 0,
)

-----------------------------------------Roles Table-----------------------------------
Create table HmsRolesTable(
	RoleId int Identity(1,1) Primary Key,
	Role varchar(50) Not Null,
)

-----------------------------------------Login Table-----------------------------------
Create table HmsLoginTable(
	UserId int Identity(1,1) Primary Key,
	UserName varchar(50) Not Null,
	UserPhone varchar(20) Not Null Unique,
	UserEmail varchar(100) Not Null Unique,
	UserPassword varchar(20) Not Null,
	PatientId_In_PatientTable int,
	DoctorId_In_DoctorTable int,
	IsActive bit default 1,
	IsDeleted bit default 0,
)

----------------------------------------- User Role Map Table -----------------------------------
create table HmsUserRoleMappingTable(
	UserRoleMapId int Identity(1,1) Primary Key, 
	UserId int Foreign Key References HmsLoginTable(UserId),
	RoleId int Foreign Key References HmsRolesTable(RoleId),
)

----------------------------------------- Chat Table -----------------------------------
CREATE TABLE HmsChatMessagesTable (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SenderId INT,
    RecipientId INT,
    Text NVARCHAR(MAX),
    Timestamp DATETIME
);


----------------------------------------- Select Queries -----------------------------------

Select * From HmsPatientsTable
Select * From HmsProviderAvailabilityTable
Select * From HmsDoctorsTable
Select * From HmsLoginTable
Select * From HmsUserRoleMappingTable
Select * From HmsRolesTable
Select * From HmsChatMessagesTable

update HmsLoginTable set UserPassword='12345678' where PatientId_In_PatientTable = 8
update HmsPatientsTable set PatientPassword='12345678' where PatientId = 8

--------------------------------------------------------------------------------------------------















truncate table HmsPatientsTable
truncate table HmsProviderAvailabilityTable
truncate table HmsDoctorsTable
truncate table HmsLoginTable
truncate table HmsUserRoleMappingTable

----------------------------------------- Drop Table in Sequence Queries -----------------------------------

--Drop table HmsProviderAvailabilityTable
--Drop table HmsPatientsTable
--Drop table HmsDoctorsTable
--Drop table HmsUserRoleMappingTable
--Drop table HmsLoginTable
--Drop table HmsRolesTable

-------------------------------------------------------------------------------------------------



