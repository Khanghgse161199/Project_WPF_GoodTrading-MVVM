using GoodTrading.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodTrading.Model.Service.HistoryService
{
    internal class Hisrotyservice
    {
        private readonly GoodsTradingContext _context;

        public Hisrotyservice()
        {
            _context = new GoodsTradingContext();
        }

        public async Task<List<TrandingHistory>> getHistoryLists(string idUser)
        {
            var listHistoryItem = await _context.TrandingHistories.Where(p => p.FromUser == idUser).ToListAsync();
            if (listHistoryItem != null)
            {
                return listHistoryItem;
            }
            else return null;
        }
    }
}
