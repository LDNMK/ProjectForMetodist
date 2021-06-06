
CREATE PROCEDURE [dbo].[return_next_group_id_for_student]
    @group_id INT
AS
BEGIN
    SELECT TOP(1) id 
    FROM groups
    WHERE GroupPrefixId IN 
        (SELECT TOP(1) GroupPrefixId 
        FROM groups
        WHERE id = @group_id)
        AND group_number IN
            (SELECT TOP(1) group_number + 10 
            FROM groups
            WHERE id = @group_id)
END