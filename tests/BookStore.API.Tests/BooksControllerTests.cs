using System;
using System.Collections.Generic;
using AutoMapper;
using BookStore.API.Controllers;
using BookStore.API.Dtos.Book;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using Moq;

namespace BookStore.API.Tests
{
    public class BooksControllerTests
    {
        private readonly BooksController _booksController;
        private readonly Mock<IBookService> _bookServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public BooksControllerTests()
        {
            _bookServiceMock = new Mock<IBookService>();
            _mapperMock = new Mock<IMapper>();
            _booksController = new BooksController(_mapperMock.Object, _bookServiceMock.Object);
        }

        private Book CreateBook()
        {
            return new Book()
            {
                Id = 2,
                Name = "Book Test",
                Author = "Author Test",
                Description = "Description Test",
                Value = 10,
                CategoryId = 1,
                PublishDate = DateTime.MinValue.AddYears(40),
                Category = new Category()
                {
                    Id = 1,
                    Name = "Category Test"
                }
            };
        }

        private BookResultDto MapModelToBookResultDto(Book book)
        {
            var bookDto = new BookResultDto()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                PublishDate = book.PublishDate,
                Value = book.Value,
                CategoryId = book.CategoryId
            };
            return bookDto;
        }

        private List<Book> CreateBookList()
        {
            return new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Name = "Book Test 1",
                    Author = "Author Test 1",
                    Description = "Description Test 1",
                    Value = 10,
                    CategoryId = 1
                },
                new Book()
                {
                    Id = 1,
                    Name = "Book Test 2",
                    Author = "Author Test 2",
                    Description = "Description Test 2",
                    Value = 20,
                    CategoryId = 1
                },
                new Book()
                {
                    Id = 1,
                    Name = "Book Test 3",
                    Author = "Author Test 3",
                    Description = "Description Test 3",
                    Value = 30,
                    CategoryId = 2
                }
            };
        }

        private List<BookResultDto> MapModelToBookResultListDto(List<Book> books)
        {
            var listBooks = new List<BookResultDto>();

            foreach (var item in books)
            {
                var book = new BookResultDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Author = item.Author,
                    Description = item.Description,
                    PublishDate = item.PublishDate,
                    Value = item.Value,
                    CategoryId = item.CategoryId
                };
                listBooks.Add(book);
            }
            return listBooks;
        }
    }
}