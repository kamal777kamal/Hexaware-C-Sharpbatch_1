create database TicketBookingSystem

use TicketBookingSystem

create table Venue( venue_id int primary key,
     venue_name varchar(30), 
	 adress varchar(30))

create table Booking(booking_id int primary key,
     customer_id int,
	 event_id int,
	 num_tickets int,
	 total_cost decimal,
	 booking_date date)
create table Event_det( event_id int, 
     event_name varchar(30), 
	 event_date date, 
	 event_time time, 
	 venue_id int, 
	 foreign key(venue_id) references Venue(venue_id), 
	 total_seats int, 
	 available_seats int, 
	 ticket_price decimal, 
	 event_type varchar(30), 
	 booking_id int,
	 foreign key(booking_id) references Booking(booking_id))

create table Customer(
     customer_id int primary key,
	 customer_name varchar(50),
	 email varchar(30),
	 phone_number int,
	 booking_id int,
	 foreign key(booking_id) references Booking(booking_id))


--task 2


--question 1
INSERT INTO Venue (venue_id, venue_name, adress) VALUES
(1, 'City Cineplex', '123 Main St'),
(2, 'National Stadium', '45 Park Ave'),
(3, 'Grand Concert Hall', '78 Broadway');


insert into Event_det (event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type) values
(101, 'Avengers: Endgame', '2024-11-10', '18:30:00', 1, 200, 50, 12.50, 'Movie'),
(102, 'Football Championship', '2024-12-05', '20:00:00', 2, 500, 120, 45.00, 'Sport'),
(103, 'Coldplay Live', '2024-12-15', '19:00:00', 3, 300, 80, 75.00, 'Concert'),
(104, 'Inception', '2024-11-20', '21:00:00', 1, 200, 75, 10.00, 'Movie'),
(105, 'Basketball Finals', '2024-12-22', '19:30:00', 2, 400, 150, 40.00, 'Sport'),
(106, 'Taylor Swift Tour', '2025-01-05', '20:30:00', 3, 350, 200, 90.00, 'Concert');


insert into Customer (customer_id, customer_name, email, phone_number) values
(1, 'John Doe', 'john.doe@example.com', '9876543210'),
(2, 'Jane Smith', 'jane.smith@example.com', '9876543211'),
(3, 'Michael Johnson', 'michael.johnson@example.com', '9876543212'),
(4, 'Emily Davis', 'emily.davis@example.com', '9876543213'),
(5, 'Robert Brown', 'robert.brown@example.com', '9876543214');


insert into Booking (booking_id, customer_id, event_id, num_tickets, total_cost, booking_date) values
(1001, 1, 101, 2, 25.00, '2024-10-01'),   
(1002, 2, 102, 1, 45.00, '2024-10-05'),   
(1003, 3, 103, 3, 225.00, '2024-09-30'),  
(1004, 4, 104, 2, 20.00, '2024-10-10'),   
(1005, 5, 105, 4, 160.00, '2024-10-15'),  
(1006, 1, 106, 2, 180.00, '2024-10-20');

select * from Customer
select * from Event_det
select * from Booking
select * from Venue


--question 2

select * from Event_det

--question 3

select event_id, event_name, event_date, event_time, event_type, available_seats 
from Event_det 
where available_seats > 0;

--question 4

select event_id, event_name, event_date, event_time, event_type, available_seats 
from Event_det 
where event_name like '%cup%';

--question5

select event_id, event_name, event_date, event_time, event_type, ticket_price 
from Event_det 
where ticket_price between 1000 and 2500;

--question 6

select event_id, event_name, event_date, event_time, event_type, venue_id 
from Event_det 
where event_date between '2024-07-01' and '2024-12-31';

--question 7

select event_id, event_name, event_date, event_time, event_type, available_seats 
from Event_det 
where available_seats > 0 
and event_name like '%Concert%';

--question 8

select * from Customer
order by customer_id
OFFSET 5 rows fetch next 5 rows ONLY;

--question 9

select booking_id, customer_id, event_id, num_tickets, total_cost, booking_date 
from Booking 
where num_tickets > 4;

--question 10

select customer_id, customer_name, email, phone_number 
from Customer 
where phone_number like '%000';

--question 11

select event_id, event_name, event_date, event_time, event_type, total_seats 
from Event_det 
where total_seats > 15000
order by total_seats desc;

--question 12

select event_id, event_name, event_date, event_time, event_type 
from Event_det 
where event_name not like 'X%' 
and event_name not like 'Y%' 
and event_name not like 'Z%';

--task 3

--question 1  

select event_id, event_name, avg(ticket_price) as avg_price
from Event_det group by event_name,event_id

--question 2

select e.event_id, e.event_name, sum(b.total_cost) AS total
from Booking b
JOIN Event_det e on b.event_id = e.event_id
group by e.event_id, e.event_name;

--question 3

