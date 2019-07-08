 select AuthorName from Author right outer join Book on Book.AuthorId = Author.Id

 create procedure findAuthor (@id INT, @author int output)
 as begin
 if exists(select Author.Id From Author, Book where Book.AuthorId = Author.Id AND Book.Id = @id)
 select @author = Author.Id From Author, Book where Book.AuthorId = Author.Id AND Book.Id = @id
 else
 set @author  = 0
 end

 create procedure findAuthor2 (@id INT, @author nvarchar(50) output)
 as begin
 if exists(select Author.AuthorName From Author, Book where Book.AuthorId = Author.Id AND Book.Id = @id)
 select @author = Author.AuthorName From Author, Book where Book.AuthorId = Author.Id AND Book.Id = @id
 else
 set @author  = 'not found'
 end

 declare @author nvarchar(50)
 exec findAuthor2 7, @author output
 print @author

 create procedure GetAuthorId (@BookId INT, @AuthorId INT OUTPUT)
 as
 select @AuthorId = AuthorId From Book Where Id = @BookId

 declare @a INT
 exec GetAuthorId 10, @a output
 print @a