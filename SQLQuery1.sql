-- Crear base de datos
CREATE DATABASE UniversityDB;
GO

-- Seleccionar la base de datos para trabajar
USE UniversityDB;
GO

-- Crear tabla UniversityPage para la relación 1 a 1 en University
CREATE TABLE UniversityPage (
    Id INT PRIMARY KEY,
    PageDetails NVARCHAR(MAX) -- Ajusta el tipo de datos y nombre de campo si necesitas más campos específicos
);
GO

-- Crear tabla University
CREATE TABLE University (
    Id INT PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    AlphaTwoCode NVARCHAR(MAX) NOT NULL,
    StateProvince NVARCHAR(MAX),
    Country NVARCHAR(MAX) NOT NULL,
    Deleted BIT NOT NULL,
    UniversityPageId INT NOT NULL,
    CONSTRAINT FK_UniversityPage FOREIGN KEY (UniversityPageId) REFERENCES UniversityPage(Id)
);
GO

-- Crear tabla UniversityDomain
CREATE TABLE UniversityDomain (
    Id INT PRIMARY KEY,
    Domain NVARCHAR(MAX) NOT NULL,
    UniversityId INT NOT NULL,
    CONSTRAINT FK_UniversityDomain FOREIGN KEY (UniversityId) REFERENCES University(Id)
);
GO

-- Crear tabla UniversityWebPage
CREATE TABLE UniversityWebPage (
    Id INT PRIMARY KEY,
    WebPage NVARCHAR(MAX) NOT NULL,
    UniversityId INT NOT NULL,
    CONSTRAINT FK_UniversityWebPage FOREIGN KEY (UniversityId) REFERENCES University(Id)
);
GO
