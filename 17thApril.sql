USE [KanakTiffins]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 17-04-2014 22:14:25 ******/
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
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 17-04-2014 22:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[DefaultDabbawalaCharges] [int] NOT NULL,
	[InitialBalance] [int] NOT NULL,
	[isDeleted] [char](1) NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerDues]    Script Date: 17-04-2014 22:14:25 ******/
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
/****** Object:  Table [dbo].[CustomerPaymentHistory]    Script Date: 17-04-2014 22:14:25 ******/
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
/****** Object:  Table [dbo].[ExtraCharges]    Script Date: 17-04-2014 22:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtraCharges](
	[CustomerId] [int] NOT NULL,
	[MonthId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[DabbawalaCharges] [int] NOT NULL,
	[DeliveryCharges] [int] NOT NULL,
 CONSTRAINT [PK_DabbawalaCharges] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[MonthId] ASC,
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LunchOrDinner]    Script Date: 17-04-2014 22:14:25 ******/
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
/****** Object:  Table [dbo].[MealPlans]    Script Date: 17-04-2014 22:14:25 ******/
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
/****** Object:  Table [dbo].[MonthlyBills]    Script Date: 17-04-2014 22:14:25 ******/
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
/****** Object:  Table [dbo].[Months]    Script Date: 17-04-2014 22:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Months](
	[MonthId] [int] NOT NULL,
	[MonthName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Months] PRIMARY KEY CLUSTERED 
(
	[MonthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (1, N'Sion')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (2, N'Wadala')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (3, N'King''s Circle')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (4, N'Runwal')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (5, N'Seepz')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (6, N'Matunga')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (8, N'Thane')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (9, N'Kurla')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (10, N'Vashi')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (12, N'Ghatkopar')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (13, N'Andheri')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (14, N'Malad')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (15, N'Mulund')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (16, N'Lalbaug')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (17, N'Parel')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (18, N'Byculla')
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (19, N'Mankhurd')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (1, N'Puja', N'Pandey', N'Shiv Nivas', N'9967943141', N'', 1000, 1, 2, 1, 100, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (2, N'', N'', N'', N'', N'', 0, 13, 1, 0, 0, 0, N'Y')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (3, N'Prathamesh', N'Sanki', N'', N'', N'', 0, 3, 1, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (1, 0, 3620)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (2, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (3, 980, 0)
INSERT [dbo].[CustomerPaymentHistory] ([CustomerId], [PaidAmount], [PaidOn], [PaymentMethod]) VALUES (1, 2000, CAST(0x0000A30100000000 AS DateTime), N'hdfc')
INSERT [dbo].[CustomerPaymentHistory] ([CustomerId], [PaidAmount], [PaidOn], [PaymentMethod]) VALUES (1, 2000, CAST(0x0000A30A00000000 AS DateTime), N'hdfc')
INSERT [dbo].[CustomerPaymentHistory] ([CustomerId], [PaidAmount], [PaidOn], [PaymentMethod]) VALUES (1, 2000, CAST(0x0000A30D00000000 AS DateTime), N'chotu')
INSERT [dbo].[CustomerPaymentHistory] ([CustomerId], [PaidAmount], [PaidOn], [PaymentMethod]) VALUES (3, 1000, CAST(0x0000A31000000000 AS DateTime), N'chotu')
INSERT [dbo].[ExtraCharges] ([CustomerId], [MonthId], [Year], [DabbawalaCharges], [DeliveryCharges]) VALUES (1, 4, 2014, 100, 200)
INSERT [dbo].[ExtraCharges] ([CustomerId], [MonthId], [Year], [DabbawalaCharges], [DeliveryCharges]) VALUES (1, 5, 2014, 100, 0)
INSERT [dbo].[ExtraCharges] ([CustomerId], [MonthId], [Year], [DabbawalaCharges], [DeliveryCharges]) VALUES (3, 4, 2014, 0, 0)
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (0, N'Lunch & Dinner')
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (1, N'Lunch Only')
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (2, N'Dinner Only')
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (1, 45, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (2, 55, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (3, 65, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (4, 75, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (5, 85, NULL)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5B380B00 AS Date), 55, 0, N'Started taking tiffin', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5C380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5D380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5E380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x5F380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x60380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x61380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x62380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x63380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x64380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x65380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x66380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x67380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x68380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x69380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6A380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6B380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6C380B00 AS Date), 55, 0, N'Stopped', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6D380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6E380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x6F380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x70380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x71380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x72380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x73380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x74380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x75380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x76380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x77380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x78380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x79380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x7A380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x7B380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x7C380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x7D380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x7E380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x7F380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x80380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x81380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x82380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x83380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x84380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x85380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x86380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x87380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x88380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x89380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x8A380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x8B380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x8C380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x8D380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x8E380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x8F380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x90380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x91380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x92380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x93380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x94380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x95380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x96380B00 AS Date), 55, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (1, CAST(0x97380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5B380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5C380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5D380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5E380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x5F380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x60380B00 AS Date), 0, 0, N'Sunday', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x61380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x62380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x63380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x64380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x65380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x66380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x67380B00 AS Date), 0, 0, N'Sunday', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x68380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x69380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6A380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6B380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6C380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6D380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6E380B00 AS Date), 0, 0, N'Sunday', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x6F380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x70380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x71380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x72380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x73380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x74380B00 AS Date), 0, 0, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x75380B00 AS Date), 0, 0, N'Sunday', 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x76380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x77380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[MonthlyBills] ([CustomerId], [DateTaken], [LunchAmount], [DinnerAmount], [Comments], [DailyPayment]) VALUES (3, CAST(0x78380B00 AS Date), 45, 45, NULL, 0)
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (1, N'January')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (2, N'February')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (3, N'March')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (4, N'April')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (5, N'May')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (6, N'June')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (7, N'July')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (8, N'August')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (9, N'September')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (10, N'October')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (11, N'November')
INSERT [dbo].[Months] ([MonthId], [MonthName]) VALUES (12, N'December')
ALTER TABLE [dbo].[CustomerDetails] ADD  CONSTRAINT [DF_CustomerDetails_DepositAmount]  DEFAULT ((0)) FOR [DepositAmount]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  DEFAULT ((0)) FOR [LunchOrDinnerId]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  DEFAULT ((0)) FOR [DefaultDabbawalaCharges]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  DEFAULT ((0)) FOR [InitialBalance]
GO
ALTER TABLE [dbo].[CustomerDetails] ADD  DEFAULT ('N') FOR [isDeleted]
GO
ALTER TABLE [dbo].[CustomerDues] ADD  CONSTRAINT [DF_CustomerDues_DueAmount]  DEFAULT ((0)) FOR [DueAmount]
GO
ALTER TABLE [dbo].[CustomerDues] ADD  CONSTRAINT [DF_CustomerDues_CarryforwardAmount]  DEFAULT ((0)) FOR [CarryforwardAmount]
GO
ALTER TABLE [dbo].[CustomerPaymentHistory] ADD  CONSTRAINT [DF_CustomerPaymentHistory_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[ExtraCharges] ADD  DEFAULT ((0)) FOR [DabbawalaCharges]
GO
ALTER TABLE [dbo].[ExtraCharges] ADD  DEFAULT ((0)) FOR [DeliveryCharges]
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
ALTER TABLE [dbo].[CustomerDues]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDues_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerDues] CHECK CONSTRAINT [FK_CustomerDues_CustomerDetails]
GO
ALTER TABLE [dbo].[CustomerPaymentHistory]  WITH CHECK ADD  CONSTRAINT [FK_CustomerPaymentHistory_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerPaymentHistory] CHECK CONSTRAINT [FK_CustomerPaymentHistory_CustomerDetails]
GO
ALTER TABLE [dbo].[ExtraCharges]  WITH CHECK ADD  CONSTRAINT [FK_DabbawalaCharges_Months] FOREIGN KEY([MonthId])
REFERENCES [dbo].[Months] ([MonthId])
GO
ALTER TABLE [dbo].[ExtraCharges] CHECK CONSTRAINT [FK_DabbawalaCharges_Months]
GO
ALTER TABLE [dbo].[ExtraCharges]  WITH CHECK ADD  CONSTRAINT [FK_ExtraCharges_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
ALTER TABLE [dbo].[ExtraCharges] CHECK CONSTRAINT [FK_ExtraCharges_CustomerDetails]
GO
ALTER TABLE [dbo].[MonthlyBills]  WITH CHECK ADD  CONSTRAINT [FK_MonthlyBills_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
ALTER TABLE [dbo].[MonthlyBills] CHECK CONSTRAINT [FK_MonthlyBills_CustomerDetails]
GO
