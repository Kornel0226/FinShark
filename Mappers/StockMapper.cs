using FinShark.Dtos.Stock;
using FinShark.Models;

namespace FinShark.Mappers;

public static class StockMapper
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Price = stockModel.Price,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap
        };
    }

    public static Stock ToStockFromCreateRequestDto(this CreateStockRequestDto createStockRequestDto)
    {
        return new Stock
        {
            Symbol = createStockRequestDto.Symbol,
            CompanyName = createStockRequestDto.CompanyName,
            Price = createStockRequestDto.Price,
            LastDiv = createStockRequestDto.LastDiv,
            Industry = createStockRequestDto.Industry,
            MarketCap = createStockRequestDto.MarketCap
        };
    }
    
    public static Stock ToStockFromUpdateRequestDto(this UpdateStockRequestDto updateStockRequestDto)
    {
        return new Stock
        {
            Symbol = updateStockRequestDto.Symbol,
            CompanyName = updateStockRequestDto.CompanyName,
            Price = updateStockRequestDto.Price,
            LastDiv = updateStockRequestDto.LastDiv,
            Industry = updateStockRequestDto.Industry,
            MarketCap = updateStockRequestDto.MarketCap
        };
        
    }
}