
using GoodTrading.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodTrading.Model.Service.UserService
{
    class UserService
    {
        private readonly GoodsTradingContext _context;
        private readonly Service.HashService.HashService _hashService;
        private readonly string serectkey = "asfakjsnfkjbaskjfbsa!@#!@#412415212";
        public UserService()
        {
            _context = new GoodsTradingContext();
            _hashService = new HashService.HashService();
        }
        public async Task<bool> CreateUser(User user)
        {
            // check duplicate username
            var userInDB = await _context.Users.Where(p => p.UserName == user.UserName).FirstOrDefaultAsync();
            if(userInDB == null)
            {
                user.PassWord = _hashService.SHA256(user.PassWord + serectkey);
                user.Id = Guid.NewGuid().ToString();
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }else return false;
        }
    }
}
