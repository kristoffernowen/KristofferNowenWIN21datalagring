
CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(50) not null,
	PostalCode char(5) not null,
	City nvarchar(50) not null,
	Country nvarchar(25) not null
)
GO
CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50)not null,
	AddressId int references Addresses(Id)
)
GO
CREATE TABLE ContactInfo (
	Id int not null identity primary key,
	CustomerId int not null references Customers(Id),
	Email varchar(100) not null unique,
	PrimaryPhoneNumber varchar(10) not null,
	SecondaryPhoneNumber varchar(10) not null,
)

CREATE TABLE StatusOfCases (
	Id int not null primary key,
	StatusOfCase varchar(20) not null
)

CREATE TABLE Administrators(
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null,
	PhoneNumber varchar(10) not null
)

GO
CREATE TABLE CaseNumbers (
	Id int not null identity primary key,
	CustomerId int not null references Customers(Id),
	Header nvarchar(25) not null,
	
)
GO
CREATE TABLE CaseDetails (
	Id int not null identity primary key,
	CaseNumbersId int not null references CaseNumbers(Id),
	CaseDescription nvarchar(max) not null,
	RegistrationDate datetime2 not null,
	DateOfLastChange datetime2 not null,
	StatusId int not null default 1 references StatusOfCases(Id),
	AdministratorId int references Administrators(Id)
)


