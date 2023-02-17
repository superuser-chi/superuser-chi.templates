/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  CAST([OrderDate] AS date) as 'Date'
    ,COUNT(case when OrderType = 'OnlineOrder' then 1 else null end) AS 'Online Orders'
	,SUM(case when OrderType = 'OnlineOrder' then OrderTotal else 0 end) AS 'Total Online Amount'
	,COUNT(case when OrderType = 'CashOrder' then 1 else null end) AS 'Cash Orders'
	,SUM(case when OrderType = 'CashOrder' then OrderTotal else 0 end) AS 'Total Cash Amount'
	,COUNT(*) as 'Total Orders'
	,SUM([OrderTotal]) as  'Total Amount'
  FROM [Canteen_DB].[dbo].[Orders] as U
  WHERE [LocationID] = '4743ed46-16a1-4bbd-a472-37e83ae81b07' 
  GROUP BY  CAST([OrderDate] AS date)
  ORDER BY 'Date'