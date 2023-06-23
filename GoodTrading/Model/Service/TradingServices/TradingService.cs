
using GoodTrading.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodTrading.Model.Service.TradingServices
{
    internal class TradingService
    {
        private readonly GoodsTradingContext _context;
        private readonly Service.TokenService.TokenService _tokenService;
        public TradingService()
        {
            _context = new GoodsTradingContext();
            _tokenService = new Service.TokenService.TokenService();
        }

        public async Task<bool> Trade(string fromProduct, string toProduct)
        {
            var checkTOken = await _tokenService.checkToken();
            if (checkTOken != null)
            {
                var fromProducts = await _context.Products.Where(p => p.Id == fromProduct && p.IsActive ).FirstOrDefaultAsync();
                var toProducts = await _context.Products.Where(p => p.Id == toProduct && p.IsActive && p.UserId == checkTOken.UserId).FirstOrDefaultAsync();
                if (fromProducts != null && toProducts != null)
                {
                    var currentUser = await _context.Users.Where(p => p.Id == checkTOken.UserId).FirstOrDefaultAsync();
                    var anothderUser = await _context.Users.Where(p => p.Id == fromProducts.UserId).FirstOrDefaultAsync();
                    string userToProductUserId = checkTOken.UserId;
                    toProducts.UserId = fromProducts.UserId;
                    fromProducts.UserId = userToProductUserId;
                   
                    _context.Products.Update(fromProducts);
                    _context.Products.Update(toProducts);
                    var listTest = await _context.Products.Where(p => p.UserId != checkTOken.UserId).ToListAsync();
                    TrandingHistory newHistory = new TrandingHistory()
                    {
                        FromGood = fromProduct,
                        FromUser = fromProducts.UserId,
                        ToGood = toProduct,
                        ToUser = toProducts.UserId,
                        Id = Guid.NewGuid().ToString(),
                        CreateDate = DateTime.Now,
                    };
                    await _context.TrandingHistories.AddAsync(newHistory);
                    await _context.SaveChangesAsync();  
                    return true;
                }
                else return false;

            }
            else return false;
        }
    }

   
}
