USE FXTWishlist;

-- ✅ Insert 20 Authors
INSERT INTO Authors (Name) VALUES 
('J.K. Rowling'), ('George R.R. Martin'), ('J.R.R. Tolkien'), ('Agatha Christie'), ('Stephen King'),
('Isaac Asimov'), ('Arthur C. Clarke'), ('H.P. Lovecraft'), ('Mary Shelley'), ('Philip K. Dick'),
('Ray Bradbury'), ('Ernest Hemingway'), ('Jane Austen'), ('Mark Twain'), ('Leo Tolstoy'),
('Fyodor Dostoevsky'), ('Homer'), ('Charles Dickens'), ('William Shakespeare'), ('Victor Hugo');

-- ✅ Insert 20 Directors
INSERT INTO Directors (Name) VALUES 
('Steven Spielberg'), ('Christopher Nolan'), ('Quentin Tarantino'), ('Martin Scorsese'), ('Alfred Hitchcock'),
('Stanley Kubrick'), ('James Cameron'), ('Ridley Scott'), ('Francis Ford Coppola'), ('Peter Jackson'),
('George Lucas'), ('David Fincher'), ('Tim Burton'), ('Guillermo del Toro'), ('Coen Brothers'),
('Clint Eastwood'), ('Woody Allen'), ('Akira Kurosawa'), ('Wes Anderson'), ('Denis Villeneuve');

-- ✅ Insert 2 WatchLists (one for books, one for movies)
INSERT INTO WatchLists (Name) VALUES ('My Book List'), ('My Movie List');

DECLARE @BookWatchListId INT, @MovieWatchListId INT;
SELECT @BookWatchListId = Id FROM WatchLists WHERE Name = 'My Book List';
SELECT @MovieWatchListId = Id FROM WatchLists WHERE Name = 'My Movie List';

-- ✅ Insert 20 Books
INSERT INTO WatchListItems (WatchListId, Title, ItemType, PagesOrDuration, AuthorId, Genre, Year, IsCompleted)
SELECT @BookWatchListId, Title, 'Book', Pages, Id, Genre, Year, 0
FROM (VALUES
    ('Harry Potter and the Philosopher''s Stone', 320, 1, 3, 1997),
    ('A Game of Thrones', 694, 2, 3, 1996),
    ('The Hobbit', 310, 3, 3, 1937),
    ('Murder on the Orient Express', 256, 4, 5, 1934),
    ('The Shining', 447, 5, 4, 1977),
    ('Foundation', 255, 6, 7, 1951),
    ('2001: A Space Odyssey', 297, 7, 7, 1968),
    ('The Call of Cthulhu', 110, 8, 4, 1928),
    ('Frankenstein', 280, 9, 14, 1818),
    ('Do Androids Dream of Electric Sheep?', 210, 10, 7, 1968),
    ('Fahrenheit 451', 249, 11, 13, 1953),
    ('The Old Man and the Sea', 127, 12, 14, 1952),
    ('Pride and Prejudice', 432, 13, 6, 1813),
    ('The Adventures of Tom Sawyer', 274, 14, 14, 1876),
    ('War and Peace', 1225, 15, 10, 1869),
    ('Crime and Punishment', 671, 16, 11, 1866),
    ('The Iliad', 704, 17, 12, -800),
    ('A Tale of Two Cities', 544, 18, 10, 1859),
    ('Hamlet', 500, 19, 2, 1603),
    ('Les Misérables', 1463, 20, 10, 1862)
) AS BookData (Title, Pages, Id, Genre, Year);

-- ✅ Insert 20 Movies
INSERT INTO WatchListItems (WatchListId, Title, ItemType, PagesOrDuration, DirectorId, Genre, Year, IMDBId, IsCompleted)
SELECT @MovieWatchListId, Title, 'Movie', Duration, Id, Genre, Year, IMDBId, 0
FROM (VALUES
    ('Jurassic Park', 127, 1, 7, 1993, 'tt0107290'),
    ('Inception', 148, 2, 7, 2010, 'tt1375666'),
    ('Pulp Fiction', 154, 3, 13, 1994, 'tt0110912'),
    ('Goodfellas', 145, 4, 13, 1990, 'tt0099685'),
    ('Psycho', 109, 5, 4, 1960, 'tt0054215'),
    ('The Shining', 146, 6, 4, 1980, 'tt0081505'),
    ('Avatar', 162, 7, 7, 2009, 'tt0499549'),
    ('Blade Runner', 117, 8, 7, 1982, 'tt0083658'),
    ('The Godfather', 175, 9, 13, 1972, 'tt0068646'),
    ('The Lord of the Rings: The Fellowship of the Ring', 178, 10, 3, 2001, 'tt0120737'),
    ('Star Wars: A New Hope', 121, 11, 7, 1977, 'tt0076759'),
    ('Fight Club', 139, 12, 2, 1999, 'tt0137523'),
    ('Edward Scissorhands', 105, 13, 3, 1990, 'tt0099487'),
    ('Pan''s Labyrinth', 118, 14, 3, 2006, 'tt0457430'),
    ('No Country for Old Men', 122, 15, 13, 2007, 'tt0477348'),
    ('Unforgiven', 131, 16, 14, 1992, 'tt0105695'),
    ('Annie Hall', 93, 17, 1, 1977, 'tt0075686'),
    ('Seven Samurai', 207, 18, 0, 1954, 'tt0047478'),
    ('The Grand Budapest Hotel', 99, 19, 1, 2014, 'tt2278388'),
    ('Dune: Part One', 155, 20, 7, 2021, 'tt1160419')
) AS MovieData (Title, Duration, Id, Genre, Year, IMDBId);