drop table Legs_CS
drop table MyFlights_CS
drop table Airports_CS
drop table Airlines_CS



CREATE table Airlines_CS(
AirlineCode nvarchar(90) primary key,
AirlineName nvarchar(90)
)


create table Airports_CS(
AirportCode nvarchar(90) primary key,
Airportname nvarchar(100),
Longitude nvarchar(15),
Latitudes nvarchar(15),
City nvarchar(80),
Country nvarchar(50),
)

create table MyFlights_CS(
 FlightPath nvarchar(500) primary key,
 AirportFrom nvarchar(90), 
 AirportTo nvarchar(90), 
 DepTime datetime, 
 ArriveTime datetime, 
 Duration nvarchar(20),
 Price float ,
 LegsNumber int ,
 FOREIGN KEY (AirportFrom) REFERENCES Airports_CS(AirportCode),
 FOREIGN KEY (AirportTo) REFERENCES Airports_CS(AirportCode)
)





Create Table Legs_CS
(
id nvarchar(50) primary key,
fullpathid nvarchar(500),
legnumber int,
flight_no nvarchar(10),
fromairport nvarchar(90) REFERENCES Airports_CS(AirportCode),
toairport nvarchar(90) REFERENCES Airports_CS(AirportCode),
airlinecode nvarchar (90),
DepTime datetime,
ArriveTime datetime,
Duration nvarchar(20),
FOREIGN KEY (fullpathid) REFERENCES MyFlights_CS(FlightPath),
FOREIGN KEY (airlinecode) REFERENCES Airlines_CS(AirlineCode),

)

select * from Airlines_CS
select * from Airports_CS
select * from MyFlights_CS
select * from Legs_CS