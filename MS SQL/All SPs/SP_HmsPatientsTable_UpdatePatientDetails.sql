Alter PROCEDURE SP_HmsPatientsTable_UpdatePatientDetails
(
    @PatientId int,             @PatientName varchar(50),     @PatientDOB Date,              @PatientPhone varchar(20),
    @PatientEmail varchar(100), @PatientPassword varchar(20), @Gender varchar(20),           @FatherName varchar(50),
    @MaritalStatus varchar(20), @BloodGroup varchar(20),      @Symptoms varchar(256) = NULL, @Diagnosis varchar(256) = NULL
)
AS
BEGIN
    -- Update data in the HmsPatientsTable
    UPDATE HmsPatientsTable
    SET
        PatientName = @PatientName,    PatientDOB = @PatientDOB,            PatientPhone = @PatientPhone,
        PatientEmail = @PatientEmail,  PatientPassword = @PatientPassword,  Gender = @Gender,
        FatherName = @FatherName,      MaritalStatus = @MaritalStatus,      BloodGroup = @BloodGroup,
        Symptoms = @Symptoms,          Diagnosis = @Diagnosis,              UpdatedBy = @PatientName,       UpdatedOn = getdate()
    WHERE
        PatientId = @PatientId

    -- Update data in the HmsLoginTable 
    UPDATE HmsLoginTable
    SET
        UserName = @PatientName,
        UserPhone = @PatientPhone,
        UserEmail = @PatientEmail,
        UserPassword = @PatientPassword
    WHERE
        PatientId_In_PatientTable = @PatientId
END
