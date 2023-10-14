Alter PROCEDURE SP_HmsPatientsTable_DeletePatientDetails
(
	@PatientId int
)
AS
BEGIN
	-- Update IsActive & IsDeleted in the HmsPatientsTable
    UPDATE HmsPatientsTable
    SET
        IsActive = 0,    IsDeleted = 1,
		DeletedBy = 'Admin',       DeletedOn = getdate()
    WHERE
        PatientId = @PatientId

    -- Update IsActive & IsDeleted in the HmsLoginTable 
    UPDATE HmsLoginTable
    SET
        IsActive = 0,    IsDeleted = 1
    WHERE
        PatientId_In_PatientTable = @PatientId
END