create TABLE Artists(
	id int IDENTITY PRIMARY KEY,
	artist_name varchar(200) not null,
	album_name varchar(200) not null,
	image_url varchar(200),
	release_date DATETIME not null,
	price decimal(10,2) not null,
	sample_url varchar(200)
)
