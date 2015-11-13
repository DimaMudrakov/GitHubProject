IF  EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Customers')
DROP DATABASE Customers

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Customers')
CREATE DATABASE Customers