-- Insertion d'utilisateurs avec différents rôle : admin, register le reste visitor

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Admin', 'admin@example.com', 'Test123*', 'Admin');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Regsiter', 'register@example.com', 'Test123*', 'Register');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Jhon', 'jhon@example.com', 'Test123*', 'Visitor');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Marc', 'marc@example.com', 'Test123*', 'Visitor');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Zoé', 'zoe@example.com', 'Test123*', 'Visitor');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Marie', 'marie@example.com', 'Test123*', 'Visitor');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Paul', 'paul@example.com', 'Test123*', 'Visitor');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Lynn', 'lynn@example.com', 'Test123*', 'Visitor');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Marie', 'marie@example.com', 'Test123*', 'Visitor');

INSERT INTO [dbo].[User] ([Name], [Email], [Passwd], [Role])
VALUES
    ('Greg', 'greg@example.com', 'Test123*', 'Visitor');
