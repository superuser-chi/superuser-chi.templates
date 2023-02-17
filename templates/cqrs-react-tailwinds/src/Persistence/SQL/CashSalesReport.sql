/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [OrderID]
      , CAST([OrderDate] AS DATE) AS "Date"
      , [OrderTotal]
	  , l.Name as 'Location'
      , case when SitIn = 1 then 'Yes' else 'No' end as 'TakeAway'
      , case when IsTenant = 1 then 'Yes' else 'No' end as 'Tenant Order'
FROM [Canteen_DB].[dbo].[Orders] as o
    INNER JOIN [Locations] as l
    ON  l.LocationID = o.LocationID
WHERE [OrderType] = 'OnlineOrder'
    and [OrderDate] >= '2021-09-01' and [OrderDate] < '2021-10-01';