select top 1 e.event_id, e.event_name, sum(b.num_tickets) as total_tickets_sold
from Booking b
join Event_det e on b.event_id = e.event_id
group by e.event_id, e.event_name
order by total_tickets_sold desc;

--question 4

select e.event_id, e.event_name, sum(b.num_tickets) as total_tickets_sold 
from Booking b
join Event_det e on b.event_id = e.event_id
group by e.event_id, e.event_name;

--question 5

select e.event_id, e.event_name
from Event_det e
left join Booking b on e.event_id = b.event_id
where b.booking_id is null;
--there is no values in the output as the data does not have any event in which no tickets is sold.

--question 6

select top 1 c.customer_id, c.customer_name, sum(b.num_tickets) as total_tickets
from Booking b
join Customer c on b.customer_id = c.customer_id
group by c.customer_id, c.customer_name
order by total_tickets desc

--question 7

select month(b.booking_date) as booking_month, e.event_id, e.event_name, sum(b.num_tickets) as total_tickets_sold
from Booking b
join Event_det e on b.event_id = e.event_id
group by booking_date, e.event_id, e.event_name
order by booking_month;

--question 8

select v.venue_id, v.venue_name, avg(e.ticket_price) as avg_ticket_price
from Event_det e
join Venue v on e.venue_id = v.venue_id
group by v.venue_id, v.venue_name;

--question 9

select e.event_type, sum(b.num_tickets) as total_tickets_sold
from Booking b
join Event_det e on b.event_id = e.event_id
group by e.event_type;

--question 10

select year(e.event_date) as event_year, sum(b.total_cost) as total_revenue
from Booking b
join Event_det e on b.event_id = e.event_id
group by event_date;

--question 11

select c.customer_id, c.customer_name, count(distinct b.event_id) as total_events_booked
from Booking b
join Customer c on b.customer_id = c.customer_id
group by c.customer_id, c.customer_name
having count(distinct b.event_id) > 1;

--question 12

select c.customer_id, c.customer_name, sum(b.total_cost) as total_spent
from Booking b
join Customer c on b.customer_id = c.customer_id
group by c.customer_id, c.customer_name;

--question 13

select e.event_type, v.venue_name, avg(e.ticket_price) as avg_ticket_price
from Event_det e
join Venue v on e.venue_id = v.venue_id
group by e.event_type, v.venue_name;

--question 14

select c.customer_id, c.customer_name, sum(b.num_tickets) as total_tickets_last_30_days
from Booking b
join Customer c on b.customer_id = c.customer_id
where b.booking_date >= dateadd(day, -30, getdate()) 
group by c.customer_id, c.customer_name;

--task 4

--question 1

select v.venue_id, v.venue_name, 
       (select avg(e.ticket_price) 
        from Event_det e 
        where e.venue_id = v.venue_id) as avg_ticket_price
from Venue v;

--question 2

select event_id, event_name
from Event_det
where available_seats < (total_seats / 2);

--question 3

select e.event_id, e.event_name, 
       (select sum(b.num_tickets) 
        from Booking b 
        where b.event_id = e.event_id) as total_tickets_sold
from Event_det e;

--question 4

select c.customer_id, c.customer_name
from Customer c
where not exists (
select 1 from Booking b where b.customer_id = c.customer_id);

--question 5

select event_id, event_name
from Event_det
where event_id not in (select distinct event_id from Booking);

--question 6

select e.event_type, sum(t.total_tickets) as total_tickets_sold from (
    select event_id, sum(num_tickets) as total_tickets
    from Booking
    group by event_id) t
join Event_det e on t.event_id = e.event_id
group by e.event_type;

--question 7

select event_id, event_name, ticket_price
from Event_det
where ticket_price > (select avg(ticket_price) from Event_det);

--question 8

select c.customer_id, c.customer_name, 
       (select sum(b.num_tickets * e.ticket_price)
        from Booking b
        join Event_det e on b.event_id = e.event_id
        where b.customer_id = c.customer_id) as total_revenue
from Customer c;

--question 9

select distinct c.customer_id, c.customer_name
from Customer c
where c.customer_id in (
    select b.customer_id
    from Booking b
    where b.event_id in (select e.event_id from Event_det e where e.venue_id = 1));

--question 10

select e.event_type, 
(select sum(b.num_tickets) 
from Booking b 
where b.event_id = e.event_id) as total_tickets_sold
from Event_det e
group by e.event_type, e.event_id;

--question 11

select distinct c.customer_id, c.customer_name, 
       format(cast(b.booking_date as date), 'yyyy-MM') as booking_month
from Customer c
join Booking b on c.customer_id = b.customer_id
where cast(b.booking_date as date) in (
    select distinct cast(booking_date as date) from Booking);

--question 12

select v.venue_id, v.venue_name, 
       (select avg(ticket_price) from Event_det e where e.venue_id = v.venue_id) as avg_ticket_price
from Venue v;
