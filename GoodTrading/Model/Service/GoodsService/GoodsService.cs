
using GoodTrading.Model.Entities;
using GoodTrading.TempModel.GoodModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodTrading.Model.Service.GoodsService
{

    internal class GoodsService
    {
        private readonly GoodsTradingContext _context;
        private readonly Service.TokenService.TokenService _token;
        public GoodsService()
        {
            _context = new GoodsTradingContext();
            _token = new TokenService.TokenService();
        }

        public async Task<List<Product>> GetUserAndPrice(double price)
        {
            var checkToken = await _token.checkToken();
            if(checkToken != null)
            {
                var goods = await _context.Products.Where(q => q.IsActive && (q.Price >= (price - 5000)) && (q.Price <= (price + 5000)) && q.UserId == checkToken.UserId).ToListAsync();
                if (goods != null)
                {
                    return goods;
                }
                else return null;
            }else return null;
        }

     
        public async Task<List<Product>> getExcepcurrentUserAsync()
        {
            
            var checkToken = await _token.checkToken();
            var listTest = await _context.Products.Where(q => q.UserId != checkToken.UserId).ToListAsync();
            if (checkToken != null)
            {
               
                var good = await _context.Products.Where(q => q.IsActive && q.UserId != checkToken.UserId).Include("User").ToListAsync();
                if (good != null)
                {
                    foreach (var item in good)
                    {
                        if (item.User == null)
                        {
                            var user = await _context.Users.Where(p => p.Id == item.UserId).FirstOrDefaultAsync();
                            item.User = user;
                        }
                    }
                    return good;
                }
                else return null;
            }
            else return null;
        }
        public async Task<List<Product>> FindByName(string name)
        {
            var checkToken = await _token.checkToken();
            if (checkToken != null)
            {
                var goods = await _context.Products.Where(q => q.IsActive == true && q.Name.Contains(name) && q.UserId != checkToken.UserId).Include("User").ToListAsync();
                if (goods.Count > 0)
                {
                    return goods;
                }
                else return null;
            }
            else return null;
        }
        public async Task<List<Product>> GetByCurrentUserAsync()
        {
            var checkToken = await _token.checkToken();
            if (checkToken != null)
            {
                var goods = await _context.Products.Where(q => q.IsActive && q.UserId == checkToken.UserId).ToListAsync();
                return goods;
            }
            else return null;
        }
        public async Task<bool> CreateGoods(GoodCreateModel good)
        {
            var checkToken = await _token.checkToken();
            if (checkToken != null)
            {
                Product newGood = new Product()
                {
                    Description = good.Description,
                    Id = Guid.NewGuid().ToString(),
                    IsActive = true,
                    Name = good.Name,
                    Price = good.Price,
                    UserId = checkToken.UserId,
                };
                await _context.Products.AddAsync(newGood);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

  

    }
}
