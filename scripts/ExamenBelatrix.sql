USE master
go

CREATE DATABASE BelatrixLog
GO

CREATE LOGIN BelatrixLogUser
WITH Password = 'belatrixlog',
DEFAULT_DATABASE = BelatrixLog,
CHECK_EXPIRATION = Off,
CHECK_POLICY = Off
GO

ALTER SERVER ROLE dbcreator
ADD MEMBER BelatrixLogUser
GO

USE BelatrixLog
GO

CREATE USER BelatrixLogUser
FOR LOGIN BelatrixLogUser
GO

sp_addrolemember 'db_owner', BelatrixLogUser
GO

CREATE TABLE ApplicationLog(
	ApplicationLogId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	LogDate DATETIME NOT NULL DEFAULT GETDATE(),
	ApplicationLogMessage VARCHAR(max) NOT NULL,
	LogLevel VARCHAR(10) NOT NULL
)
GO

CREATE PROCEDURE ApplicationLogInsert
@ApplicationLogMessage VARCHAR(max),
@LogLevel VARCHAR(10)
AS
	INSERT INTO ApplicationLog(ApplicationLogMessage, LogLevel) 
	VALUES(@ApplicationLogMessage, @LogLevel)
GO