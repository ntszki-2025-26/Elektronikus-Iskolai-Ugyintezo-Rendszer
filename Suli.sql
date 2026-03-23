USE [master]
GO
/****** Object:  Database [Suli]    Script Date: 2026. 02. 24. 10:46:37 ******/
CREATE DATABASE [Suli]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Suli', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.SQLEXPRESS\MSSQL\DATA\Suli.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Suli_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.SQLEXPRESS\MSSQL\DATA\Suli_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Suli] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Suli].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Suli] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Suli] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Suli] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Suli] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Suli] SET ARITHABORT OFF 
GO
ALTER DATABASE [Suli] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Suli] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Suli] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Suli] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Suli] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Suli] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Suli] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Suli] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Suli] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Suli] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Suli] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Suli] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Suli] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Suli] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Suli] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Suli] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Suli] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Suli] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Suli] SET  MULTI_USER 
GO
ALTER DATABASE [Suli] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Suli] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Suli] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Suli] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Suli] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Suli] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [Suli] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Suli] SET QUERY_STORE = ON
GO
ALTER DATABASE [Suli] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Suli]
GO
/****** Object:  Table [dbo].[Erettsegi]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Erettsegi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[SubjectId] [int] NULL,
	[Lvl] [tinyint] NULL,
 CONSTRAINT [PK__Erettseg__3214EC07511E08EB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hianyzas]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hianyzas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[DateFrom] [datetime] NULL,
	[DateTo] [datetime] NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK__Hianyzas__3214EC0747173238] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Replies]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Replies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderUserId] [uniqueidentifier] NULL,
	[TaskId] [int] NULL,
	[MessageContent] [nvarchar](max) NULL,
 CONSTRAINT [PK__Replies__3214EC072989D664] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK__Roles__3214EC0705169387] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentData]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Class] [varchar](5) NULL,
	[Address] [nvarchar](50) NULL,
	[ZIP] [int] NULL,
	[OM_Number] [int] NULL,
	[UserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK__StudentD__3214EC07013E511D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK__Subject__3214EC07655E1897] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[TaskTypeId] [int] NULL,
	[ReportDate] [datetime] NULL,
	[Message] [nvarchar](max) NULL,
	[SenderUserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK__Tasks__3214EC07C4E9A7ED] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskType]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK__TaskType__3214EC0720649C98] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskTypeRoles]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskTypeRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskTypeId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK__TaskType__3214EC0749D36134] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2026. 02. 24. 10:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [varchar](100) NULL,
	[RoleId] [int] NULL,
	[PhoneNumber] [varchar](12) NULL,
	[Password] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Erettsegi] ON 
GO
INSERT [dbo].[Erettsegi] ([Id], [UserId], [SubjectId], [Lvl]) VALUES (1, N'263a1885-79ef-4bd5-9c69-2b7d6095419e', 5, 1)
GO
INSERT [dbo].[Erettsegi] ([Id], [UserId], [SubjectId], [Lvl]) VALUES (2, N'263a1885-79ef-4bd5-9c69-2b7d6095419e', 4, 1)
GO
INSERT [dbo].[Erettsegi] ([Id], [UserId], [SubjectId], [Lvl]) VALUES (3, N'263a1885-79ef-4bd5-9c69-2b7d6095419e', 2, 1)
GO
INSERT [dbo].[Erettsegi] ([Id], [UserId], [SubjectId], [Lvl]) VALUES (4, N'263a1885-79ef-4bd5-9c69-2b7d6095419e', 3, 2)
GO
SET IDENTITY_INSERT [dbo].[Erettsegi] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Diák')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'Osztályfőnök')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (3, N'Igazgatóhelyettes')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (4, N'Szakképzésvezető')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (5, N'Igazgató')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (6, N'GazdaságiTitkár')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (7, N'Titkár')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (8, N'Könyvtáros')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (9, N'Admin')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (1, N'Matematika')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (2, N'Történelem')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (3, N'Digitális Kultúra')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (4, N'Magyar Nyelv')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (5, N'Angol')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (6, N'Német')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (7, N'Földrajz')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (8, N'Japán')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (9, N'Testnevelés')
GO
INSERT [dbo].[Subject] ([Id], [Name]) VALUES (10, N'Fizika')
GO
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskType] ON 
GO
INSERT [dbo].[TaskType] ([Id], [Type]) VALUES (1, N'Iskolalátogatási igazolás magyar')
GO
INSERT [dbo].[TaskType] ([Id], [Type]) VALUES (2, N'Jogviszony igazolás
')
GO
INSERT [dbo].[TaskType] ([Id], [Type]) VALUES (3, N'MÁK igazolás/ árvasági dokumentum
')
GO
INSERT [dbo].[TaskType] ([Id], [Type]) VALUES (4, N'érettségi vizsga adatbegyűjtés
')
GO
INSERT [dbo].[TaskType] ([Id], [Type]) VALUES (5, N'lakcím adatok változásának bejelentése
')
GO
INSERT [dbo].[TaskType] ([Id], [Type]) VALUES (6, N'korábbi érettségi vizsgák törzslap másolata
')
GO
INSERT [dbo].[TaskType] ([Id], [Type]) VALUES (7, N'Iskolalátogatási igazolás német')
GO
SET IDENTITY_INSERT [dbo].[TaskType] OFF
GO
INSERT [dbo].[Users] ([Id], [FirstName], [MiddleName], [LastName], [Email], [RoleId], [PhoneNumber], [Password]) VALUES (N'263a1885-79ef-4bd5-9c69-2b7d6095419e', N'Dániel', NULL, N'Flórián', N'dangyusz@gmail.com', 1, N'+36301631780', NULL)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [MiddleName], [LastName], [Email], [RoleId], [PhoneNumber], [Password]) VALUES (N'da308cc4-d377-4afa-a609-2da7603e9fae', N'Eszter', NULL, N'Sudár', N'sudareszti@gmail.com', 3, N'+36406438574', NULL)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [MiddleName], [LastName], [Email], [RoleId], [PhoneNumber], [Password]) VALUES (N'b6db1d5f-51a4-45d6-9cb6-54cbe5be493f', N'Gergely', N'Tamás', N'Lendvai', N'tomika@gmail.com', 1, N'+36307549352', NULL)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [MiddleName], [LastName], [Email], [RoleId], [PhoneNumber], [Password]) VALUES (N'7e07f0aa-40ca-4861-b393-8d860a8b3b56', N'András', N'Márton', N'Dorogi', N'marci.dorogi@gmail.com', 1, N'+36303654286', N'')
GO
INSERT [dbo].[Users] ([Id], [FirstName], [MiddleName], [LastName], [Email], [RoleId], [PhoneNumber], [Password]) VALUES (N'81b81de7-1324-4471-a9b6-90794fc52336', N'Ildikó', NULL, N'Pék', N'ildiko@gmail.com', 7, N'+36508536853', NULL)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [MiddleName], [LastName], [Email], [RoleId], [PhoneNumber], [Password]) VALUES (N'a5c154a3-4183-4f74-ba7b-d3429125c45e', N'Kornél', N'"The"', N'Dorner', N'igo@gmail.com', 5, N'+36201231234', NULL)
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Erettsegi]  WITH CHECK ADD  CONSTRAINT [FK__Erettsegi__Subje__5DCAEF64] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Erettsegi] CHECK CONSTRAINT [FK__Erettsegi__Subje__5DCAEF64]
GO
ALTER TABLE [dbo].[Erettsegi]  WITH CHECK ADD  CONSTRAINT [FK__Erettsegi__UserI__5EBF139D] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Erettsegi] CHECK CONSTRAINT [FK__Erettsegi__UserI__5EBF139D]
GO
ALTER TABLE [dbo].[Hianyzas]  WITH CHECK ADD  CONSTRAINT [FK__Hianyzas__UserId__5BE2A6F2] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Hianyzas] CHECK CONSTRAINT [FK__Hianyzas__UserId__5BE2A6F2]
GO
ALTER TABLE [dbo].[Replies]  WITH CHECK ADD  CONSTRAINT [FK__Replies__SenderU__628FA481] FOREIGN KEY([SenderUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Replies] CHECK CONSTRAINT [FK__Replies__SenderU__628FA481]
GO
ALTER TABLE [dbo].[Replies]  WITH CHECK ADD  CONSTRAINT [FK__Replies__TaskId__6383C8BA] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
ALTER TABLE [dbo].[Replies] CHECK CONSTRAINT [FK__Replies__TaskId__6383C8BA]
GO
ALTER TABLE [dbo].[StudentData]  WITH CHECK ADD  CONSTRAINT [FK__StudentDa__UserI__5FB337D6] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[StudentData] CHECK CONSTRAINT [FK__StudentDa__UserI__5FB337D6]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK__Tasks__SenderUse__619B8048] FOREIGN KEY([SenderUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK__Tasks__SenderUse__619B8048]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK__Tasks__TaskTypeI__60A75C0F] FOREIGN KEY([TaskTypeId])
REFERENCES [dbo].[TaskType] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK__Tasks__TaskTypeI__60A75C0F]
GO
ALTER TABLE [dbo].[TaskTypeRoles]  WITH CHECK ADD  CONSTRAINT [FK__TaskTypeR__RoleI__656C112C] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[TaskTypeRoles] CHECK CONSTRAINT [FK__TaskTypeR__RoleI__656C112C]
GO
ALTER TABLE [dbo].[TaskTypeRoles]  WITH CHECK ADD  CONSTRAINT [FK__TaskTypeR__TaskT__6477ECF3] FOREIGN KEY([TaskTypeId])
REFERENCES [dbo].[TaskType] ([Id])
GO
ALTER TABLE [dbo].[TaskTypeRoles] CHECK CONSTRAINT [FK__TaskTypeR__TaskT__6477ECF3]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleId__5CD6CB2B] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleId__5CD6CB2B]
GO
USE [master]
GO
ALTER DATABASE [Suli] SET  READ_WRITE 
GO
