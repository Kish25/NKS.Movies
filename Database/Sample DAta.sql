declare @Movieid bigint

INSERT INTO Movies (ReleaseYear,Duration)  VALUES (2021,'01:39:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Hitman''s Wife''s Bodyguard (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'ru',N'Телохранитель жены киллера (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'fr',N'Le garde du corps de la femme du tueur à gages (2021)')


INSERT INTO Movies (ReleaseYear,Duration)  VALUES (2021,'01:23:00') 
select @Movieid=SCOPE_IDENTITY()

INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Birthday Cake (2021)')

INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'ru',N'Торт на день рождения (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'fr',N'Le gâteau d''anniversaire (2021)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES (2021,'01:30:00') 
select @Movieid=SCOPE_IDENTITY()

INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','Summer of 85 (2020)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'ru',N'Лето 85-го (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'fr',N'Été 85 (2021)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES (2021,'01:29:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Serpent (2020)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES (2021,'02:15:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Sparks Brothers (2021)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES (2021,'01:32:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','Siberia (2019)')



    
    
SELECT Movies.MovieId,Titles.Title,Titles.Language,  Cast(Duration as char(8)) as Duration, ReleaseYear
FROM Movies 
INNER JOIN Titles on Titles.MovieId = Movies.MovieId
WHERE Movies.Movieid=@MovieId
    
    

SELECT FROM Movies
SELECT *FROM Titles order by 2,1


/*
INSERT INTO Movies (ReleaseYear,Duration)  VALUES ('2021/06/16','01:39:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Hitman''s Wife''s Bodyguard (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'ru',N'Телохранитель жены киллера (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'fr',N'Le garde du corps de la femme du tueur à gages (2021)')


INSERT INTO Movies (ReleaseYear,Duration)  VALUES ('2021/07/16','01:23:00') 
select @Movieid=SCOPE_IDENTITY()

INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Birthday Cake (2021)')

INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'ru',N'Торт на день рождения (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'fr',N'Le gâteau d''anniversaire (2021)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES ('2021/06/18','01:30:00') 
select @Movieid=SCOPE_IDENTITY()

INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','Summer of 85 (2020)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'ru',N'Лето 85-го (2021)')
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'fr',N'Été 85 (2021)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES ('2021/06/18','01:29:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Serpent (2020)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES ('2021/06/18','02:15:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','The Sparks Brothers (2021)')

INSERT INTO Movies (ReleaseYear,Duration)  VALUES ('2021/06/18','01:32:00') 
select @Movieid=SCOPE_IDENTITY()
INSERT INTO Titles  (MovieId, Language, Title) VALUES (@Movieid,'en-us','Siberia (2019)')

*/