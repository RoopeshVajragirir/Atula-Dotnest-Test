CREATE DATABASE AtulaTechnologies
USE AtulaTechnologies
CREATE TABLE Product( Id INT PRIMARY KEY, Sku VARCHAR(50), Name VARCHAR(100), CategoryId INT)
CREATE TABLE Category(Id INT PRIMARY KEY, CategoryName VARCHAR(100))
CREATE TABLE Users(Id INT PRIMARY KEY, FirstName VARCHAR(100), LastName VARCHAR(100), Email VARCHAR(150), Password VARCHAR(100))