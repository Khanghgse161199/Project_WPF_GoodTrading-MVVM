
using GoodTrading.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodTrading.Model.Service.AuthService
{
    class AuthService
    {
        private readonly GoodsTradingContext _context;
        private readonly Model.Service.HashService.HashService _hash;
        private readonly string serectkey = "asfakjsnfkjbaskjfbsa!@#!@#412415212";
        public AuthService()
        {
            _context = new GoodsTradingContext();
            _hash = new HashService.HashService();
        }
        public async Task<bool> Login(string username, string password)
        {
            var user = await _context.Users.Where(p => p.UserName == username && p.PassWord == _hash.SHA256(password + serectkey)).FirstOrDefaultAsync();

            // if token exist => update, else create new

            if (user != null)
            {
                try
                {
                    string accessToken = Guid.NewGuid().ToString();
                    var userToken = await _context.Tokens.Where(p => p.UserId == user.Id).FirstOrDefaultAsync();
                    if (userToken != null)
                    {
                        userToken.AccessToken = accessToken;
                        userToken.CreateDate = DateTime.Now;
                        userToken.IsActive = true;
                        _context.Tokens.Update(userToken);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        Token newToken = new Token()
                        {
                            AccessToken = accessToken,
                            CreateDate = DateTime.Now,
                            Id = Guid.NewGuid().ToString(),
                            IsActive = true,
                            UserId = user.Id,
                        };
                        await _context.Tokens.AddAsync(newToken);
                        await _context.SaveChangesAsync();
                    }
                    // save token to cache for later user
                    string currentPath = Directory.GetCurrentDirectory();
                    string filename = "cache.temp";
                    string fullpath = Path.Combine(currentPath, filename);
                    await File.WriteAllTextAsync(fullpath, accessToken);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }


            }
            else return false;
        }
    }
}
