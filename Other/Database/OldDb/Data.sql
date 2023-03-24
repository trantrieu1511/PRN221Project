USE [PRN221_Project_QLNS]
GO
SET IDENTITY_INSERT [dbo].[account] ON 
GO
INSERT [dbo].[account] ([account_id], [username], [password], [isadmin], [ismanager]) VALUES (1, N'admin', N'admin', 1, 0)
GO
INSERT [dbo].[account] ([account_id], [username], [password], [isadmin], [ismanager]) VALUES (2, N'M3ijn', N'123456', 0, 1)
GO
INSERT [dbo].[account] ([account_id], [username], [password], [isadmin], [ismanager]) VALUES (3, N'khanhndn0811', N'123456', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[account] OFF
GO
SET IDENTITY_INSERT [dbo].[profile] ON 
GO
INSERT [dbo].[profile] ([profile_id], [account_id], [first_name], [last_name], [email], [phone_number], [hire_date], [job], [report_to]) VALUES (1, 2, N'Tran', N'Trieu', N'trantrieu@gmail.com', N'123456', N'01/01/2020', N'Department Head', NULL)
GO
INSERT [dbo].[profile] ([profile_id], [account_id], [first_name], [last_name], [email], [phone_number], [hire_date], [job], [report_to]) VALUES (2, 3, N'Nguyen', N'Khanh', N'namkhanh@gmail.com', N'123456', N'01/01/2023', N'Junior Dev', 2)
GO
SET IDENTITY_INSERT [dbo].[profile] OFF
GO
SET IDENTITY_INSERT [dbo].[task] ON 
GO
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (3, N'CRUD', N'CRUD employee list', CAST(N'2023-04-30' AS Date), 0, 2)
GO
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (4, N'Fix bug', N'Fix new list will not load after CRUD', CAST(N'2023-04-30' AS Date), 1, 2)
GO
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (5, N'Modify UI', N'Divide task board by color', CAST(N'2023-04-19' AS Date), 2, 2)
GO
INSERT [dbo].[task] ([task_id], [name], [description], [deadline], [status], [assigned]) VALUES (6, N'Create UI', N'Create Employee List UI', CAST(N'2023-04-13' AS Date), 3, 2)
GO
SET IDENTITY_INSERT [dbo].[task] OFF
GO
