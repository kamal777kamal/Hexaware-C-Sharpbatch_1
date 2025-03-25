-- artist table 

create table Artists( 
	artist_id int primary key,
	artist_name varchar(255) not null, 
	biography text, 
	nationality varchar(100))

--category table

create table Categories(
	category_id int primary key, 
	cat_name varchar(100) not null)

--artworks table

create table ArtWorks(
	artwork_id int primary key, 
	title varchar(225) not null, 
	artist_id int, 
	foreign key(artist_id) references Artists(artist_id), 
	category_id int,
	foreign key(category_id) references Categories(category_id), 
	year_ int, description_ text, 
	image_url varchar(225))

--exhibition table

create table Exhibition( 
	exhibition_id int primary key, 
	title varchar(225)not null, 
	Startdate date, Enddate date, 
	descript text)

--associating artworks with exhibitions

create table ExhibitionArtworks(
	exhibition_id int, 
	foreign key(exhibition_id) references Exhibition(exhibition_id), 
	artwork_id int, 
	foreign key(artwork_id) references ArtWorks(artwork_id))

--DML operations inserting values

-- Sample data for atrist table

insert into Artists(
	artist_id, artist_name, biography, nationality) values
	(1, 'Pablo Picaso', 'Renowed Spanish painter and sculptor.', 'Spanish'),
	(2, 'Vincent van Gogh', 'Dutch post-impressionist painter.', 'Dutch'),
	(3, 'Leonardo da Vinci', 'Italian polymath of the Renaissance.', 'Italian');

--Sample data for categories table

insert into Categories(
	category_id, cat_name) values 
	(1, 'Painting'),
	(2, 'Sculpture'),
	(3, 'Photography');

--Sample data for artworks table

insert into ArtWorks(
	artwork_id, title, artist_id, category_id, year_, description_, image_url) values
	(1, 'Starry Night', 2,1,1889, 'A famous painting by Vincent van Gogh.', 'starry_night.jpg'),
	(2, 'Mona Lisa', 3,1,1503, 'The iconic portriat by Leonardo da Vinci.', 'mona_lisa.jpg'),
	(3, 'Guernica', 1,1,1937, 'Pablo Picasso\s powerful anti-war mural.', 'guarnica.jpg');

--Sample data for exhibition table

insert into Exhibition(
	exhibition_id, title, Startdate, Enddate, descript) values
	(1, 'Modern Art Masterpieces', '2023-01-01', '2023-03-01', 'A collection of modern art masterpieces.'),
	(2, 'Renaissance Art', '2023-04-01', '2023-06-01', 'A showcase of Renaissance art tressures.');

--sample data for artworks to exhibition

insert into ExhibitionArtworks(
	exhibition_id, artwork_id) values
	(1,1),
	(1,2),
	(1,3),
	(2,2);

--tasks or questions to be solved

--question 1 Retrieve the names of all artists along with the number of artworks they have in the gallery, and list them in descending order of the number of artworks.

select artist_name, count(artwork_id) as Artcount from Artists
	left join ArtWorks Art on Artists.artist_id = Artists.artist_id
	group by Artists.artist_name
	order by Artcount desc;

--question 2 List the titles of artworks created by artists from 'Spanish' and 'Dutch' nationalities, and order them by the year in ascending order.

select title, year_ from ArtWorks
	join Artists on ArtWorks.artist_id = Artists.artist_id
	where Artists.nationality in ('Spanish', 'Dutch')
	order by ArtWorks.year_ asc;

--question 3 Find the names of all artists who have artworks in the 'Painting' category, and the number of artworks they have in this category.

select artist_name, count(artwork_id)as PaintingCount from Artists
	join ArtWorks on Artists.artist_id = ArtWorks.artist_id
	join Categories on ArtWorks.category_id=Categories.category_id
	where Categories.cat_name= 'Paiting'
	group by Artists.artist_name;

--question 4 List the names of artworks from the 'Modern Art Masterpieces' exhibition, along with their artists and categories.

select ArtWorks.title, Artists.artist_name as ArtistName, Categories.cat_name as CategoryName
	from ArtWorks
	join ExhibitionArtworks on ArtWorks.artwork_id= ExhibitionArtworks.artwork_id
	join Exhibition on Exhibition.title= Exhibition.title
	join Artists on ArtWorks.artist_id= Artists.artist_id
	join Categories on ArtWorks.category_id= Categories.category_id
	where Exhibition.title= 'Modern Art Masterpieces';

--question 5 Find the artists who have more than two artworks in the gallery.

select Artists.artist_name
	from Artists
	join ArtWorks on Artists.artist_id=ArtWorks.artist_id
	group by Artists.artist_name
	having count(artwork_id)>2;

--question 6 Find the titles of artworks that were exhibited in both 'Modern Art Masterpieces' and 'Renaissance Art' exhibitions

