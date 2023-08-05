IF OBJECT_ID('usp_get_users','P') IS NOT NULL
    DROP PROC usp_get_users
GO
CREATE PROCEDURE usp_get_users
AS
BEGIN
    SELECT * FROM Users
END