create table ArtWork (Art_id int primary key, Title varchar(500), Descrip varchar(500), Creationdate date, Mediums varchar(30), ImageURL varchar(100))

create table Artist (Artist_id int primary key, Aname varchar(30), Biography varchar(200), BirthDate varchar(20), Nationality varchar(30), Website varchar(50), Contact varchar(30))

create table Users (U_id int primary key, U_name varchar(50), pwd varchar(50), email varchar(30), FirstName varchar(50), LastName varchar(50), DOB varchar(30))

create table Gallery (Gallery_id int primary Key, Gname varchar(50), Descrpit varchar(500), GLocation varchar(50), Artist_id int, foreign key(Artist_id) references Artist(Artist_id), Opening_hrs int)

create table Favourites( Art_id int, foreign key(Art_id) references ArtWork(Art_id))
select * from ArtWork

INSERT INTO ArtWork (Art_id, Title, Descrip, Creationdate, Mediums, ImageURL)
VALUES (1, 'Starry Night', 'A famous painting by Vincent van Gogh', '1889-06-01', 'Oil on Canvas', 'https://example.com/starrynight.jpg');

INSERT INTO ArtWork (Art_id, Title, Descrip, Creationdate, Mediums, ImageURL)
VALUES (2, 'Mona Lisa', 'A portrait painting by Leonardo da Vinci', '1503-10-01', 'Oil on Wood', 'https://example.com/monalisa.jpg');
