/****** Script for SelectTopNRows command from SSMS  ******/
SELECT
    [OrderID] as 'OrderID'
      , A.AccountNumber
      , CAST([OrderDate] AS date) as 'Date'
      , [OrderTotal]
      , l.Name as 'Location'
FROM [Canteen_DB].[dbo].[Orders] as c
    INNER JOIN [Payments] as P
    ON p.PaymentID = c.PaymentID
    INNER JOIN [Locations] as l
    ON l.LocationID = c.LocationID
    INNER JOIN [Accounts] as a
    ON a.AccountID = p.AccountID
