alter table Customer 
add booking_id int, foreign key(booking_id) references Booking(booking_id)
--iam altering the table because the primary key of booking_id is located in table name Booking. So i alter the table by inserting booking_id as a new column.