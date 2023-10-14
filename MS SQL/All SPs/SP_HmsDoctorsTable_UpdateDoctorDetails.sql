CREATE PROCEDURE SP_HmsDoctorsTable_UpdateDoctorDetails
(
    @DoctorId int,              @DoctorName varchar(50),     @DoctorDOB Date,    
	@DoctorPhone varchar(20),   @DoctorEmail varchar(100),   @DoctorPassword varchar(20), 
	@Gender varchar(20)
)
AS
BEGIN
    -- Update data in the HmsDoctorsTable
    UPDATE HmsDoctorsTable
    SET
        DoctorName = @DoctorName,   DoctorDOB = @DoctorDOB,           DoctorPhone = @DoctorPhone,
        DoctorEmail = @DoctorEmail, DoctorPassword = @DoctorPassword, Gender = @Gender
    WHERE
        DoctorId = @DoctorId

    -- Update data in the HmsLoginTable 
    UPDATE HmsLoginTable
    SET
        UserName = @DoctorName,
        UserPhone = @DoctorPhone,
        UserEmail = @DoctorEmail,
        UserPassword = @DoctorPassword
    WHERE
        DoctorId_In_DoctorTable = @DoctorId
END
