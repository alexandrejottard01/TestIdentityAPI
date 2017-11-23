/*Drop table Smart city*/
DROP TABLE Vote_interest_point;
DROP TABLE Vote_description;
DROP TABLE [Description];
DROP TABLE Interest_point;
DROP TABLE Unknown_point;
DROP TABLE [User];

/*Drop table Asp Net Identity*/
DROP TABLE AspNetUserTokens;
DROP TABLE __EFMigrationsHistory;
DROP TABLE AspNetUserRoles;
DROP TABLE AspNetUserLogins;
DROP TABLE AspNetUserClaims;
DROP TABLE AspNetRoleClaims;
DROP TABLE AspNetRoles;
DROP TABLE AspNetUsers;


/* SCRIPT GENERATION TABLE ASP NET IDENTITY */
USE [MoveAndSeeDatabaseTest]

/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	is_certified bit not null,
	name_certified varchar(30),
	language varchar(20) not null,
	isMale bit,
	birth_date date,
	row_version timestamp,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10-Nov-17 7:51:45 AM ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


SET ANSI_PADDING ON


/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 10-Nov-17 7:51:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

SET ANSI_PADDING ON


/****** Object:  Index [RoleNameIndex]    Script Date: 10-Nov-17 7:51:45 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

SET ANSI_PADDING ON


/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 10-Nov-17 7:51:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

SET ANSI_PADDING ON


/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 10-Nov-17 7:51:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

SET ANSI_PADDING ON


/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 10-Nov-17 7:51:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

SET ANSI_PADDING ON


/****** Object:  Index [EmailIndex]    Script Date: 10-Nov-17 7:51:45 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

SET ANSI_PADDING ON


/****** Object:  Index [UserNameIndex]    Script Date: 10-Nov-17 7:51:45 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]

ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]

ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]

USE [MoveAndSeeDatabaseTest]

ALTER DATABASE [MoveAndSeeDatabaseTest] SET  READ_WRITE 

/*Generation table Smart City*/
create table Interest_point(
	id_interest_point bigint identity(1,1) not null,
	id_user [nvarchar](450) not null,
	latitude decimal(9,6) not null,
	longitude decimal(9,6) not null,
	name varchar(30) not null,
	date_creation date not null,
	primary key(id_interest_point),
	constraint fk_creator_interest_point foreign key (id_user) references [AspNetUsers](Id)
);

create table Unknown_point(
	id_unknown_point bigint identity(1,1) not null,
	id_user [nvarchar](450) not null,
	latitude decimal(9,6) not null,
	longitude decimal(9,6) not null,
	date_creation date not null,
	primary key(id_unknown_point),
	constraint fk_creator_unknown_point foreign key (id_user) references [AspNetUsers](Id)
);

create table Description(
	id_description bigint identity(1,1) not null,
	explication varchar(500) not null,
	id_user [nvarchar](450) not null,
	id_interest_point bigint not null,
    constraint fk_writing foreign key (id_user) references [AspNetUsers](Id),
	constraint fk_subject foreign key (id_interest_point) references Interest_point(id_interest_point),
	primary key(id_description)
);

create table Vote_interest_point(
	is_positive_assessment bit not null,
	id_user [nvarchar](450) not null,
	id_interest_point bigint not null,
	constraint fk_vote_interest_point foreign key (id_user) references [AspNetUsers](Id),
	constraint fk_interest_point_voted foreign key (id_interest_point) references Interest_point(id_interest_point),
	primary key(id_user,id_interest_point)
);

create table Vote_description(
	is_positive_assessment bit not null,
	id_user [nvarchar](450) not null,
	id_description bigint not null,
	constraint fk_description_voted foreign key (id_description) references [Description](id_description),
	constraint fk_voter_description foreign key (id_user) references [AspNetUsers](Id),
	primary key(id_description,id_user)
);

