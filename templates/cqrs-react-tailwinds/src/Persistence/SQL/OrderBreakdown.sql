/****** Script for SelectTopNRows command from SSMS  ******/
SELECT COUNT(case when l.Name = 'Mbabane' then 1 else null end) as 'Total Orders - Mbabane'
      , SUM(case when l.Name = 'Mbabane' then OrderTotal else 0 end) as 'Total Amount - Mbabane'
	  , COUNT(case when l.Name = 'Matsapha' then 1 else null end) as 'Total Orders - Matsapha'
      , SUM(case when l.Name = 'Matsapha' then OrderTotal else 0 end) as 'Total Amount - Matsapha'
	  , COUNT(*) as 'Total Orders'
      , SUM(OrderTotal) as 'Total Amount'

FROM [Canteen_DB].[dbo].[Orders] as o
    INNER JOIN [Canteen_DB].[dbo].[Locations] as l
    ON  l.LocationID = o.LocationID
WHERE [OrderType] = 'CashOrder'