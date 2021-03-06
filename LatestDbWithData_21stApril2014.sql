USE [KanakTiffins]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[CustomerDues]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[CustomerPaymentHistory]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[ExtraCharges]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[LunchOrDinner]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[MealPlans]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[MonthlyBills]    Script Date: 21-04-2014 04:47:36 PM ******/
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
/****** Object:  Table [dbo].[Months]    Script Date: 21-04-2014 04:47:36 PM ******/
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
INSERT [dbo].[Areas] ([AreaId], [AreaName]) VALUES (3, N'Matunga')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (1, N'Prachi', N'', N'Shiv Nivas', N'9768925265', N'', 0, 1, 2, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (2, N'Spruha', N'', N'Shiv Nivas', N'8879487583', N'', 0, 1, 2, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (3, N'Palak', N'', N'Shiv Nivas', N'9833111457', N'', 1000, 1, 1, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (4, N'Pallavi', N'', N'Shiv Nivas', N'9172503546', N'', 1000, 1, 1, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (5, N'Puja', N'Pandey', N'Shiv Nivas', N'9967943141', N'', 1000, 1, 1, 0, 0, 180, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (6, N'Bhuvneshwari', N'', N'77/04', N'9819764283', N'', 1000, 1, 3, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (7, N'Devarchana', N'', N'286/5', N'9769663853', N'', 0, 1, 2, 0, 0, 55, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (8, N'Doshi', N'', N'9 PSB', N'9920299712  ', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (9, N'Janak', N'', N'', N'8080651868', N'', 0, 1, 2, 1, 0, 10, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (10, N'Rehman', N'', N'King''s Circle', N'8291346662', N'', 0, 1, 2, 1, 0, 5, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (11, N'Abbas', N'', N'Midas 1st floor', N'9429055094', N'', 0, 1, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (12, N'Vaibhav', N'', N'', N'9820163287', N'', 0, 2, 1, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (13, N'Prachi', N'', N'', N'9221425184 ', N'', 0, 2, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (14, N'Sindhi family', N'', N'sindhi colony 9/A-4', N'24092030', N'', 0, 2, 3, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (15, N'Sindhi family 2', N'', N'sindhi colony 9/B-8', N'9167883037 ', N'', 0, 2, 2, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (16, N'Rajesh', N'Devikar (BMC)', N'', N'9930196252 ', N'', 0, 1, 1, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (17, N'Manoj', N'BMC', N'', N'7507997206', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (18, N'Alok', N'Ji', N'Axis Bank', N'9167006544', N'', 0, 2, 3, 1, 0, 5, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (19, N'Priya', N'Ji', N'Axis Bank', N'9969188532', N'', 0, 2, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (20, N'Shailesh', N'Ji', N'Axis Bank', N'', N'', 0, 2, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (21, N'Sachin', N'Ji', N'Axis Bank', N'', N'', 0, 2, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (22, N'Dipankar', N'', N'UBI', N'9892061997', N'', 0, 1, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (23, N'Champaklal', N'', N'207', N'9820140074', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (24, N'Rajesh', N'', N'EXT 136 Runal', N'9920901406', N'', 0, 2, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (25, N'Harshit', N'', N'EXT 160 Runal', N'', N'', 0, 2, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (26, N'Subhash', N'', N'Runwal', N'9702219078', N'', 0, 2, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (27, N'Nitu', N'', N'Ext 264 Runwal', N'9820244439 ', N'', 0, 2, 1, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (28, N'Anupam', N'Mehta', N'', N'9967448918', N'', 0, 2, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (29, N'Somaiya', N'', N'207', N'', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (30, N'Gautam', N'', N'Allahabad bank', N'9960217770', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (31, N'Panwala', N'', N'', N'', N'', 0, 2, 3, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (32, N'Mukul', N'', N'ABI', N'', N'', 0, 1, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (33, N'Danish', N'', N'IT', N'8149212749', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (34, N'Mehul', N'', N'IT', N'8149212749', N'', 0, 1, 3, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (35, N'Sanket', N'', N'IT', N'9892255855', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (36, N'Jijaji', N'Staff', N'', N'', N'', 0, 1, 3, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (37, N'Amit', N'', N'A1 Evrard Nagar', N'9167274729', N'', 0, 1, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (38, N'Rohit', N'', N'15/5', N'9167309036', N'', 0, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (39, N'Neha', N'Singh', N'D5', N'9769643221', N'', 1000, 1, 3, 2, 0, 5, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (40, N'Chandrayee', N'', N'D5', N'9167344164', N'', 1000, 1, 2, 2, 0, 5, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (41, N'Aishwarya', N'', N'286/5', N'9930266251', N'', 1000, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (42, N'Garima', N'', N'286/5', N'9930266940  ', N'', 1000, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (43, N'Sindhi family 3', N'', N'Sindhi colony 13 A-6', N'9833411833', N'', 0, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (44, N'Nisha', N'', N'69/8', N'9819477008', N'', 0, 1, 2, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (45, N'Ali', N'', N'Runwal', N'9833034467', N'', 0, 2, 2, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (46, N'Highway', N'', N'B-14 Highway Apt.', N'24072049', N'', 0, 2, 3, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (47, N'Hemang', N'Mehta', N'188/2', N'9930199056', N'', 0, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (48, N'Ayush', N'Mehta', N'Shiv Mahal', N'8080260171', N'', 0, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (49, N'Shrushti', N'', N'77/10', N'9096592888', N'', 0, 1, 2, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (50, N'Rishabh', N'', N'', N'9011873877', N'', 0, 3, 2, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (51, N'Veena', N'', N'6/181 Veena Apt.', N'9819924790 ', N'', 0, 3, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (52, N'Rahul', N'', N'114/7', N'9920787146', N'', 0, 3, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (53, N'Umang', N'', N'86/4', N'8108142484', N'', 1000, 3, 2, 2, 0, 720, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (54, N'Parth', N'', N'86/4', N'9167086165 ', N'', 1000, 3, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (55, N'Akshay', N'', N'178/10', N'9403727364 ', N'', 1000, 1, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (56, N'Rahul', N'', N'Dharavi', N'7738618507', N'', 1000, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (57, N'Drishya', N'', N'SM', N'9619595765', N'', 0, 3, 2, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (58, N'Ashwini', N'Patanwala', N'258/7', N'9561322896', N'', 0, 3, 3, 0, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (59, N'Aakash', N'', N'258/7', N'', N'', 1000, 3, 1, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (60, N'Mohit', N'SC', N'4B-5', N'9028862252', N'', 0, 3, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (61, N'Nirav', N'', N'Behind Dominoes', N'9987790480', N'', 0, 3, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (62, N'Champak', N'Lal', N'22 702', N'9167771980', N'', 0, 3, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (63, N'Bhakti', N'', N'Shiv Nivas', N'9768430539', N'', 0, 1, 1, 2, 0, 405, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (64, N'Venkatesh', N'', N'King''s Circle', N'', N'', 0, 1, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (65, N'Niraj', N'', N'99/14', N'', N'', 0, 3, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (66, N'Niraj', N'Magma', N'', N'', N'', 0, 3, 3, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (67, N'Reshma', N'', N'SNDT KC', N'', N'', 1000, 2, 2, 1, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (68, N'Ram', N'Krishna', N'219/37', N'', N'', 0, 2, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDetails] ([CustomerId], [FirstName], [LastName], [Address], [PhoneNumber], [EmailAddress], [DepositAmount], [AreaId], [MealPlanId], [LunchOrDinnerId], [DefaultDabbawalaCharges], [InitialBalance], [isDeleted]) VALUES (69, N'Asha', N'Gala Mam', N'', N'', N'', 0, 2, 3, 2, 0, 0, N'N')
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (1, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (2, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (3, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (4, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (5, 180, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (6, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (7, 55, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (8, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (9, 10, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (10, 5, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (11, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (12, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (13, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (14, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (15, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (16, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (17, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (18, 5, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (19, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (20, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (21, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (22, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (23, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (24, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (25, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (26, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (27, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (28, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (29, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (30, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (31, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (32, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (33, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (34, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (35, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (36, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (37, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (38, 365, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (39, 5, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (40, 5, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (41, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (42, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (43, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (44, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (45, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (46, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (47, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (48, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (49, 1065, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (50, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (51, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (52, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (53, 720, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (54, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (55, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (56, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (57, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (58, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (59, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (60, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (61, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (62, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (63, 405, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (64, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (65, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (66, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (67, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (68, 0, 0)
INSERT [dbo].[CustomerDues] ([CustomerId], [DueAmount], [CarryforwardAmount]) VALUES (69, 0, 0)
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (0, N'Lunch & Dinner')
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (1, N'Lunch only')
INSERT [dbo].[LunchOrDinner] ([Id], [Name]) VALUES (2, N'Dinner only')
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (1, 45, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (2, 55, NULL)
INSERT [dbo].[MealPlans] ([MealPlanId], [MealAmount], [MealDescription]) VALUES (3, 65, NULL)
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
