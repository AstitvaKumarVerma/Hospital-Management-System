Create PROCEDURE SP_HmsDoctorsTable_DeleteDoctorDetails
(
	@DoctorId int
)
AS
BEGIN
	-- Update IsActive & IsDeleted in the HmsDoctorsTable
    UPDATE HmsDoctorsTable
    SET
        IsActive = 0,    IsDeleted = 1,
		DeletedBy = 'Admin',       DeletedOn = getdate()
    WHERE
        DoctorId = @DoctorId

    -- Update IsActive & IsDeleted in the HmsLoginTable 
    UPDATE HmsLoginTable
    SET
        IsActive = 0,    IsDeleted = 1
    WHERE
        DoctorId_In_DoctorTable = @DoctorId
END