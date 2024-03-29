--Final db
USE [master]
GO
/****** Object:  Database [PRN221_Project_QLNS]    Script Date: 23/3/2023 1:45:50 PM ******/
CREATE DATABASE [PRN221_Project_QLNS]
 CONTAINMENT = NONE
GO
ALTER DATABASE [PRN221_Project_QLNS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN221_Project_QLNS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN221_Project_QLNS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET  MULTI_USER 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN221_Project_QLNS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN221_Project_QLNS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN221_Project_QLNS', N'ON'
GO
ALTER DATABASE [PRN221_Project_QLNS] SET QUERY_STORE = OFF
GO
USE [PRN221_Project_QLNS]
GO
/****** Object:  Table [dbo].[account]    Script Date: 23/3/2023 1:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[isadmin] [bit] NOT NULL,
	[ismanager] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HubConnection]    Script Date: 23/3/2023 1:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HubConnection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConnectionId] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
 CONSTRAINT [PK_HubConnection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 23/3/2023 1:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Message] [varchar](1000) NOT NULL,
	[MessageType] [varchar](50) NOT NULL,
	[NotificationDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profile]    Script Date: 23/3/2023 1:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profile](
	[profile_id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[first_name] [varchar](20) NOT NULL,
	[last_name] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone_number] [varchar](20) NULL,
	[hire_date] [varchar](20) NOT NULL,
	[job] [varchar](40) NOT NULL,
	[report_to] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[task]    Script Date: 23/3/2023 1:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[task](
	[task_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](35) NOT NULL,
	[description] [varchar](max) NOT NULL,
	[deadline] [date] NULL,
	[status] [int] NULL,
	[assigned] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[task_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[account] ON 

INSERT [dbo].[account] ([account_id], [username], [password], [isadmin], [ismanager]) VALUES (1, N'admin', N'admin', 1, 0)
INSERT [dbo].[account] ([account_id], [username], [password], [isadmin], [ismanager]) VALUES (2, N'M3ijn', N'123456', 0, 1)
INSERT [dbo].[account] ([account_id], [username], [password], [isadmin], [ismanager]) VALUES (3, N'khanhndn0811', N'123456', 0, 0)
INSERT [dbo].[account] ([account_id], [username], [password], [isadmin], [ismanager]) VALUES (4, N'lu', N'123456', 0, 0)
SET IDENTITY_INSERT [dbo].[account] OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (1, N'M3ijn', N'ok', N'All', CAST(N'2023-03-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (2, N'M3ijn', N'ok', N'All', CAST(N'2023-03-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (3, N'all', N'ok', N'All', CAST(N'2023-03-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (4, N'all', N'ok', N'All', CAST(N'2023-03-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (5, N'all', N'ok', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (7, N'all', N'ok', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (8, N'all', N'ok', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (9, N'all', N'ok', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (10, N'all', N'iiiiiiiiiiii', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (11, N'all', N'chao moi nguoi', N'All', CAST(N'2023-03-23T09:11:56.880' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (12, N'all', N'chao moi nguoi', N'All', CAST(N'2023-03-23T09:17:18.393' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (13, N'all', N'allllllllllllllll', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (14, N'all', N'lllllllla', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (15, N'all', N'laaaaaa', N'All', CAST(N'2023-03-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (16, N'all', N'chao moi nguoi', N'All', CAST(N'2023-03-23T09:21:49.087' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (17, N'khanhndn0811', N'Pending New lunguyen2', N'Personal', CAST(N'2023-03-23T09:30:15.003' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (18, N'khanhndn0811', N'Pending New lunguyen2', N'Personal', CAST(N'2023-03-23T09:32:20.907' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (19, N'khanhndn0811', N'Pending New ludddd', N'Personal', CAST(N'2023-03-23T09:34:52.947' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (20, N'khanhndn0811', N'Pending New lunguyen22222222', N'Personal', CAST(N'2023-03-23T09:43:12.810' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (21, N'khanhndn0811', N'Pending New lunguyen2', N'Personal', CAST(N'2023-03-23T09:49:31.520' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (22, N'lu', N'123', N'All', CAST(N'2023-03-23T11:13:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (23, N'lu', N'heeeeeeeeeeeeeeeee', N'Personal', CAST(N'2023-03-23T11:13:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (24, N'lu', N'heeeeeeeeeeeeeeeee2222', N'Personal', CAST(N'2023-03-23T11:16:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (26, N'lu', N'122222', N'Personal', CAST(N'2023-03-23T11:17:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (27, N'lu', N'heeeeeeeeeeeeeeeee1111', N'Personal', CAST(N'2023-03-23T11:20:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (28, N'lu', N'heeeeeeeeeeeeeeeee22222222222', N'Personal', CAST(N'2023-03-23T11:40:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (29, N'lu', N'123', N'All', CAST(N'2023-03-23T11:40:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (31, N'lu', N'heeeeeeeeeeeeeeeee1111', N'All', CAST(N'2023-03-23T11:43:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (32, N'lu', N'heeeeeeeeeeeeeeeee1111', N'Personal', CAST(N'2023-03-23T11:45:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (33, N'lu', N'heeeeeeeeeeeeeeeee2222', N'Personal', CAST(N'2023-03-23T11:48:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (34, N'lu', N'heeeeeeeeeeeeeeeee22222222222', N'Personal', CAST(N'2023-03-23T11:49:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (35, N'lu', N'123', N'All', CAST(N'2023-03-24T11:49:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (36, N'lu', N'heeeeeeeeeeeeeeeee1111', N'Personal', CAST(N'2023-03-23T11:53:00.000' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (37, N'khanhndn0811', N'Pending New lunguyen2', N'Personal', CAST(N'2023-03-23T12:09:37.320' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (38, N'khanhndn0811', N'Pending New lunguyen2', N'Personal', CAST(N'2023-03-23T12:12:44.630' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (39, N'khanhndn0811', N'Pending New lunguyen2', N'Personal', CAST(N'2023-03-23T12:27:39.980' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (40, N'khanhndn0811', N'Pending New lunguyen2122121', N'Personal', CAST(N'2023-03-23T13:27:04.327' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (41, N'khanhndn0811', N'Pending New lunguyen2212', N'Personal', CAST(N'2023-03-23T13:34:35.153' AS DateTime))
INSERT [dbo].[Notification] ([Id], [Username], [Message], [MessageType], [NotificationDateTime]) VALUES (42, N'khanhndn0811', N'Pending New lunguyen211111', N'Personal', CAST(N'2023-03-23T13:42:24.913' AS DateTime))
SET IDENTITY_INSERT [dbo].[Notification] OFF
GO
SET IDENTITY_INSERT [dbo].[profile] ON 

INSERT [dbo].[profile] ([profile_id], [account_id], [first_name], [last_name], [email], [phone_number], [hire_date], [job], [report_to]) VALUES (1, 2, N'Tran', N'Trieu', N'trantrieu@gmail.com', N'123456', N'01/01/2020', N'Department Head', NULL)
INSERT [dbo].[profile] ([profile_id], [account_id], [first_name], [last_name], [email], [phone_number], [hire_date], [job], [report_to]) VALUES (2, 3, N'Nguyen', N'Khanh', N'namkhanh@gmail.com', N'123456', N'01/01/2023', N'Junior Dev', 2)
INSERT [dbo].[profile] ([profile_id], [account_id], [first_name], [last_name], [email], [phone_number], [hire_date], [job], [report_to]) VALUES (3, 4, N'lu2', N'lu', N'lunguyen2k18@gmail.com', N'123456', N'22/03/2023', N'lu', 1)
SET IDENTITY_INSERT [dbo].[profile] OFF
GO
SET IDENTITY_INSERT [dbo].[task] ON 

INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (3, N'CRUD', N'CRUD employee list', CAST(N'2023-04-30' AS Date), 3, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (4, N'Fix bug', N'Fix new list will not load after CRUD', CAST(N'2023-04-30' AS Date), 2, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (5, N'Modify UI', N'Divide task board by color', CAST(N'2023-04-19' AS Date), 2, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (6, N'Create UI', N'Create Employee List UI', CAST(N'2023-04-13' AS Date), 3, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (7, N'lu', N'ok', CAST(N'2023-02-27' AS Date), 2, 1)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (8, N'21', N'21', CAST(N'2023-03-07' AS Date), 2, 1)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (9, N'lunguyen2', N'54', CAST(N'2023-03-01' AS Date), 1, 1)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (10, N'java', N'java', CAST(N'2023-03-21' AS Date), 1, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (11, N'LU2', N' ok', CAST(N'2023-02-28' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (12, N'ok', N'hh', CAST(N'2023-03-23' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (13, N'lu2222', N'ok', CAST(N'2023-03-24' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (14, N'lunguyen2', N'22222222222222222', CAST(N'2023-03-23' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (15, N'lunguyen2222222', N'2222222222', CAST(N'2023-03-24' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (16, N'lunguyen2', N'okkkkkkkkk', CAST(N'2023-02-28' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (17, N'lunguyen2', N'okkkkkkkkk', CAST(N'2023-03-24' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (18, N'ludddd', N'dddddddd', CAST(N'2023-03-24' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (19, N'lunguyen22222222', N'22222222222222222222', CAST(N'2023-03-24' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (20, N'lunguyen2', N'ok', CAST(N'2023-03-25' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (21, N'lunguyen2', N'okkkkkkkkkkkk', CAST(N'2023-03-24' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (22, N'lunguyen2', N'okk', CAST(N'2023-03-23' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (23, N'lunguyen2', N'ok', CAST(N'2023-03-23' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (24, N'lunguyen2', N'ok', CAST(N'2023-03-24' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (25, N'lunguyen2122121', N'21', CAST(N'2023-03-23' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (26, N'lunguyen2212', N'1212', CAST(N'2023-03-23' AS Date), 0, 2)
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (27, N'lunguyen211111', N'21', CAST(N'2023-03-23' AS Date), 0, 2)
SET IDENTITY_INSERT [dbo].[task] OFF
GO
ALTER TABLE [dbo].[profile]  WITH CHECK ADD FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([account_id])
GO
ALTER TABLE [dbo].[profile]  WITH CHECK ADD FOREIGN KEY([report_to])
REFERENCES [dbo].[profile] ([profile_id])
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD FOREIGN KEY([assigned])
REFERENCES [dbo].[profile] ([profile_id])
GO
/****** Object:  StoredProcedure [dbo].[dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_QueueActivationSender]    Script Date: 23/3/2023 1:45:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_QueueActivationSender] 
WITH EXECUTE AS SELF
AS 
BEGIN 
    SET NOCOUNT ON;
    DECLARE @h AS UNIQUEIDENTIFIER;
    DECLARE @mt NVARCHAR(200);

    RECEIVE TOP(1) @h = conversation_handle, @mt = message_type_name FROM [dbo].[dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender];

    IF @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog'
    BEGIN
        END CONVERSATION @h;
    END

    IF @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer' OR @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/Error'
    BEGIN 
        

        END CONVERSATION @h;

        DECLARE @conversation_handle UNIQUEIDENTIFIER;
        DECLARE @schema_id INT;
        SELECT @schema_id = schema_id FROM sys.schemas WITH (NOLOCK) WHERE name = N'dbo';

        
        IF EXISTS (SELECT * FROM sys.triggers WITH (NOLOCK) WHERE object_id = OBJECT_ID(N'[dbo].[tr_dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender]')) DROP TRIGGER [dbo].[tr_dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender') EXEC (N'ALTER QUEUE [dbo].[dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender] WITH ACTIVATION (STATUS = OFF)');

        
        SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoints WITH (NOLOCK) WHERE far_service LIKE N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_%' ORDER BY is_initiator ASC;
        DECLARE conversation_cursor CURSOR FAST_FORWARD FOR SELECT conversation_handle FROM #Conversations;
        OPEN conversation_cursor;
        FETCH NEXT FROM conversation_cursor INTO @conversation_handle;
        WHILE @@FETCH_STATUS = 0 
        BEGIN
            END CONVERSATION @conversation_handle WITH CLEANUP;
            FETCH NEXT FROM conversation_cursor INTO @conversation_handle;
        END
        CLOSE conversation_cursor;
        DEALLOCATE conversation_cursor;
        DROP TABLE #Conversations;

        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Receiver') DROP SERVICE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Receiver];
        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender') DROP SERVICE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Receiver') DROP QUEUE [dbo].[dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Receiver];
        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender') DROP QUEUE [dbo].[dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_contracts WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f') DROP CONTRACT [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f];
        
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/StartMessage/Insert') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/StartMessage/Insert];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/StartMessage/Update') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/StartMessage/Update];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/StartMessage/Delete') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/StartMessage/Delete];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/Id') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/Id];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/Username') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/Username];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/Message') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/Message];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/MessageType') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/MessageType];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/NotificationDateTime') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/NotificationDateTime];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/EndMessage') DROP MESSAGE TYPE [dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f/EndMessage];

        
        IF EXISTS (SELECT * FROM sys.objects WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_QueueActivationSender') DROP PROCEDURE [dbo].[dbo_Notification_364d1331-9e73-42d8-bbcd-a6e78757fe3f_QueueActivationSender];

        
    END
END
GO
USE [master]
GO
ALTER DATABASE [PRN221_Project_QLNS] SET  READ_WRITE 
GO
