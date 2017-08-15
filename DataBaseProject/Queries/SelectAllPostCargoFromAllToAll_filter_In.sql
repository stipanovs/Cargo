SELECT * FROM PostCargo
Where LocalityFromId IN ( 
SELECT Id FROM Locality
Where LocalyPlaceId IN (
SELECT Id FROM LocalityPlace
WHERE CountryId IN ( 
SELECT Id FROM Country
WHERE Name IN ('Italy'))))
AND
LocalityToId IN ( 
SELECT Id FROM Locality
Where LocalyPlaceId IN (
SELECT Id FROM LocalityPlace
WHERE CountryId IN ( 
SELECT Id FROM Country
WHERE Name IN ('Russia',  'Moldova, Republic of '))))
ORDER By DateFrom;