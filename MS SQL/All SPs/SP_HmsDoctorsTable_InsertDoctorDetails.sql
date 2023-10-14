ALTER PROCEDURE SP_HmsDoctorsTable_InsertDoctorDetails
(
    @DoctorName varchar(50),    @DoctorDOB Date,               @DoctorPhone varchar(20),
    @DoctorEmail varchar(100),  @DoctorPassword varchar(20),   @Gender varchar(20)
)
AS
BEGIN
    -- Insert data into the HmsDoctorsTable
    INSERT INTO HmsDoctorsTable
    (
        DoctorName,  DoctorDOB,  DoctorPhone,  DoctorEmail,  DoctorPassword,  Gender,  CreatedBy, CreatedOn
    )
    VALUES
    (
        @DoctorName, @DoctorDOB, @DoctorPhone, @DoctorEmail, @DoctorPassword, @Gender, 'Admin',    GETDATE()
    )

    SELECT SCOPE_IDENTITY() AS DoctorId

    Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,DoctorId_In_DoctorTable) values 
	(@DoctorName, @DoctorPhone, @DoctorEmail, @DoctorPassword, SCOPE_IDENTITY())
	
	Select SCOPE_IDENTITY() AS UserId

	Insert Into HmsUserRoleMappingTable(UserId, RoleId) Values (SCOPE_IDENTITY(), 2)
END
