-----------------------------------------Sp For Time Slots--------------------------------------------

Create PROCEDURE SP_Populate_HmsProviderAvailability_Dynamic
    @StartDate DATE,
    @EndDate DATE,
    @StartTime TIME,
    @EndTime TIME,
    @IntervalMinutes INT,
    @ProviderId INT
AS
BEGIN
    DECLARE @DynamicSQL NVARCHAR(MAX);

    SET @DynamicSQL = N'
    DECLARE @StartDate DATE = @StartDateParam;
    DECLARE @EndDate DATE = @EndDateParam;
    DECLARE @StartTime TIME = @StartTimeParam;				-- Start time of slots
    DECLARE @EndTime TIME = @EndTimeParam;					-- End time of slots
    DECLARE @IntervalMinutes INT = @IntervalMinutesParam;	-- Interval between slots

    WHILE @StartDate <= @EndDate
    BEGIN
        SET @StartTime = @StartTimeParam;

        WHILE @StartTime <= DATEADD(MINUTE, @IntervalMinutesParam, @EndTimeParam)
        BEGIN
            INSERT INTO HmsProviderAvailabilityTable (DateAvailable, TimeSlots, ProviderId)
            VALUES (@StartDate, @StartTime, @ProviderIdParam);

            SET @StartTime = DATEADD(MINUTE, @IntervalMinutesParam, @StartTime);
        END;

        SET @StartDate = DATEADD(DAY, 1, @StartDate);
    END;';

    EXEC sp_executesql @DynamicSQL, N'@StartDateParam DATE, @EndDateParam DATE, @StartTimeParam TIME, @EndTimeParam TIME, @IntervalMinutesParam INT, @ProviderIdParam INT',
        @StartDate, @EndDate, @StartTime, @EndTime, @IntervalMinutes, @ProviderId;
END;

-------------------------------------- Execute Command For  Above SP ------------------------------------

DECLARE @StartDate DATE = '2023-10-13'
DECLARE @EndDate DATE = '2023-10-13'
DECLARE @StartTime TIME = '09:00:00'
DECLARE @EndTime TIME = '11:30:00'
DECLARE @IntervalMinutes INT = 30
DECLARE @ProviderId INT = 2

EXEC SP_Populate_HmsProviderAvailability_Dynamic @StartDate, @EndDate, @StartTime, @EndTime, @IntervalMinutes, @ProviderId;

----------------------------------------------------------------------------------------------------------



