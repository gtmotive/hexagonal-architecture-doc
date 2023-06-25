USE [dbPtRenting]
GO

drop table Rentals
drop table Vehicles
drop table Clients

CREATE TABLE Clients
(
	[ClientId] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NULL,
)


INSERT INTO Clients ([Name], [Email], [Phone]) VALUES ('Beatriz', 'beatriz1985@gmail.com', '655123123');
INSERT INTO Clients ([Name], [Email], [Phone]) VALUES ('Victor', 'vaf85@gmail.com', '654456456');

CREATE TABLE Vehicles
(
	[VehicleId] [int] PRIMARY KEY,
	[Brand] [varchar](50) NOT NULL,
	[ManufacturingDate] [datetime] NOT NULL,
)

INSERT INTO Vehicles ([VehicleId], [Brand], [ManufacturingDate]) VALUES (1, 'Brand1', '01/01/2023');
INSERT INTO Vehicles ([VehicleId], [Brand], [ManufacturingDate]) VALUES (2, 'Brand2', '10/02/2022');


CREATE TABLE [dbo].[Rentals](
	[VehicleId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[StartingDate] [datetime] NOT NULL,
	[EndingDate] [datetime] NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY 
(
	[VehicleId] ASC,
	[ClientId] ASC,
    [StartingDate] ASC
))

ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO

ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Clients]
GO

ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
GO

ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Vehicles]
GO


INSERT INTO Rentals ([VehicleId], [ClientId], [StartingDate], EndingDate) VALUES (1, 1, '02/01/2023', '03/01/2023');
INSERT INTO Rentals ([VehicleId], [ClientId], [StartingDate], EndingDate) VALUES (1, 1, '03/10/2023', '03/15/2023');
INSERT INTO Rentals ([VehicleId], [ClientId], [StartingDate], EndingDate) VALUES (1, 1, '03/16/2023', '03/20/2023');


INSERT INTO Rentals ([VehicleId], [ClientId], [StartingDate], EndingDate) VALUES (1, 1, '2023-02-01', '2023-03-01');
INSERT INTO Rentals ([VehicleId], [ClientId], [StartingDate], EndingDate) VALUES (1, 1, '2023-03-01', '2023-03-15');
INSERT INTO Rentals ([VehicleId], [ClientId], [StartingDate], EndingDate) VALUES (1, 1, '2023-03-16', '2023-03-20');



select * from Vehicles
select * from Rentals

