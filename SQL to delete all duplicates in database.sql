WITH CTE_Duplicates AS (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY Title, Year, Genre, AuthorId ORDER BY Id) AS RowNum
    FROM WatchListItems
)
DELETE FROM CTE_Duplicates WHERE RowNum > 1;
