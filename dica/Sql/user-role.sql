USE [dica]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8E545372-7BD1-4306-A2FB-4467359F6684', N'Administrator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9EB63E06-B660-44C4-B580-03B5B4542EEC', N'User')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'22a46622-efb9-454b-917c-a8b0a1169d1a', N'zayarmin@gmail.com', 0, N'AAYGOW5e9msXcR+D3O9jGbxs26rxjlgp/gupT9S66MDmA6dOLwfKOzIrS3YMYZoxYA==', N'cf89f818-38cb-464c-9e01-f06d5a6d54d3', NULL, 0, 0, NULL, 1, 0, N'zayarmin@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'442d5b78-a653-4c87-b19b-f181e7295916', N'aungmo@gmail.com', 0, N'AH1ObNz84yh3oLYZTHGwZBRStSl8wwHORFbYGmNIh4Mp5b/7VzofOdEUGKSWDHhm7Q==', N'3c7ccbcb-7391-406c-ae61-91ce6993180d', NULL, 0, 0, NULL, 1, 0, N'aungmo@gmail.com')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22a46622-efb9-454b-917c-a8b0a1169d1a', N'8E545372-7BD1-4306-A2FB-4467359F6684')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'442d5b78-a653-4c87-b19b-f181e7295916', N'8E545372-7BD1-4306-A2FB-4467359F6684')
