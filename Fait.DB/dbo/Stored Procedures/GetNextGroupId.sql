CREATE PROCEDURE [dbo].[GetNextGroupId]
	@GroupId INT
AS
BEGIN
	BEGIN TRY
		DECLARE @NextGroupId INT = NULL;

		BEGIN TRANSACTION

			DECLARE @GroupNumber INT;
			DECLARE @GroupPrefixId INT;
			DECLARE @Course INT;

			-- Current group
			SELECT 
				@GroupNumber = g.GroupNumber,
				@GroupPrefixId = g.GroupPrefixId,
				@Course = g.Course
			FROM Groups g
			WHERE g.Id = @GroupId

			-- Try to find next group
			SET @NextGroupId = (SELECT dbo.GetGroupId(@Course + 1, @GroupPrefixId))

			-- If groupId not found - we have to create a new group
			IF (@NextGroupId IS NULL)
			BEGIN
				INSERT INTO Groups (GroupNumber, GroupPrefixId, Actual, Course)
				VALUES (@GroupNumber + 10, @GroupPrefixId, 1, @Course + 1);

				-- IDENT_CURRENT('table') - Returns the last identity value generated for a specified table or view. 
				-- The last identity value generated can be for any session and any scope.
				SET @NextGroupId = (SELECT IDENT_CURRENT('Groups'))
			END

		COMMIT TRANSACTION

		SELECT @NextGroupId;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		THROW;
	END CATCH
END
