SELECT * FROM PostCargo
Where LocalityFromId IN ( 
SELECT Id FROM Locality
Where LocalyPlaceId IN (
SELECT Id FROM LocalityPlace
WHERE Name = 'Milan'));
