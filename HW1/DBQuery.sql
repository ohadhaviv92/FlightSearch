--create table Airports_CS(
--AirportCode nvarchar(40) primary key,
--Airportname nvarchar(40),
--Longitude nvarchar(15),
--Latitudes nvarchar(15),
--City nvarchar(30),
--Country nvarchar(40),
--)

--INSERT INTO Airports_CS (AirportCode, Airportname, Longitude, Latitudes, City, Country) Values('LCG', 'A Coruña' ,-8.377222, 43.302222, 'A Coruña', 'Spain')

DROP TABLE Airlines_CS


CREATE table Airlines_CS(
AirlineCode nvarchar(40) primary key,
AirlineName nvarchar(40)
)

create table MyFlights_CS(
 FlightPath nvarchar(500) primary key,
 AirportFrom  nvarchar(100), 
 AirportTo nvarchar(100), 
 DepTime nvarchar(40), 
 ArriveTime nvarchar(40), 
 Duration nvarchar(20),
 Price float ,
 LegsNumber int ,
 FOREIGN KEY (AirportFrom) REFERENCES Airports_CS(AirportCode),
  FOREIGN KEY (AirportTo) REFERENCES Airports_CS(AirportCode)
)


create table Airports_CS(
AirportCode nvarchar(30) primary key,
Airportname nvarchar(40),
Longitude nvarchar(15),
Latitudes nvarchar(15),
City nvarchar(30),
Country nvarchar(40),
)