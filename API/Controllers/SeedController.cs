using System.Globalization;
using API.Data.Models;
using Core.Entities;
using CsvHelper;
using Infrastructure.Context;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpPut]
        public async Task<IActionResult> SeedData()
        {
            try
            {
                var categories = SeedCategories();
                var categoryIds = _context.Categories.Select(c => c.CategoryId).ToList();

                var books = SeedBooks();
                var bookIds = _context.Books.Select(b => b.BookId).ToList();

                var bookCategories = SeedBookCategory(bookIds, categoryIds);

                var users = SeedUsers();
                var userIds = _context.Users.Select(u => u.UserId).ToList();

                var requests = SeedRequests(userIds);
                var requestIds = _context.Requests.Select(r => r.RequestId).ToList();

                var requestDetails = SeedRequestDetails(requestIds, bookIds);



                await _context.SaveChangesAsync();

                var result = new
                {
                    CategoryAdded = categories,
                    BookAdded = books,
                    BookCategoryAdded = bookCategories,
                    UserAdded = users,
                    RequestAdded = requests,
                    RequestDetailAdded = requestDetails
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during seeding: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        private static List<T> LoadDataFromCsv<T>(string fileName)
            where T : class
        {
            try
            {
                using (var reader = new StreamReader($"./Data/{fileName}.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv.GetRecords<T>().ToList();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from CSV: {ex.Message}");
                throw;
            }
        }

        private int SeedCategories()
        {
            var categories = LoadDataFromCsv<Category>("categories");
            var existingCategoryIds = _context.Categories.Select(c => c.CategoryId).ToHashSet();

            var newCategories = categories
                .Where(c => !existingCategoryIds.Contains(c.CategoryId))
                .ToList();
            _context.Categories.AddRange(newCategories);
            _context.SaveChanges();
            return newCategories.Count;
        }

        private int SeedBooks()
        {
            var bookDatas = LoadDataFromCsv<BookData>("books");
            var existingBookIds = _context.Books.Select(b => b.BookId).ToHashSet();

            var newBooks = bookDatas
                .Where(b => !existingBookIds.Contains(b.BookId))
                .Select(book => book.Adapt<Book>())
                .ToList();
            _context.Books.AddRange(newBooks);
            _context.SaveChanges();
            return newBooks.Count;
        }

        private int SeedBookCategory(List<Guid> bookIds, List<Guid> categoryIds)
        {
            var random = new Random();
            var bookCategories = new List<BookCategory>();

            for (int i = 0; i < 999; i++)
            {
                bookCategories.Add(
                    new BookCategory
                    {
                        BookId = bookIds[^(i + 1)],
                        CategoryId = categoryIds[random.Next(categoryIds.Count)]
                    }
                );
            }

            var newBookCategories = bookCategories
                .Where(bc =>
                    !_context.BookCategories.Any(b =>
                        b.BookId == bc.BookId && b.CategoryId == b.CategoryId
                    )
                )
                .ToList();

            _context.BookCategories.AddRange(newBookCategories);
            _context.SaveChanges();
            return newBookCategories.Count;
        }

        private int SeedUsers()
        {
            var userDatas = LoadDataFromCsv<UserData>("users");
            var existingUserIds = _context.Users.Select(u => u.UserId).ToHashSet();

            var newUsers = userDatas
                .Where(u => !existingUserIds.Contains(u.UserId))
                .Select(user => user.Adapt<User>())
                .ToList();
            _context.Users.AddRange(newUsers);
            _context.SaveChanges();
            return newUsers.Count;
        }

        private int SeedRequests(List<Guid> requestorIds)
        {
            var requestsData = LoadDataFromCsv<RequestData>("requests");
            var existingRequestIds = _context.Requests.Select(r => r.RequestId).ToHashSet();
            var random = new Random();

            var newRequests = requestsData
                .Where(r => !existingRequestIds.Contains(r.RequestId))
                .Select(request => new Request
                {
                    RequestId = request.RequestId,
                    RequestDate = request.RequestDate.ToUniversalTime(),
                    Status = request.Status,
                    RequestorId = requestorIds[random.Next(requestorIds.Count)],
                    ApproverId = Guid.Parse("79d3b7be-c7e7-4efc-befd-0c6c09cc9a8b")
                })
                .ToList();

            _context.Requests.AddRange(newRequests);
            _context.SaveChanges();
            return newRequests.Count;
        }

        private int SeedRequestDetails(List<Guid> requestIds, List<Guid> bookIds)
        {
            var random = new Random();
            var requestDetails = new List<RequestDetail>();

            for (int i = 0; i < 999; i++)
            {
                requestDetails.Add(
                    new RequestDetail
                    {
                        RequestId = requestIds[^(i + 1)],
                        BookId = bookIds[random.Next(bookIds.Count)],
                    }
                );
            }

            var newRequestDetails = requestDetails
                .Where(rd =>
                    !_context.RequestDetails.Any(r =>
                        r.RequestId == rd.RequestId && r.BookId == rd.BookId
                    )
                )
                .ToList();

            _context.RequestDetails.AddRange(newRequestDetails);
            _context.SaveChanges();
            return newRequestDetails.Count;
        }

    }
}