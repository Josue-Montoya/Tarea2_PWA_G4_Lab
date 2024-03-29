USE [master]
GO
/****** Object:  Database [TransilvaniaHotels]    Script Date: 25/2/2024 18:10:44 ******/
CREATE DATABASE [TransilvaniaHotels]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TransilvaniaHotels', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.U20210157JM\MSSQL\DATA\TransilvaniaHotels.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TransilvaniaHotels_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.U20210157JM\MSSQL\DATA\TransilvaniaHotels_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TransilvaniaHotels] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TransilvaniaHotels].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TransilvaniaHotels] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET ARITHABORT OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TransilvaniaHotels] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TransilvaniaHotels] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TransilvaniaHotels] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TransilvaniaHotels] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET RECOVERY FULL 
GO
ALTER DATABASE [TransilvaniaHotels] SET  MULTI_USER 
GO
ALTER DATABASE [TransilvaniaHotels] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TransilvaniaHotels] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TransilvaniaHotels] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TransilvaniaHotels] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TransilvaniaHotels] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TransilvaniaHotels] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TransilvaniaHotels', N'ON'
GO
ALTER DATABASE [TransilvaniaHotels] SET QUERY_STORE = ON
GO
ALTER DATABASE [TransilvaniaHotels] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TransilvaniaHotels]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 25/2/2024 18:10:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[clientId] [int] IDENTITY(1,1) NOT NULL,
	[clientName] [varchar](50) NOT NULL,
	[clientEmail] [varchar](50) NOT NULL,
	[clientPhone] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 25/2/2024 18:10:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[hotelId] [int] IDENTITY(1,1) NOT NULL,
	[hotelName] [varchar](50) NOT NULL,
	[hotelStars] [int] NOT NULL,
	[hotelAddress] [varchar](50) NOT NULL,
	[hotelPhone] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[hotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 25/2/2024 18:10:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[reservationId] [int] IDENTITY(1,1) NOT NULL,
	[startDate] [varchar](20) NOT NULL,
	[endDate] [varchar](20) NOT NULL,
	[roomId] [int] NULL,
	[clientId] [int] NOT NULL,
	[reservationPrice] [money] NOT NULL,
	[paidReservation] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[reservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 25/2/2024 18:10:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomId] [int] IDENTITY(1,1) NOT NULL,
	[roomNumber] [varchar](10) NOT NULL,
	[roomType] [varchar](20) NOT NULL,
	[roomPrice] [money] NOT NULL,
	[hotelId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([clientId], [clientName], [clientEmail], [clientPhone]) VALUES (1, N'John Doe', N'johndoe@example.com', N'555-111-2222')
INSERT [dbo].[Client] ([clientId], [clientName], [clientEmail], [clientPhone]) VALUES (2, N'Jane Smith', N'janesmith@example.com', N'555-333-4444')
INSERT [dbo].[Client] ([clientId], [clientName], [clientEmail], [clientPhone]) VALUES (3, N'Michael Johnson', N'michaeljohnson@example.com', N'555-555-6666')
INSERT [dbo].[Client] ([clientId], [clientName], [clientEmail], [clientPhone]) VALUES (4, N'Emily Brown', N'emilybrown@example.com', N'555-777-8888')
INSERT [dbo].[Client] ([clientId], [clientName], [clientEmail], [clientPhone]) VALUES (5, N'David Wilson', N'davidwilson@example.com', N'555-999-0000')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([hotelId], [hotelName], [hotelStars], [hotelAddress], [hotelPhone]) VALUES (1, N'Hotel Bella Vista', 2, N'La Presita', N'7865-2003')
INSERT [dbo].[Hotel] ([hotelId], [hotelName], [hotelStars], [hotelAddress], [hotelPhone]) VALUES (2, N'Grand Hotel Lumière', 5, N'456 Elm Street', N'555-987-6543')
INSERT [dbo].[Hotel] ([hotelId], [hotelName], [hotelStars], [hotelAddress], [hotelPhone]) VALUES (3, N'Hotel Montaña Azul', 3, N'789 Oak Street', N'555-321-6789')
INSERT [dbo].[Hotel] ([hotelId], [hotelName], [hotelStars], [hotelAddress], [hotelPhone]) VALUES (5, N'Hotel del Bosque', 5, N'202 Maple Street', N'555-789-0123')
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([reservationId], [startDate], [endDate], [roomId], [clientId], [reservationPrice], [paidReservation]) VALUES (1, N'2024-03-01', N'2024-03-05', 1, 1, 200.0000, N'Yes')
INSERT [dbo].[Reservation] ([reservationId], [startDate], [endDate], [roomId], [clientId], [reservationPrice], [paidReservation]) VALUES (2, N'2024-04-15', N'2024-04-20', 2, 2, 400.0000, N'No')
INSERT [dbo].[Reservation] ([reservationId], [startDate], [endDate], [roomId], [clientId], [reservationPrice], [paidReservation]) VALUES (3, N'2024-05-10', N'2024-05-15', 3, 3, 300.0000, N'Yes')
INSERT [dbo].[Reservation] ([reservationId], [startDate], [endDate], [roomId], [clientId], [reservationPrice], [paidReservation]) VALUES (4, N'2024-06-20', N'2024-06-25', 4, 4, 500.0000, N'Yes')
INSERT [dbo].[Reservation] ([reservationId], [startDate], [endDate], [roomId], [clientId], [reservationPrice], [paidReservation]) VALUES (5, N'2024-07-05', N'2024-07-10', 5, 5, 250.0000, N'No')
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([roomId], [roomNumber], [roomType], [roomPrice], [hotelId]) VALUES (1, N'101', N'Individual', 50.0000, 1)
INSERT [dbo].[Room] ([roomId], [roomNumber], [roomType], [roomPrice], [hotelId]) VALUES (2, N'102', N'Doble', 80.0000, 1)
INSERT [dbo].[Room] ([roomId], [roomNumber], [roomType], [roomPrice], [hotelId]) VALUES (3, N'201', N'Individual', 60.0000, 2)
INSERT [dbo].[Room] ([roomId], [roomNumber], [roomType], [roomPrice], [hotelId]) VALUES (4, N'202', N'Doble', 100.0000, 2)
INSERT [dbo].[Room] ([roomId], [roomNumber], [roomType], [roomPrice], [hotelId]) VALUES (5, N'301', N'Suite', 40.0000, 3)
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD FOREIGN KEY([clientId])
REFERENCES [dbo].[Client] ([clientId])
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD FOREIGN KEY([roomId])
REFERENCES [dbo].[Room] ([roomId])
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([hotelId])
REFERENCES [dbo].[Hotel] ([hotelId])
GO
USE [master]
GO
ALTER DATABASE [TransilvaniaHotels] SET  READ_WRITE 
GO
