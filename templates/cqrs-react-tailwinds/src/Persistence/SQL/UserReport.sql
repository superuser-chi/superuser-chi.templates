/****** Script for SelectTopNRows command from SSMS  ******/
USE [Canteen_DB]
SELECT
    [UserName]
      , [Email]
      , U.[Name] as 'Full Name'
      , L.[Name] AS 'Location'
      , D.[Name] AS 'Department'
	  , R.[Name] AS 'Role'
FROM [Canteen_DB].[dbo].[AspNetUsers] AS U
    INNER JOIN [AspNetUserRoles] AS UR
    ON U.Id = UR.UserId
    INNER JOIN [AspNetRoles] AS R
    ON UR.RoleId = R.Id
    INNER JOIN [Departments] as D
    ON D.DepartmentID = U.DepartmentID
    INNER JOIN [Locations] as L
    on U.LocationID = L.LocationID
WHERE R.Name != 'UserCustomer'
 