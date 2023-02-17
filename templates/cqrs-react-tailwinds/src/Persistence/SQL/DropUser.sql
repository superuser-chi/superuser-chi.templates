/****** Object:  Database [Canteen_DB]    Script Date: 2020/08/31 10:29:54 ******/

USE [Canteen_DB]
GO
DECLARE @TestVariable AS VARCHAR(100)='d5b46455-ad9f-4294-b4f4-933945ff0bb2'
DELETE FROM OrderDetails
DELETE FROM Orders
DELETE FROM [dbo].[Payments]
      WHERE [AccountID] = @TestVariable
DELETE FROM [dbo].AspNetUsers
      WHERE [AccountID] = @TestVariable 
DELETE FROM [dbo].Accounts
      WHERE [AccountID] = @TestVariable 
GO