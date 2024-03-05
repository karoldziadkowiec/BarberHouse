using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Repositories.Interfaces;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;

namespace BarberHouse.Repositories.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<User>> GetAllUsers()
            => await Task.FromResult(_context.Users.OrderBy(u => u.Id));

        public async Task<User> GetUserById(int userId)
            => await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public async Task<IEnumerable<User>> GetUsersByGroupId(int groupId)
            => await _context.Users.Where(u => u.GroupId == groupId).ToListAsync();

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Phone = user.Phone;
                existingUser.Birthday = user.Birthday;
                existingUser.Address = user.Address;
                existingUser.GroupId = user.GroupId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveUser(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<byte[]> GetUsersCsvBytes()
        {
            var users = await _context.Users.ToListAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");

                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Name";
                worksheet.Cell(1, 3).Value = "Surname";
                worksheet.Cell(1, 4).Value = "E-mail";
                worksheet.Cell(1, 5).Value = "Password";
                worksheet.Cell(1, 6).Value = "Phone";
                worksheet.Cell(1, 7).Value = "Birthday";
                worksheet.Cell(1, 8).Value = "Address";
                worksheet.Cell(1, 9).Value = "Group";

                var row = 2;
                foreach (var user in users)
                {
                    var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == user.Id);

                    worksheet.Cell(row, 1).Value = user.Id;
                    worksheet.Cell(row, 2).Value = user.Name;
                    worksheet.Cell(row, 3).Value = user.Surname;
                    worksheet.Cell(row, 4).Value = user.Email;
                    worksheet.Cell(row, 5).Value = "-";
                    worksheet.Cell(row, 6).Value = user.Phone;
                    worksheet.Cell(row, 7).Value = user.Birthday.ToShortDateString();
                    worksheet.Cell(row, 8).Value = user.Address;
                    worksheet.Cell(row, 9).Value = group.Name;
                    row++;
                }

                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.Position = 0;
                    return memoryStream.ToArray();
                }
            }
        }

        public async Task<IEnumerable<User>> SearchUser(string searchTerm)
            => await Task.FromResult(_context.Users.Where(u => u.Name == searchTerm || u.Surname == searchTerm));

        public async Task<IEnumerable<User>> SearchPartial(string searchTerm)
        {
            return await _context.Users
                .Where(u => u.Name.Contains(searchTerm) || u.Surname.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task ModifyToBarber(User user)
        {
            string barberName = "Barber";
            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Name == barberName);
            var existingUser = await _context.Users.FindAsync(user.Id);

            if (existingUser != null && group != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Phone = user.Phone;
                existingUser.Birthday = user.Birthday;
                existingUser.Address = user.Address;
                existingUser.GroupId = group.Id;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromBarber(User user)
        {
            string userName = "User";
            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Name == userName);
            var existingUser = await _context.Users.FindAsync(user.Id);

            if (existingUser != null && group != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Phone = user.Phone;
                existingUser.Birthday = user.Birthday;
                existingUser.Address = user.Address;
                existingUser.GroupId = group.Id;

                await _context.SaveChangesAsync();
            }
        }
    }
}
