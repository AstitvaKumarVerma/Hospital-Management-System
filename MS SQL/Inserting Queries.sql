---------------------------- Here Inserting in HmsPatientsTable --------------------------------------

Insert Into HmsPatientsTable(PatientName,PatientDOB,PatientPhone,PatientEmail,PatientPassword,Gender,FatherName,MaritalStatus,BloodGroup,CreatedBy,CreatedOn) 
values('Satyam Singh','2000-02-28','7037192194','satyamsinghindia8@gmail.com','satyam123','Male','XYZ Singh','Single','B+','Satyam Singh',getdate())

Insert Into HmsPatientsTable(PatientName,PatientDOB,PatientPhone,PatientEmail,PatientPassword,Gender,FatherName,MaritalStatus,BloodGroup,CreatedBy,CreatedOn) 
values('Prince Malik','2001-10-27','8077300493','ytoffical2234@gmail.com','prince123','Male','Abc Malik','Single','A+','Prince Malik',getdate())

Insert Into HmsPatientsTable(PatientName,PatientDOB,PatientPhone,PatientEmail,PatientPassword,Gender,FatherName,MaritalStatus,BloodGroup,CreatedBy,CreatedOn) 
values('Preeti Shukla','2000-08-30','7819860668','preeti78198606@gmail.com','preeti123','Female','Zef Shukla','Single','AB+','Preeti Shukla',getdate())

Insert Into HmsPatientsTable(PatientName,PatientDOB,PatientPhone,PatientEmail,PatientPassword,Gender,FatherName,MaritalStatus,BloodGroup,CreatedBy,CreatedOn) 
values('Sakshi Bisht','2002-01-23','9520207542','sakshibisht72@gmail.com','sakshi123','Female','Asd Bisht','Single','A+','Sakshi Bisht',getdate())


Select * From HmsPatientsTable

---------------------------- Here Inserting in HmsDoctorsTable --------------------------------------

Insert Into HmsDoctorsTable(DoctorName,DoctorPhone,DoctorDOB,DoctorEmail,DoctorPassword,Gender,CreatedBy,CreatedOn) values('Dr. Ajaya Nand','7894561230','1980-03-29','ajayanand@gmail.com','ajay123','Male','Admin',GetDate())
Insert Into HmsDoctorsTable(DoctorName,DoctorPhone,DoctorDOB,DoctorEmail,DoctorPassword,Gender,CreatedBy,CreatedOn) values('Dr. Suresh Joshi','6123078945','1970-07-15','sureshjoshi@gmail.com','suresh123','Male','Admin',GetDate())
Insert Into HmsDoctorsTable(DoctorName,DoctorPhone,DoctorDOB,DoctorEmail,DoctorPassword,Gender,CreatedBy,CreatedOn) values('Dr. Abhijit Dey','7893045612','1965-10-05','abhijitdey@gmail.com','abhijit123','Male','Admin',GetDate())
Insert Into HmsDoctorsTable(DoctorName,DoctorPhone,DoctorDOB,DoctorEmail,DoctorPassword,Gender,CreatedBy,CreatedOn) values('Dr. Aroop Mukherjee','6145678945','1985-05-26','aroopM@gmail.com','aroop123','Male','Admin',GetDate())
Insert Into HmsDoctorsTable(DoctorName,DoctorPhone,DoctorDOB,DoctorEmail,DoctorPassword,Gender,CreatedBy,CreatedOn) values('Dr. Shiong','7893234612','1977-12-20','shiong@gmail.com','shiong123','Male','Admin',GetDate())

Select * From HmsDoctorsTable

---------------------------- Here Inserting in HmsRolesTable --------------------------------------

Insert Into HmsRolesTable values('Admin');
Insert Into HmsRolesTable values('Provider');
Insert Into HmsRolesTable values('Patient');

Select * From HmsRolesTable


---------------------------- Here Inserting in HmsLoginTable with RoleMapping --------------------------------------

Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword) values('Admin','5885412345','admin@gmail.com','admin');
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,PatientId_In_PatientTable) values('Satyam Singh','7037192194','satyamsinghindia8@gmail.com','satyam123',1);
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,PatientId_In_PatientTable) values('Prince Malik','8077300493','ytoffical2234@gmail.com','prince123',2);
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,PatientId_In_PatientTable) values('Preeti Shukla','7819860668','preeti78198606@gmail.com','preeti123',3);
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,PatientId_In_PatientTable) values('Sakshi Bisht','9520207542','sakshibisht72@gmail.com','sakshi123',4);
Insert Into HmsUserRoleMappingTable values(1,1)
Insert Into HmsUserRoleMappingTable values(2,3)
Insert Into HmsUserRoleMappingTable values(3,3)
Insert Into HmsUserRoleMappingTable values(4,3)
Insert Into HmsUserRoleMappingTable values(5,3)

Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,DoctorId_In_DoctorTable) values('Dr. Ajaya Nand','7894561230','ajayanand@gmail.com','ajay123',1);
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,DoctorId_In_DoctorTable) values('Dr. Suresh Joshi','6123078945','sureshjoshi@gmail.com','suresh123',2);
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,DoctorId_In_DoctorTable) values('Dr. Abhijit Dey','7893045612','abhijitdey@gmail.com','abhijit123',3);
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,DoctorId_In_DoctorTable) values('Dr. Aroop Mukherjee','6145678945','aroopM@gmail.com','aroop123',4);
Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,DoctorId_In_DoctorTable) values('Dr. Shiong','7893234612','shiong@gmail.com','shiong123',5);
Insert Into HmsUserRoleMappingTable values(6,2)
Insert Into HmsUserRoleMappingTable values(7,2)
Insert Into HmsUserRoleMappingTable values(8,2)
Insert Into HmsUserRoleMappingTable values(9,2)
Insert Into HmsUserRoleMappingTable values(10,2) 


Select * From HmsPatientsTable
Select * From HmsLoginTable
select * From HmsUserRoleMappingTable

----------------------------------------------------------------------------------------------------------------------------------

update HmsProviderAvailabilityTable set BookedBy=12 where Id = 5
update HmsProviderAvailabilityTable set IsBooked=1 where Id = 5

select * from HmsProviderAvailabilityTable
truncate table HmsProviderAvailabilityTable 

----------------------------------------------------------------------------------------------------------------------------------

update HmsPatientsTable set IsActive=1 where PatientId = 4
update HmsPatientsTable set IsDeleted=0 where PatientId = 4

update HmsLoginTable set IsActive=1 where PatientId_In_PatientTable = 4
update HmsLoginTable set IsDeleted=0 where PatientId_In_PatientTable = 4

----------------------------------------------------------------------------------------------------------------------------------


update HmsDoctorsTable set IsActive=1 where DoctorId = 2
update HmsDoctorsTable set IsDeleted=0 where DoctorId = 2

update HmsLoginTable set IsActive=1 where DoctorId_In_DoctorTable = 2
update HmsLoginTable set IsDeleted=0 where DoctorId_In_DoctorTable = 2

----------------------------------------------------------------------------------------------------------------------------------

update HmsPatientsTable Set PatientEmail='sakshibisht72@gmail.com' where PatientId=4
update HmsPatientsTable Set BloodGroup='O+' where PatientId=4

----------------------------------------------------------------------------------------------------------------------------------

--delete HmsPatientsTable where PatientId =6
