--create table Airports_CS(
--AirportCode nvarchar primary key,
--airportname nvarchar(40),
--long int,
--lat int,
--airportcity nvarchar(30),
--airportCountry nvarchar(40),
--)


--create table Airlines_CS(
--AirlinesCode nvarchar primary key,
--Airportname nvarchar(40)
--)

--create table MyFlights_CS(
-- FlightPath nvarchar primary key,
-- AirportFrom  nvarchar, 
-- AirportTo nvarchar, 
-- DepTime nvarchar(40), 
-- ArriveTime nvarchar(40), 
-- Duration nvarchar(20),
-- Price float ,
-- LegsNumber int ,
-- FOREIGN KEY (AirportFrom) REFERENCES Airports_CS(AirportCode),
--  FOREIGN KEY (AirportTo) REFERENCES Airports_CS(AirportCode)
--)