using FinShark.Dtos.Stock;
using FinShark.Models;

namespace FinShark.Interfaces;

public interface IStockRepository
{
    Task<ICollection<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stock);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
    Task<Stock?> DeleteAsync(int id);
}