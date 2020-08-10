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


Create Table users
(
    username nvarchar(15) primary key,
    password nvarchar(10),
    isAdmin char(1)
)

Create Table orders
(


flightId nvarchar(500),
passengersNames nvarchar(100),
userEmail nvarchar(70),
orderDate datetime,

FOREIGN KEY (flightId) REFERENCES MyFlights_CS(FlightPath),
primary key(userEmail,flightId)
)

select *
from users u
where u.username= 'dor' and u.password = '1234'

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


create table discounts(
id int IDENTITY(0,1),
AirlineCode nvarchar(90) ,
AirportCodeFrom nvarchar(90) ,
AirportCodeTo nvarchar(90) ,
DateFrom date,
DateTo date,
discount float
FOREIGN KEY (AirlineCode) REFERENCES Airlines_CS(AirlineCode),
 FOREIGN KEY (AirportCodeFrom) REFERENCES Airports_CS(AirportCode),
 FOREIGN KEY (AirportCodeTo) REFERENCES Airports_CS(AirportCode),
 PRIMARY KEY (AirlineCode,AirportCodeFrom,AirportCodeTo,DateFrom,DateTo)


)


create table TourAgent_CS(
     agentID int IDENTITY PRIMARY KEY,
    agentName nvarchar(90),
     agentImage  nvarchar(max),
     pass nvarchar(90),
)


create TABLE Tour_CS(
TourID int IDENTITY (1,1) PRIMARY KEY,
city  NVARCHAR(100),
agentID int, 
price float ,
tourName NVARCHAR(100),
durationInMinute int,
FOREIGN KEY (agentID) REFERENCES TourAgent_CS(agentID)
)





create TABLE TripInTour_CS(
TourID int,
tripID NVARCHAR(500),
durationInMinute int, 
price float,
image NVARCHAR(500) ,
intro NVARCHAR(500) ,
title NVARCHAR(max) ,
openingHour NVARCHAR(max) ,
score float ,
 FOREIGN KEY (TourID) REFERENCES Tour_CS(TourID),
 PRIMARY key (TourID,tripID)
)

UPDATE discounts
SET col1 = constant_value1 , col2 =  constant_value2 , colN = constant_valueN

select * from Airlines_CS
select * from Airports_CS
select * from MyFlights_CS
select * from Legs_CS
select * from discounts
select * from orders

UPDATE discounts set AirlineCode = 'LI', AirportCodeFrom = 'SYD', AirportCodeTo = 'TLV', DateFrom = '05/02/2020', DateTo='05/04/2020', discount = 97 where id = 0