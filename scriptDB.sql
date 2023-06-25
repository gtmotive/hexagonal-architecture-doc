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



CREATE TABLE [dbo].[Rentals](
	[VehicleId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

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


