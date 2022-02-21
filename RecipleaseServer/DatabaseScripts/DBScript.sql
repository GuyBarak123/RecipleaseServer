--CREATE DATABASE Reciplease
--go

CREATE DATABASE Reciplease
go

USE Reciplease
Go

CREATE TABLE Ingridients(
IngridientID INT IDENTITY (1,1) PRIMARY KEY,
IngridientName NVARCHAR(255)
);

CREATE TABLE Tags(
TagID INT IDENTITY (1,1) PRIMARY KEY,
TagName NVARCHAR(255)
);

CREATE TABLE Gender(
GenderID INT IDENTITY (1,1) PRIMARY KEY,
GenderName NVARCHAR(255)
);

CREATE TABLE Measurement(
MeasurementID INT IDENTITY (1,1) PRIMARY KEY,
MeasurementName NVARCHAR(255)
);


CREATE TABLE Users (
UserID INT IDENTITY (1,1) PRIMARY KEY,
Name NVARCHAR (100) NOT NULL,
Password NVARCHAR (100) NOT NULL,
Email NVARCHAR(255) NOT NULL,
GenderID INT
CONSTRAINT FK_GenderID FOREIGN KEY (GenderID)
REFERENCES Gender(GenderID),
TagID INT,
CONSTRAINT FK_User_TagID FOREIGN KEY (TagID)
REFERENCES Tags(TagID),
);

CREATE TABLE Recipe(
RecipeID INT IDENTITY (1,1) PRIMARY KEY,
UserID INT,
CONSTRAINT FK_UserID FOREIGN KEY (UserID)
REFERENCES Users(UserID),
Title NVARCHAR (255) NOT NULL,
RecipeDescription NVARCHAR(1000) NOT NULL,
Instructions NVARCHAR(3000) NOT NULL,
TagID INT,
CONSTRAINT FK_Recipe_TagID FOREIGN KEY (TagID)
REFERENCES Tags(TagID),
DateOfUpload DATETIME,
);

CREATE TABLE Comment(
CommentID INT IDENTITY (1,1) PRIMARY KEY,
Content NVARCHAR(1500) NOT NULL,
RecipeID INT ,
CONSTRAINT FK_Comment_RecipeID FOREIGN KEY (RecipeID)
REFERENCES Recipe(RecipeID)
);

CREATE TABLE Follow(
FollowID INT IDENTITY (1,1) NOT NULL,
UserID INT,
CONSTRAINT FK_Follow_UserID FOREIGN KEY (UserID)
REFERENCES Users(UserID),
);

CREATE TABLE Likes(
LikesID INT IDENTITY (1,1) PRIMARY KEY,
RecipeID INT ,
CONSTRAINT FK_Likes_RecipeID FOREIGN KEY (RecipeID)
REFERENCES Recipe(RecipeID),
UserID INT,
CONSTRAINT FK_Likes_UserID FOREIGN KEY (UserID)
REFERENCES Users(UserID),
);

CREATE TABLE RecipeIng(
RecipeIngID INT IDENTITY (1,1) PRIMARY KEY,
RecipeID INT ,
CONSTRAINT FK_RecipeID FOREIGN KEY (RecipeID)
REFERENCES Recipe(RecipeID),
IngridientID INT ,
CONSTRAINT FK_IngridientID FOREIGN KEY (IngridientID)
REFERENCES Ingridients(IngridientID),
Amount FLOAT NOT NULL,
MeasurementID INT,
CONSTRAINT FK_MeasurementID FOREIGN KEY (MeasurementID)
REFERENCES Measurement (MeasurementID)
);

CREATE TABLE Saved(
RecipeID INT ,
CONSTRAINT FK_Saved_RecipeID FOREIGN KEY (RecipeID)
REFERENCES Recipe(RecipeID),
UserID INT,
CONSTRAINT FK_Saved_UserID FOREIGN KEY (UserID)
REFERENCES Users(UserID),
);

Alter table Users
ADD IsAdmin bit NOT NULL default(0)

USE Reciplease
go

INSERT INTO Ingridients ( IngridientName)
VALUES ('All Purpose Flour')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Self Rising Flour')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Corn Flour')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Corn Starch')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Cake Flour')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Sugar')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Brown Sugar')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Vanilla Sugar')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Egg')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Butter')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Salt')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Cinnamon')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Brown Butter')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Margerine')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Vanilla Extract')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Vanilla Paste')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Vegetable Oil')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Olive Oil')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Cocoa Powder')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Dark Chocolate')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Milk Chocolate')
INSERT INTO Ingridients ( IngridientName)
VALUES ('White Chocolate')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Dark Chocolate Chip')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Milk Chocolate Chip')
INSERT INTO Ingridients ( IngridientName)
VALUES ('White Chocolate Chip')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Hazelnut Spread')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Vanilla Instant Pudding')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Chocolate Instant Pudding')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Milk')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Heavy Cream')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Butter Milk')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Yogurt')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Sour Cream')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Sweetened Condensed Milk')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Coconut Shreds')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Coconut Flakes')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Coconut Milk')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Peanut Butter')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Almonds')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Hazelnuts')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Pecans')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Macadamias')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Pistachios')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Walnuts')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Peanuts')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Poppy Seeds')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Dates')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Dates Spread')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Raisins')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Gelatin')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Apple')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Banana')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Pear')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Plum')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Blueberries')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Strawberries')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Raspberries')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Orange')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Lemon')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Orange Juice')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Lemon Juice')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Orage Zest')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Lemon Zest')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Halva')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Graham Cracker')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Clove')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Nutmeg')
INSERT INTO Ingridients ( IngridientName)
VALUES ('All Spice')
INSERT INTO Ingridients ( IngridientName)
VALUES ('Ginger')


INSERT INTO Gender(GenderName)
VALUES('Female')
INSERT INTO Gender(GenderName)
VALUES('Male')
INSERT INTO Gender(GenderName)
VALUES('Other')

INSERT INTO Tags(TagName)
VALUES ('Baked')
INSERT INTO Tags(TagName)
VALUES ('Cookies')
INSERT INTO Tags(TagName)
VALUES ('Birthday')
INSERT INTO Tags(TagName)
VALUES ('Cakes')
INSERT INTO Tags(TagName)
VALUES ('Fast Recipes')
INSERT INTO Tags(TagName)
VALUES ('No Bake')
INSERT INTO Tags(TagName)
VALUES ('Pies')
INSERT INTO Tags(TagName)
VALUES ('Frozen Desserts')
INSERT INTO Tags(TagName)
VALUES ('Gluten Free')
INSERT INTO Tags(TagName)
VALUES ('Frosting')
INSERT INTO Tags(TagName)
VALUES ('low Fat')
INSERT INTO Tags(TagName)
VALUES ('Tarts')
INSERT INTO Tags(TagName)
VALUES ('Vegan')


INSERT INTO Users(Name, Password, Email, GenderID, TagID)
Values('Guy', 'G123', 'guy@gmail.com',1,2 )

INSERT INTO  Recipe (UserID, Title, RecipeDescription, Instructions, TagID)
Values(1, 'MY FIRST RECIPE', 'THIS RECIPE IS VERY EASY TO MAKE YOU WILL ENJOY IT!.', 'YOU ILL NEED FLOUR, EGGS, COCA POWDER AND MILK', 6)

INSERT INTO  Recipe (UserID, Title, RecipeDescription, Instructions, TagID)
Values(1, 'MY second RECIPE', 'cake recipe you will love it.', 'you need flour eggs baking powder sugar', 2)




SELECT * FROM Recipe
SELECT * FROM USERS
delete Recipe where RecipeID in (3,4)