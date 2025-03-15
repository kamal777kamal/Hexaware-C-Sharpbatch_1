create table EventTable(event_id int Primary key, event_name varchar(50), event_date date, event_time time, venue_id int, 
foreign key(venue_id) references Venue(venue_id))