select ArtWorks.title
	from ArtWorks
	join Exhibition on Exhibition.exhibition_id= Exhibition.exhibition_id
	join ExhibitionArtworks on ArtWorks.artwork_id= ExhibitionArtworks.artwork_id
	join Exhibition E1 on Exhibition.exhibition_id= Exhibition.exhibition_id
	where Exhibition.title= 'Modern Art Masterpieces' and E1.title= 'Renaissance Art'

--question 7 Find the total number of artworks in each category

select Categories.cat_name as CategoryName, count(ArtWorks.artwork_id) as TotalArts
	from Categories
	left join ArtWorks on Categories.category_id= ArtWorks.category_id
	group by Categories.cat_name

--question 8 List artists who have more than 3 artworks in the gallery

select Artists.artist_name
	from Artists
	join ArtWorks on Artists.artist_id= ArtWorks.artist_id
	group by Artists.artist_name
	having count( ArtWorks.artist_id)>3;

--question 9 Find the artworks created by artists from a specific nationality (e.g., Spanish).

select ArtWorks.title
	from ArtWorks
	join Artists on ArtWorks.artist_id=Artists.artist_id
	where Artists.nationality= 'Spanish';

--question 10 List exhibitions that feature artwork by both Vincent van Gogh and Leonardo da Vinci.

select Exhibition.title
	from Exhibition
	join ExhibitionArtworks on Exhibition.exhibition_id= ExhibitionArtworks.exhibition_id
	join ArtWorks on ExhibitionArtworks.artwork_id=ArtWorks.artwork_id
	join Artists on ArtWorks.artist_id= Artists.artist_id
	where Artists.artist_name= 'Vincent van Gogh'
	intersect select Exhibition.title
	from Exhibition
	join ExhibitionArtworks on Exhibition.exhibition_id= ExhibitionArtworks.exhibition_id
	join ArtWorks on ExhibitionArtworks.artwork_id= ArtWorks.artist_id
	join Artists on ArtWorks.artist_id= Artists.artist_id
	where Artists.artist_name= 'Leonardo da Vinci';

--question 11 Find all the artworks that have not been included in any exhibition.

select ArtWorks.title
	from ArtWorks
	left join ExhibitionArtworks on ArtWorks.artist_id= ExhibitionArtworks.artwork_id
	where ExhibitionArtworks.artwork_id is null;

--question 12 List artists who have created artworks in all available categories.

select Artists.artist_name
	from Artists
	join ArtWorks on Artists.artist_id= ArtWorks.artist_id
	join Categories on ArtWorks.category_id=Categories.category_id
	group by Artists.artist_name
	having count( distinct Categories.category_id)= (select count(*) from Categories);

--question 13 List the total number of artworks in each category.

select Categories.cat_name, count( ArtWorks.artwork_id) as Totalarts
	from Categories
	left join ArtWorks on Categories.category_id= ArtWorks.category_id
	group by Categories.cat_name;

--question 14 Find the artists who have more than 2 artworks in the gallery.

select Artists.artist_name
	from Artists
	join ArtWorks on Artists.artist_id=ArtWorks.artist_id
	group by Artists.artist_name
	having count(artwork_id)>=2;

--question 15 List the categories with the average year of artworks they contain, only for categories with more than 1 artwork.

select Categories.cat_name as CategoryName, avg( ArtWorks.year_) as AvgYear
	from Categories
	join ArtWorks on Categories.category_id= ArtWorks.category_id
	group by Categories.cat_name
	having count( ArtWorks.artwork_id)>1;

--question 16 Find the artworks that were exhibited in the 'Modern Art Masterpieces' exhibition.

select ArtWorks.title
	from ArtWorks
	join ExhibitionArtworks on ArtWorks.artwork_id= ExhibitionArtworks.artwork_id
	join Exhibition on ExhibitionArtworks.exhibition_id= Exhibition.exhibition_id
	where Exhibition.title= 'Modern Art Masterpieces';

--question 17 Find the categories where the average year of artworks is greater than the average year of all artworks.

select Categories.cat_name as CategoryName
	from Categories
	join ArtWorks on Categories.category_id= ArtWorks.category_id
	group by Categories.cat_name
	having avg( ArtWorks.year_)> (select avg(year_) from ArtWorks);

--question 18 List the artworks that were not exhibited in any exhibition.

select ArtWorks.title
	from ArtWorks
	left join ExhibitionArtworks on ArtWorks.artist_id= ExhibitionArtworks.artwork_id
	where ExhibitionArtworks.artwork_id is null;

--question 19 Show artists who have artworks in the same category as "Mona Lisa."

select distinct Artists.artist_name
	from Artists
	join ArtWorks on Artists.artist_id= Artists.artist_id
	where ArtWorks.category_id= (select category_id from ArtWorks where title= 'Mona Lisa');

--question 20 List the names of artists and the number of artworks they have in the gallery.

select Artists.artist_name, count( ArtWorks.artwork_id) as ArtCount
	from Artists
	left join ArtWorks on Artists.artist_id= ArtWorks.artist_id
	group by artist_name;