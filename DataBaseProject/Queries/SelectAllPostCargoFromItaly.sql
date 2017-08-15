SELECT Count(LocalityFromId) FROM PostCargo
Where LocalityFromId IN ( 
SELECT Id FROM Locality
Where LocalyPlaceId IN (
SELECT Id FROM LocalityPlace
WHERE CountryId = ( 
SELECT Id FROM Country
WHERE Name = 'Italy')));
