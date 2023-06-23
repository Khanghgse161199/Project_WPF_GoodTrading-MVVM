
using GoodTrading.Model.Entities;
using GoodTrading.TempModel.TokenModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodTrading.Model.Service.TokenService
{
    class TokenService
    {
       private readonly GoodsTradingContext _context;
        public TokenService()
        {
            _context = new GoodsTradingContext();
        }
        public async Task<bool> DeacTive()
        {
            string currentPath = Directory.GetCurrentDirectory();
            string fileName = "cache.temp";
            string fullPath = Path.Combine(currentPath, fileName);
            if (File.Exists(fullPath))
            {
                var token2 = await File.ReadAllTextAsync(fullPath);
                if (token2 != null)
                {


                    var tokenDb = await _context.Tokens.Where(p => p.AccessToken == token2).FirstOrDefaultAsync();
                    if (tokenDb != null)
                    {
                        tokenDb.IsActive = false;
                        _context.Tokens.Update(tokenDb);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else { return false; }
                }
                return false;
            }
            else return false;
        }
        public async Task<TokenResultModel> checkToken()
        {
            //get token from cache file
            string currentPath = Directory.GetCurrentDirectory();
            string fileName = "cache.temp";
            string fullPath = Path.Combine(currentPath, fileName);
            if (File.Exists(fullPath))
            {
                var token = await File.ReadAllTextAsync(fullPath);
                if (token != null)
                {
                    var validToken = await _context.Tokens.Where(q => q.AccessToken == token && q.IsActive).Include("User").FirstOrDefaultAsync();
                    if (validToken != null)
                    {
                        var day = (DateTime.Now - validToken.CreateDate).Days;
                        if (day <= 10)
                        {
                            TokenResultModel result = new TokenResultModel()
                            {
                                UserId = validToken.UserId,
                                UserName = validToken.User.UserName
                            };
                            return result;
                        }
                        else
                        {
                            return null;
                        }                  
                    }
                    else return null;
                }
                else return null;
            }
            else return null;
        }
    }
}
