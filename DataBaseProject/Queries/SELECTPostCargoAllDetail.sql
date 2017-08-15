SELECT PostCargo.PublicationDate as PubDate,
CountryFrom.Name as CountryFrom, LocPlaceFrom.Name as CityFrom, LocFrom.AddressDetail as AddressFrom,
CountryTo.Name as CountryTo, LocPlaceTo.Name as CityTo, LocTo.AddressDetail as AddresToTo, PostCargo.Price,
cspec.Description, PostCargo.AdditionalInformation
FROM PostCargo 

INNER JOIN Locality as LocFrom ON LocFrom.Id = PostCargo.LocalityFromId
INNER JOIN LocalityPlace as LocPlaceFrom ON LocPlaceFrom.Id = LocFrom.LocalyPlaceId
INNER JOIN Country as CountryFrom ON CountryFrom.Id = LocPlaceFrom.CountryId

INNER JOIN Locality as LocTo On LocTo.Id = PostCargo.LocalityToId
INNER JOIN LocalityPlace as LocPlaceTo ON LocPlaceTo.Id = LocTo.LocalyPlaceId
INNER JOIN Country as CountryTo ON CountryTo.Id = LocPlaceTo.CountryId

INNER JOIN CargoSpecification AS cspec ON cspec.Id = PostCargo.CargoSpecificationId

ORDER BY PubDate;

