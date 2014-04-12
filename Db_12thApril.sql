USE [KanakTiffins]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 12-04-2014 03:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[AreaId] [int] NOT NULL,
	[AreaName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 12-04-2014 03:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[CustomerId] [int] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NOT NULL,
	[PhoneNumber] [nvarchar](15) NOT NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[DepositAmount] [int] NULL,
	[AreaId] [int] NOT NULL,
	[MealPlanId] [int] NOT NULL,
	[LunchOrDinnerId] [int] NOT NULL,
	[DabbawalaCharges] [int] NOT NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerDues]    Script Date: 12-04-2014 03:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDues](
	[CustomerId] [int] NOT NULL,
	[DueAmount] [int] NOT NULL,
	[CarryforwardAmount] [int] NOT NULL,
 CONSTRAINT [PK_CustomerDues] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerPaymentHistory]    Script Date: 12-04-2014 03:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerPaymentHistory](
	[CustomerId] [int] NOT NULL,
	[PaidAmount] [int] NOT NULL,
	[PaidOn] [datetime] NOT NULL,
	[PaymentMethod] [varchar](50) NULL,
 CONSTRAINT [PK_CustomerPaymentHistory] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[PaidOn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LunchOrDinner]    Script Date: 12-04-2014 03:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LunchOrDinner](
	[Id] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_LunchOrDinner_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MealPlans]    Script Date: 12-04-2014 03:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MealPlans](
	[MealPlanId] [int] NOT NULL,
	[MealAmount] [int] NOT NULL,
	[MealDescription] [varchar](1000) NULL,
 CONSTRAINT [PK_MealPlans] PRIMARY KEY CLUSTERED 
(
	[MealPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MonthlyBills]    Script Date: 12-04-2014 03:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthlyBills](
	[CustomerId] [int] NOT NULL,
	[DateTaken] [date] NOT NULL,
	[LunchAmount] [int] NOT NULL,
	[DinnerAmount] [int] NOT NULL,
	[Comments] [nvarchar](50) NULL,
	[DailyPayment] [int] NOT NULL,
 CONSTRAINT [PK_MonthlyBills] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[DateTaken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (1, N'Sion')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (2, N'Wadala')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (3, N'King''s Circle')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (4, N'Runwal')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (5, N'Seepz')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (6, N'Matunga')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (7, N'Dharavi')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (8, N'Thane')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (9, N'Kurla')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (10, N'Vashi')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (12, N'Ghatkopar')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DabbawalaCharges]) VALUES (1, N'Prachi', N'', N'Shiv Niwas Sion Mumbai ', N'9768925265', N'prachi@gmail.com', 0, 12, 2, 1, 200)
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DabbawalaCharges]) VALUES (2, N'Spruha', N'', N'Shiv Niwas Sion Mumbai', N'8879487583', N'spruha@gmail.com', 0, 1, 2, 0, 0)
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DabbawalaCharges]) VALUES (3, N'Rajesh', N'Devikar', N'Sion', N'9930196252', N'', 0, 1, 1, 0, 0)
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DabbawalaCharges]) VALUES (5, N'Balaji', N'Iyengar', N'Vashi', N'9769974346', N'devitsfangs@gmail.com', NULL, 5, 3, 0, 0)
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DabbawalaCharges]) VALUES (6, N'Viral', N'Mehta', N'Marine Lines', N'12345678', N'viralm@kyunnox.com', 0, 5, 1, 0, 200)
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DabbawalaCharges]) VALUES (7, N'Rajesh', N'Vishwakarma', N'Kurla', N'0', N'rajvish@gmail.com', 0, 1, 3, 1, 200)
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DabbawalaCharges]) VALUES (8, N'Ashton', N'Mendes', N'Thane', N'9967443949', N'ashton.mendes@gmail.com', 1000, 5, 3, 1, 200)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (1, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (3, 1980, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (5, 0, 0)
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (0, N'Lunch & Dinner')
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (1, N'Lunch Only')
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (2, N'Dinner Only')
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (1, 45, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (2, 55, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (3, 65, NULL)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x3C380B00 AS Date), 55, 0, N'march taking', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x3D380B00 AS Date), 55, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x3E380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x3F380B00 AS Date), 0, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x40380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x41380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x42380B00 AS Date), 0, 55, N'', 55)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x43380B00 AS Date), 55, 55, N'', 55)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x44380B00 AS Date), 45, 45, N'', 100)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x45380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x46380B00 AS Date), 45, 45, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x47380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x48380B00 AS Date), 55, 55, N'', 125)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x49380B00 AS Date), 0, 55, N'', 200)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x4A380B00 AS Date), 65, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x4B380B00 AS Date), 55, 0, N'', 50)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x4C380B00 AS Date), 45, 55, N'', 100)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x4D380B00 AS Date), 0, 55, N'', 50)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x4E380B00 AS Date), 55, 45, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x4F380B00 AS Date), 45, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x50380B00 AS Date), 55, 45, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x51380B00 AS Date), 45, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x52380B00 AS Date), 0, 45, N'', 100)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x53380B00 AS Date), 0, 55, N'', 20)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x54380B00 AS Date), 45, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x55380B00 AS Date), 0, 65, N'', 20)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x56380B00 AS Date), 55, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x57380B00 AS Date), 0, 0, N'', 100)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x58380B00 AS Date), 0, 0, N'', 100)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x59380B00 AS Date), 55, 45, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5A380B00 AS Date), 55, 0, N'', 100)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5B380B00 AS Date), 55, 55, N'taking tiffin', 55)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5C380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5D380B00 AS Date), 55, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5E380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5F380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x60380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x61380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x62380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x63380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x64380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x65380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x66380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x67380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x68380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x69380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6A380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6B380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6C380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6D380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6E380B00 AS Date), 0, 0, N'', 5000)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6F380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x70380B00 AS Date), 85, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x71380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x72380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x73380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x74380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x75380B00 AS Date), 0, 0, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x76380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x77380B00 AS Date), 55, 55, N'', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x78380B00 AS Date), 55, 55, N'Didn''t like the service, wants refund', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x5B380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x5C380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x5D380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x5E380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x5F380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x60380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x61380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x62380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x63380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x64380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x65380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x66380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x67380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x68380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x69380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x6A380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x6B380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x6C380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x6D380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x6E380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x6F380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x70380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x71380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x72380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x73380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x74380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x75380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x76380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x77380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (2, CAST(0x78380B00 AS Date), 55, 55, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5B380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5C380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5D380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5E380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5F380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x60380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x61380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x62380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x63380B00 AS Date), 45, 45, NULL, 0)
GO
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x64380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x65380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x66380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x67380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x68380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x69380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6A380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6B380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6C380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6D380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6E380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6F380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x70380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x71380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x72380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x73380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x74380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x75380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x76380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x77380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x78380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x5B380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x5C380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x5D380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x5E380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x5F380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x60380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x61380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x62380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x63380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x64380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x65380B00 AS Date), 65, 65, NULL, 200)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x66380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x67380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x68380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x69380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x6A380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x6B380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x6C380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x6D380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x6E380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x6F380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x70380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x71380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x72380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x73380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x74380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x75380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x76380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x77380B00 AS Date), 65, 65, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (5, CAST(0x78380B00 AS Date), 65, 65, NULL, 0)
ALTER TABLE [dbo].[CustomerDetails] ADD  CONSTRAINT [DF_CustomerDetails_DepositAmount]  DEFAULT ((0)) FOR [DepositAmount]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  DEFAULT ((0)) FOR [LunchOrDinnerId]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  DEFAULT ((0)) FOR [DabbawalaCharges]
GO
ALTER TABLE [dbo].[CustomerDues] ADD  CONSTRAINT [DF_CustomerDues_DueAmount]  DEFAULT ((0)) FOR [DueAmount]
GO
ALTER TABLE [dbo].[CustomerDues] ADD  CONSTRAINT [DF_CustomerDues_CarryforwardAmount]  DEFAULT ((0)) FOR [CarryforwardAmount]
GO
ALTER TABLE [dbo].[CustomerPaymentHistory] ADD  CONSTRAINT [DF_CustomerPaymentHistory_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[LunchOrDinner] ADD  CONSTRAINT [DF_LunchOrDinner_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[MealPlans] ADD  CONSTRAINT [DF_MealPlans_MealAmount]  DEFAULT ((0)) FOR [MealAmount]
GO
ALTER TABLE [dbo].[MonthlyBills] ADD  CONSTRAINT [DF_MonthlyBills_LunchAmount]  DEFAULT ((0)) FOR [LunchAmount]
GO
ALTER TABLE [dbo].[MonthlyBills] ADD  CONSTRAINT [DF_MonthlyBills_DinnerAmount]  DEFAULT ((0)) FOR [DinnerAmount]
GO
ALTER TABLE [dbo].[MonthlyBills] ADD  CONSTRAINT [DF_MonthlyBills_DailyPayment]  DEFAULT ((0)) FOR [DailyPayment]
GO
ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_Areas] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Areas] ([AreaId])
GO
ALTER TABLE [dbo].[CustomerDetails] CHECK CONSTRAINT [FK_CustomerDetails_Areas]
GO
ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_LunchOrDinner] FOREIGN KEY([LunchOrDinnerId])
REFERENCES [dbo].[LunchOrDinner] ([Id])
GO
ALTER TABLE [dbo].[CustomerDetails] CHECK CONSTRAINT [FK_CustomerDetails_LunchOrDinner]
GO
ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_MealPlans] FOREIGN KEY([MealPlanId])
REFERENCES [dbo].[MealPlans] ([MealPlanId])
GO
ALTER TABLE [dbo].[CustomerDetails] CHECK CONSTRAINT [FK_CustomerDetails_MealPlans]
GO
ALTER TABLE [dbo].[CustomerDues]  WITH CHECK ADD  CONSTRAINT [FK_BillingHistory_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerDues] CHECK CONSTRAINT [FK_BillingHistory_CustomerDetails]
GO
ALTER TABLE [dbo].[CustomerPaymentHistory]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPaymentHistory_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerPaymentHistory] CHECK CONSTRAINT [FK_CustomerPaymentHistory_CustomerDetails]
GO
ALTER TABLE [dbo].[MonthlyBills]  WITH CHECK ADD  CONSTRAINT [FK_MonthlyBills_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
ALTER TABLE [dbo].[MonthlyBills] CHECK CONSTRAINT [FK_MonthlyBills_CustomerDetails]
GO
