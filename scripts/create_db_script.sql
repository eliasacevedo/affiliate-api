create database AFILIADOS_ELIAS_ACEVEDO;
use AFILIADOS_ELIAS_ACEVEDO;

GO
create table GeneralStatus (
	Id int identity(1,1) primary key,
	Estatus varchar(40)
);
GO
insert into GeneralStatus (Estatus) values ('Inactivo');
insert into GeneralStatus (Estatus) values ('Activo');
GO
create table Plans (
	Id  int primary key identity(1,1) not null,
	Names varchar(50) not null,
	CoverageAmount decimal(12,2),
	RegistryDate date default GETDATE(),
	StatusId int not null ,
	CONSTRAINT FK_Plans_Status_Id FOREIGN KEY (StatusId)
        REFERENCES GeneralStatus (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
go
create table Affiliate(
	Id int primary key identity(1,1) not null,
	Firstname varchar(50) not null,
	Lastname varchar(50) not null,
	BirthDate date not null,
	Sex bit not null,
	IdentificationId varchar(11) not null,
	PhoneNumber varchar(10),
	SocialSecurity varchar(13) not null,
	RegistryDate date default GETDATE(),
	ConsumedAmount decimal(12,2),
	PlanId int not null,
	StatusId int not null,

	CONSTRAINT FK_Users_Plan_Id FOREIGN KEY (PlanId)
        REFERENCES Plans (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	CONSTRAINT FK_Status_Id FOREIGN KEY (StatusId)
        REFERENCES GeneralStatus (Id)
);

GO
CREATE PROCEDURE AffiliateInsert
	@Firstname varchar(50),
	@Lastname varchar(50),
	@BirthDate date, 
	@Sex bit,
	@IdentificationId varchar(11),
	@PhoneNumber varchar(10),
	@SocialSecurity varchar(13),
	@ConsumedAmount decimal(12,2), 
	@PlanId int,
	@StatusId int
AS   

insert into Affiliate (Firstname, Lastname, BirthDate, Sex, IdentificationId, PhoneNumber, SocialSecurity, RegistryDate, ConsumedAmount, PlanId, StatusId) 
values (@Firstname, @Lastname, @BirthDate, @Sex, @IdentificationId, @PhoneNumber, @SocialSecurity, GETDATE(), @ConsumedAmount, @PlanId, @StatusId);
GO

CREATE PROCEDURE AffiliateUpdate
	@Id int,
	@Firstname varchar(50),
	@Lastname varchar(50),
	@BirthDate date ,
	@Sex bit,
	@IdentificationId varchar(11),
	@PhoneNumber varchar(10),
	@SocialSecurity varchar(13), 
	@ConsumedAmount decimal(12,2), 
	@PlanId int,
	@StatusId int 
AS   

update Affiliate 
set Firstname = @Firstname, Lastname = @Lastname, BirthDate = @BirthDate, Sex = @Sex, IdentificationId = @IdentificationId, PhoneNumber = @PhoneNumber, SocialSecurity = @SocialSecurity, ConsumedAmount = @ConsumedAmount, PlanId = @PlanId, StatusId = @StatusId
where Id = @ID;

GO

CREATE PROCEDURE AddAffiliateConsumedAmount
	@UserId int,
	@Amount decimal(12,2)
as

update Affiliate
set ConsumedAmount += @Amount 
where Id = @UserId;

GO

CREATE INDEX AffiliateFilter ON Affiliate (Firstname, Lastname, IdentificationId);

-- Recordar agregar indices para busquedas por nombre, apellido y cedula