using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
         Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<Stock, TResult>> selector, QueryObject query);
         Task<Stock?> GetByIdAsync(int id);
         Task<Stock> CreateAsync(Stock stockModel);
         Task <Stock?>UpdateAsync(int id, UpdateStockRequestDto stockDto);
         Task<Stock?>DeleteAsync(int id);
         Task<bool> StockExists(int id);
    }
}