
CREATE PROCEDURE [dbo].[return_next_group_id_for_student]
    @group_id INT
AS
BEGIN
    SELECT TOP(1) Id 
    FROM Groups
    WHERE GroupPrefixId IN 
        (SELECT TOP(1) GroupPrefixId 
        FROM Groups
        WHERE Id = @group_id)
        AND GroupNumber IN
            (SELECT TOP(1) GroupNumber + 10 
            FROM Groups
            WHERE Id = @group_id)
END