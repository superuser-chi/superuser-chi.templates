/****** Script for SelectTopNRows command from SSMS  ******/


-- SELECT  TOP (100) 
-- 	   U.Name
-- 	   ,D.Name
-- 	  ,P.Reference
--       ,P.[Date]
--       ,P.[Amount]
--   FROM [Payments] P
--   JOIN [Accounts] A ON A.AccountID = P.AccountID
--   JOIN [AspNetUsers] U ON A.Id = U.Id
--   JOIN [Departments] D ON D.DepartmentID = U.DepartmentID
--   WHERE  [PaymentTypeID] = 'b3500059-b7ec-434a-b330-58819c7799d8' AND
--      A.AccountType = 'IndividualAccount' AND 
-- 	 U.DepartmentID != '57034cc4-960c-4f35-8abc-a378184edf22' AND
-- 	 P.Amount > 0
--   union
  
--   SELECT
--       [UserID]
--   FROM [Canteen_DB].[dbo].[MeetingParticipants]
--   WHERE [UserID] = '---'

  
-- SELECT * FROM
-- (
-- SELECT  
-- 	   U.Name
-- 	   , A.AccountNumber
-- 	   ,D.Name as Department
--       ,P.[Date]
-- 	  , ROW_NUMBER() OVER (PARTITION BY A.AccountNumber ORDER BY P.Date DESC) AS RowNumber
--   FROM [Payments] P
--   JOIN [Accounts] A ON A.AccountID = P.AccountID
--   JOIN [AspNetUsers] U ON A.Id = U.Id
--   JOIN [Departments] D ON D.DepartmentID = U.DepartmentID
--   WHERE  [PaymentTypeID] = 'b3500059-b7ec-434a-b330-58819c7799d8' AND
--      A.AccountType = 'IndividualAccount' AND 
-- 	 U.DepartmentID != '57034cc4-960c-4f35-8abc-a378184edf22' AND
-- 	 P.Amount > 0
-- ) a
-- WHERE RowNumber = 1

-- /****** Script for SelectTopNRows command from SSMS  ******/
-- SELECT DISTINCT Name, AccountNumber
-- FROM (
-- 	SELECT 
-- 	       U.Name
-- 		   ,A.AccountNumber
-- 		  ,[Amount]
-- 		   , P.Reference 	
-- 		  ,[Date]
-- 		  ,[PaymentTypeID]
-- 		  ,A.[AccountID]
-- 	  FROM [Canteen_DB].[dbo].[Payments] AS P
-- 	  INNER JOIN [Accounts] AS A ON A.AccountID = P.AccountID
-- 	  INNER JOIN [AspNetUsers] AS U ON A.Id = U.Id 
-- 	  WHERE DebitIndicator = 0 AND 
-- 	  A.AccountType = 'IndividualAccount' AND
-- 	  P.PaymentTypeID = 'b3500059-b7ec-434a-b330-58819c7799d8' AND
-- 	  P.Amount > 0
--   ) A


-- SELECT P.AccountID,p.[Date], pt.Name
-- FROM Payments AS P
-- INNER JOIN PaymentTypes AS PT ON p.PaymentTypeID = pt.PaymentTypeID


select * from Orders