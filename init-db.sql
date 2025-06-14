-- Create database if not exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HotelHub')
BEGIN
    CREATE DATABASE [HotelHub];
END;
GO

USE [HotelHub];
GO

-- Database is ready for Entity Framework migrations 