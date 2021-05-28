
CREATE PROCEDURE [dbo].[return_next_group_id_for_student]
    @group_id INT
AS
BEGIN
    SELECT TOP(1) id 
    FROM groups
    WHERE group_name_id IN 
        (SELECT TOP(1) group_name_id 
        FROM groups
        WHERE id = @group_id)
        AND group_number IN
            (SELECT TOP(1) group_number + 10 
            FROM groups
            WHERE id = @group_id)
END