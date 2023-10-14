Alter PROCEDURE SP_HmsPatientsTable_InsertPatientDetails
(
    @PatientName varchar(50),		@PatientDOB Date,					@PatientPhone varchar(20), 
	@PatientEmail varchar(100),		@PatientPassword varchar(20),		@Gender varchar(20), 
	@FatherName varchar(50),		@MaritalStatus varchar(20),			@BloodGroup varchar(20),
    @Symptoms varchar(256) = NuLL,  @Diagnosis varchar(256) = NuLL
)
AS
BEGIN
    -- Insert data into the HmsPatientsTable
    INSERT INTO HmsPatientsTable
    (
        PatientName, PatientDOB, PatientPhone,  PatientEmail, PatientPassword,
		Gender,      FatherName, MaritalStatus, BloodGroup,   Symptoms,
		Diagnosis,   CreatedBy,  CreatedOn
    )
    VALUES
    (
        @PatientName, @PatientDOB,  @PatientPhone,  @PatientEmail,  @PatientPassword,
		@Gender,      @FatherName,  @MaritalStatus, @BloodGroup,    @Symptoms,
		@Diagnosis,   @PatientName,   GETDATE()
    )

	-- Return the ID of the newly inserted record
    SELECT SCOPE_IDENTITY() AS PatientId

	Insert Into HmsLoginTable(UserName,UserPhone,UserEmail,UserPassword,PatientId_In_PatientTable) values 
	(@PatientName, @PatientPhone, @PatientEmail, @PatientPassword, SCOPE_IDENTITY())

	Select SCOPE_IDENTITY() AS UserId

	Insert Into HmsUserRoleMappingTable(UserId, RoleId) Values (SCOPE_IDENTITY(), 3)
END


-----------------------------------  Execution of Above SP  ---------------------

DECLARE @NewPatientId int
DECLARE @NewUserId int
EXEC SP_HmsPatientsTable_InsertPatientDetails
    @PatientName = 'molly Singh',
    @PatientDOB = '1993-01-15',
    @PatientPhone = '1995555590',
    @PatientEmail = 'mollysingh@gmail.com',
    @PatientPassword = '123456',
    @Gender = 'Male',
    @FatherName = 'X-Man Singh',
    @MaritalStatus = 'Single',
    @BloodGroup = 'A+',
    @Symptoms = 'Fever, Headache',
    @Diagnosis = 'Common cold'

	-- Retrieve the newly inserted PatientId
SELECT @NewPatientId
SELECT @NewUserId


