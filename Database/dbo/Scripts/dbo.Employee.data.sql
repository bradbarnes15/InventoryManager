SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT INTO [dbo].[Employee] ([employee_id], [first_name], [last_name], [username], [encrypted_password]) VALUES (1, N'First Name', N'Last Name', N'User Name ', N'Password')
INSERT INTO [dbo].[Employee] ([employee_id], [first_name], [last_name], [username], [encrypted_password]) VALUES (2, N'Sam', N'Smith', N'@smith    ', N'lFhHTtUwkNZ1Q7kL/qBO6w==')
INSERT INTO [dbo].[Employee] ([employee_id], [first_name], [last_name], [username], [encrypted_password]) VALUES (3, N'test_UserFN', N'test_UserLN', N'@test_User', N'240u0HKuQlMH2bEJymBRwg==')
SET IDENTITY_INSERT [dbo].[Employee] OFF
