SELECT LocalityPlace.Name as City, Country.Name as Country,
Locality.AddressDetail as Addres
FROM Country 
INNER JOIN LocalityPlace ON Country.Id=LocalityPlace.CountryId
LEFT OUTER JOIN Locality ON Locality.LocalyPlaceId=LocalityPlace.Id;
