use CARGO;

SELECT [c].[Name], [c].[Alpha2Code] FROM [dbo].[Country] AS [c] 
WHERE [c].[Name] LIKE 'M%'
ORDER BY [c].[Name];

