

CREATE DATABASE [KUAS]
GO

USE [KUAS]
GO

CREATE TABLE [dbo].[Course](
	[CourseID]   [nvarchar](20) NOT NULL,
	[CourseName] [nvarchar](200) NOT NULL,
	[CourseDescription]  [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseDescription]) VALUES (N'1'  , N'C#',  N'就C#');
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseDescription]) VALUES (N'2', N'JAVA',  N'就JAVA');
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseDescription]) VALUES (N'3'  , N'Html5',  N'就Html5');
GO