/*INSERT INTO [dbo].[User] (pseudo, [password], [is_certified], name_certified, [email],[language],isMale, birth_date,[is_admin]) 
VALUES	('Chronix', '$2y$10$xDNtN7tc6AQdWXHNl0NhMedD2O8LfEOl2BGSdrdxNbfJMv9c1LKM2', 1, 'Alexandre Jottard','alexandre.jottard@gmail.com','français',1,'1993-07-05', 1),
		('Cheesta', '$2y$10$Qtnowf4cbdGn7JBjvqLlHeaXo5NLy/3BzLlpTnfqmKj9eS65YA3La', 1, 'Bertrand Vens','bertrand.vens@gmail.com','français',1,'1994-11-15', 1),
		('Cha', '$2y$10$ImnuKbIfrInipP.yAwLgneyuQ/eO3p9wKXy3Pbs.1iWKGHTETidi6', 1, 'Charlotte Colin','charlotte.colin@gmail.com','français',0,'1996-01-23', 1),
		('Baraldhur', '$2y$10$ImnuKbIfrInipP.yAwLgneyuQ/eO3p9wKXy3Pbs.1iWKGHTETidi6', 1, 'Bob Dylan','bob.dylan@gmail.com','français',1,'1996-01-23', 1),
		('Barbara', '$2y$10$ImnuKbIfrInipP.yAwLgneyuQ/eO3p9wKXy3Pbs.1iWKGHTETidi6', 1, 'Barbara Stat','barabarabara@gmail.com','français',1,'1996-01-23', 1),
		('Bryan', '$2y$10$ImnuKbIfrInipP.yAwLgneyuQ/eO3p9wKXy3Pbs.1iWKGHTETidi6', 1, 'Bryan Francotte','bryan.fra@gmail.com','français',1,'1996-01-23', 1),
		('Kevin', '$2y$10$ImnuKbIfrInipP.yAwLgneyuQ/eO3p9wKXy3Pbs.1iWKGHTETidi6', 1, 'Kevin Lucien','kevin.lucien@gmail.com','français',1,'1996-01-23', 1),
		('Luc', '$2y$10$ImnuKbIfrInipP.yAwLgneyuQ/eO3p9wKXy3Pbs.1iWKGHTETidi6', 1, 'Luc Pop','luc.pop@gmail.com','français',1,'1996-01-23', 1);

INSERT INTO [dbo].[Interest_point] (id_user, latitude, longitude, [name], date_creation) 
VALUES	(1,50.469262, 4.862445,'Gare de Namur','2017-11-02'),
		(1,50.464312, 4.860252,'Place st Aubain','2017-11-06'),
		(2,50.459962, 4.861122,'Citadelle','2017-11-01'),
		(2,50.471366, 4.854766,'Iesn','2017-11-04'),
		(3,50.463260, 4.867608,'Place d''Armes','2017-11-10'),
		(1,50.463555, 4.864767,'Place du vieux','2017-11-18'),
		(6,50.461816, 4.868940,'Place du Grognon','2017-11-18'),
		(6,50.454757, 4.853983,'Chateau de Namur','2017-11-18'),
		(6,50.458225, 4.852535,'Parc Reine Astrid','2017-11-18'),
		(6,50.466197, 4.865533,'Ancien Eldorado','2017-11-18'),
		(1,50.466591, 4.853872,'Plaque sur le pont','2017-11-18');

INSERT INTO [dbo].[Unknown_point] (id_user, latitude, longitude, date_creation) 
VALUES	(3,50.464076, 4.865961,'2017-11-01'),
		(3,50.464411, 4.868117,'2017-11-01'),
		(3,50.464624, 4.865234,'2017-11-02'),
		(3,50.464024, 4.868810,'2017-10-14');

INSERT INTO [dbo].[Description] (explication, id_user, id_interest_point) 
VALUES	('La gare de Namur est une gare ferroviaire belge située à Namur, au nord de la Corbeille, le centre historique de la ville.',1,1),
		('Le sillon ferroviaire est établi sur un ancien bras de Sambre qui ceinturait anciennement le rempart nord de la ville.',2,1),
		('La place d’Armes, autrefois Grand Place est une place pavée située à Namur en Belgique.',2,2),
		('La place abritait à l''origine l''hôtel de ville, lequel fut incendié par les soldats allemands durant la Première Guerre mondiale.',3,2),
		('La gare est superbe depuis qu''elle a été rénovée',1,1),
		('Il n''y a pas d''armes, je suis déçu',6,5),
		('Bryan t''es stupide',1,5),
		('Ancien Cinéma de Namur qu va être remplacé par des magasins',6,10),
		('Voici ce que l''Eldorado a publié :  C''est avec beaucoup d''émotions et beaucoup de tristesse que notre vieille société namuroise (1918) s''est vue dans l''obligation de prendre la décision de cesser l''exploitation de notre cinéma Eldorado après le 20 décembre 2016.',1,10),
		('PLaque sur la mort de Claude Boucher',1,11),
		('Claude Boucher qu est un grand architecte qui a construit ce pont',2,11),
		('Il y a plein dechet partout c''est dégeulasse',3,1);


INSERT INTO [dbo].[Vote_description] ([is_positive_assessment], id_user, id_description) 
VALUES	(1,1,1),
		(1,1,2),
		(1,1,3),
		(1,2,1),
		(1,2,2),
		(1,2,4),
		(0,3,1),
		(0,3,2),
		(1,3,4);

INSERT INTO [dbo].[Vote_interest_point] ([is_positive_assessment], id_user, id_interest_point) 
VALUES	(1,2,1),
		(0,2,2),
		(0,2,3),
		(0,2,4),
		(1,3,1),
		(1,3,2),
		(1,3,3),
		(0,3,4),
		(0,4,1),
		(0,4,2),
		(1,4,3),
		(1,4,4),
		(1,5,1),
		(0,5,2),
		(0,5,3),
		(0,5,4),
		(1,6,1),
		(1,6,2),
		(0,6,3),
		(0,6,4),
		(1,7,1),
		(1,7,2);*/