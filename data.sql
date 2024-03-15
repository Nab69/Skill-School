INSERT INTO [dbo].[Classroom] ([classname],[Floor],[Corridor]) VALUES ('Salle Bill Gates', 2, 'A');
INSERT INTO [dbo].[Classroom] ([classname],[Floor],[Corridor]) VALUES ('Salle Steve Ballmer', 1, 'B');

INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Ted', 'Mosby', 35);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Barney', 'Stinson', 34);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Marshall', 'Eriksen', 35);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Robin', 'Stinson', 38);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('John', 'Dorian', 25);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Perry', 'Cox', 45);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Lily', 'Aldrin', 32);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Chris', 'Turk', 23);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Elliot', 'Reid', 22);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Carla', 'Espinosa', 37);
INSERT INTO [dbo].[Person] ([FirstName],[LastName],[Age]) VALUES ('Bob', 'Kelso', 67);

INSERT INTO [dbo].[Student] ([PersonId],[IsClassDelegate],[Average],[ClassroomId]) VALUES (6, 1, 16.8, 1);
INSERT INTO [dbo].[Student] ([PersonId],[IsClassDelegate],[Average],[ClassroomId]) VALUES (9, 0, 12, 1);
INSERT INTO [dbo].[Student] ([PersonId],[IsClassDelegate],[Average],[ClassroomId]) VALUES (10, 1, 18, 1);
INSERT INTO [dbo].[Student] ([PersonId],[IsClassDelegate],[Average],[ClassroomId]) VALUES (8, 0, 15, 1);

INSERT INTO [dbo].[Teacher] ([PersonId],[Discipline],[Salary], [ClassroomId]) VALUES (7, 'Medecine', 4000, NULL);
INSERT INTO [dbo].[Teacher] ([PersonId],[Discipline],[Salary], [ClassroomId]) VALUES (11, 'Chief of Medecine', 10000, 1);