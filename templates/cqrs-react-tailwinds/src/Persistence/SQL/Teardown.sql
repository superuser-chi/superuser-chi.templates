/*This is a teadown script by Gift N. Mavuso*/
/*NOTE: Execute this a couple of times till you see 'Command(s) completed successfully.'*/
GO

/****** Object:  Table [dbo].[PortionTypes]    Script Date: 2020/07/31 11:55:29 ******/
EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

DECLARE @sql NVARCHAR(max)=''

SELECT @sql += ' Drop table ' + QUOTENAME(s.NAME) + '.' + QUOTENAME(t.NAME) + '; '
FROM sys.tables t
  JOIN sys.schemas s
  ON t.[schema_id] = s.[schema_id]
WHERE  t.type = 'U'

Exec sp_executesql @sql