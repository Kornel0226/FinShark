using FinShark.Data;
using FinShark.Dtos.Stock;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository;

public class StockRepository(ApplicationDBContext context) : IStockRepository
{
    
    public async Task<ICollection<Stock>> GetAllAsync()
    {
       return await context.Stocks.ToListAsync();
    }

     public async Task<Stock?> GetByIdAsync(int id)
    {
        return await context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Stock> CreateAsync(Stock stock)
    {
        await context.Stocks.AddAsync(stock);
        await context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
    {
        var stock = await context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (stock is null) return null;
        
        // Note: This might overwrite properties incorrectly if ToStockFromUpdateRequestDto creates a new object.
        // Usually, mapping libraries update the *existing* entity.
        // Assuming manual mapping or proper assignment here:
        stock.Symbol = stockDto.Symbol;
        stock.CompanyName = stockDto.CompanyName;
        stock.Price = stockDto.Price; // Assuming non-nullable for standard PUT
        stock.LastDiv = stockDto.LastDiv;
        stock.Industry = stockDto.Industry;
        stock.MarketCap = stockDto.MarketCap;
        
        // _context.Stocks.Update(stock); // Not strictly necessary if tracking is enabled, but harmless
        await context.SaveChangesAsync();
        
        return stock;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stock = await context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

        if (stock is null) return null;
        
        // Remove is not an asynchronous function, so we need to await it explicitly
        context.Stocks.Remove(stock);
        await context.SaveChangesAsync();
        
        return stock;
    }
}