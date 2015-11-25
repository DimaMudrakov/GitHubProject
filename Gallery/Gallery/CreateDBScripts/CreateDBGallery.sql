IF  EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Gallery')
DROP DATABASE Gallery

IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Gallery')
CREATE DATABASE Gallery