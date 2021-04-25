USE MASTER
GO

IF exists(SELECT * FROM sysdatabases WHERE NAME='PD1Movies')
		DROP DATABASE PD1Movies
GO

CREATE DATABASE PD1Movies
GO

USE PD1Movies
GO

CREATE TABLE Movies(
	Id			INT			NOT NULL	PRIMARY KEY IDENTITY(1,1),
	Title			VARCHAR(50)		NOT NULL,
	ReleaseDate		DATE			NOT NULL,
	Budget			MONEY			NOT NULL,
	AvgRating		Numeric(18,2)		NOT NULL,	
	Imax3D			BIT			NOT NULL,
	TicketsSold		INT			NOT NULL
)
