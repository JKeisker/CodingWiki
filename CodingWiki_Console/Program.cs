// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

//using (ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if(context.Database.GetPendingMigrations().Count() > 0)
//    {
//        context.Database.Migrate();
//    }
//}

//AddBook();
//GetAllBooks();
//GetBook();
//GetBook2();
//GetBook3();
//GetBook4();
//GetBook5();
//GetAllBooks2();
//GetBook6();
//GetBook7();
//GetPagination();
//UpdateBook();
//UpdateBook2();
//DeleteBook();
//DeleteBookAsync();
UpdateBookAsync();
//GetPaginationAsync();



async void DeleteBookAsync()
{
    using var context = new ApplicationDbContext();
    var book = await context.Books.FindAsync(3);
    if (book == null)
    {
        Console.WriteLine("books is null");
    }
    context.Books.Remove(book!);
    await context.SaveChangesAsync();
}

async void UpdateBookAsync()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = await context.Books.Where(b => b.Publisher_Id == 1).ToListAsync();

        foreach (var book in books)
        {
            book.Price = 67.55m;
        }
        await context.SaveChangesAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: No books were found");
    }
}

async void GetPaginationAsync() //w/o .ToList() appended to context.Books, the query does NOT get executed right away, it execute during iteration
{
    using var context = new ApplicationDbContext();

    var books = await context.Books.Skip(0).Take(2).ToListAsync();
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }

    books = await context.Books.Skip(4).Take(1).ToListAsync();
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}

void DeleteBook()
{
    using var context = new ApplicationDbContext();
    var book = context.Books.Find(4);
    if (book == null)
    {
        Console.WriteLine("books is null");
    }
    context.Books.Remove(book!);
    context.SaveChanges();
}

void UpdateBook2()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = context.Books.Where(b=>b.Publisher_Id==1);

        foreach (var book in books)
        {
            book.Price = 55.55m;
        }
        context.SaveChanges();
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: No books were found");
    }
}

void UpdateBook()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = context.Books.Find(7);
        if (books == null)
        {
            Console.WriteLine("books is null");
        }
        books!.ISBN = "777";
        context.SaveChanges();
    }
    catch (Exception e)
    {

    }
}

void GetPagination() //w/o .ToList() appended to context.Books, the query does NOT get executed right away, it execute during iteration
{
    using var context = new ApplicationDbContext();

    var books = context.Books.Skip(0).Take(2);
    foreach (var book in books)                                                     
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }

    books = context.Books.Skip(4).Take(1);
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}

void GetBook7() //w/o .ToList() appended to context.Books, the query does NOT get executed right away, it execute during iteration
{
    using var context = new ApplicationDbContext();
    var books = context.Books.Where(b=>b.Price>10).OrderBy(b => b.Title).ThenByDescending(b => b.ISBN); //IMPORTANT LESSON: this creates the outcome that was initially expected from 
    foreach (var book in books)                                                     //GetBook6() method.. After it orders by Title, it then orders by desc ISBN
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}


void GetBook6() //w/o .ToList() appended to context.Books, the query does NOT get executed right away, it execute during iteration
{
    using var context = new ApplicationDbContext();
    var books = context.Books.OrderBy(b => b.Title).OrderByDescending(b=>b.ISBN); //IMPORTANT LESSON: when using multiple ORDERBY LINQ statements, it will only 
    foreach (var book in books)                                                   //consider the LAST OrderBy condition
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}

void GetAllBooks2() //w/o .ToList() appended to context.Books, the query does NOT get executed right away, it execute during iteration
{
    using var context = new ApplicationDbContext();
    var books = context.Books;
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}


void GetBook5()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = context.Books.Where(b => EF.Functions.Like(b.ISBN,"12%"));

        foreach (var book in books)
        {
            Console.WriteLine(book.Title + " = " + book.ISBN);
        }

    }
    catch (Exception e)
    {

    }
}


void GetBook4()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = context.Books.Where(b => b.ISBN.Contains("12"));

        foreach(var book in books)
        {
            Console.WriteLine(book.Title + " = " + book.ISBN);
        }

    }
    catch (Exception e)
    {

    }
}

void GetBook3()
{
    try
    {
        using var context = new ApplicationDbContext();
        var book = context.Books.Single(b=>b.ISBN == "12123B12");
        Console.WriteLine(book!.Title + " - " + book.ISBN);
    }
    catch (Exception e)
    {

    }
}

void GetBook2()
{
    try
    {
        using var context = new ApplicationDbContext();
        var book = context.Books.Find(7);
        Console.WriteLine(book!.Title + " - " + book.ISBN);
    }
    catch (Exception e)
    {

    }
}

void GetBook()
{
    try
    {
        Book? book = null;
        using var context = new ApplicationDbContext();
        {
            //book = context.Books.Where(b => b.Title == "Cookie Jar").FirstOrDefault();
            book = context.Books.FirstOrDefault(b => b.Title == "Cookie Jar");
        }

        bool result = context == null;

        if(book == null)
        {
            Console.WriteLine("The book was not found");
        }
        Console.WriteLine(book!.Title + " - " + book.ISBN);
    }
    catch (Exception e)
    {

    }
}

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach(var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}

void AddBook()
{
    Book book = new() { Title = "New EF Core Book", ISBN = "1231231212", Price = 10.93m, Publisher_Id = 1 };
    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    context.SaveChanges();
}