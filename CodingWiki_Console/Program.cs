// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

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
GetBook2();

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