using FinShark.Dtos.Stock;
using FinShark.Interfaces;
using FinShark.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace FinShark.Controllers;

[Route("api/stocks")]
[ApiController]
public class StockController(IStockRepository stockRepo) : ControllerBase
{
    
    // GET api/stock ---> Get all stocks
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await stockRepo.GetAllAsync();
        var stockDto = stocks.Select(s => s.ToStockDto()).ToList();
        
        return Ok(stockDto);
    }
    
    // GET api/stock/{id} ---> Get stock by id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var stock = await stockRepo.GetByIdAsync(id);
        
        if (stock is null)
        {
            return NotFound();
        }
        
        return Ok(stock.ToStockDto());
    }
    
    // POST api/stock ---> Create stock
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        var stock = await stockRepo.CreateAsync(stockDto.ToStockFromCreateRequestDto());
        
        // 201 Created
        // If created successfully, return the newly created resource
        return CreatedAtAction(nameof(GetById), new {id = stock.Id}, stock.ToStockDto());
    }
    
    // PUT api/stock/{id} ---> Update stock
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStockRequestDto stockDto)
    {
        var stock = await stockRepo.UpdateAsync(id, stockDto);

        if (stock is null)
        {
            return NotFound();
        }
        
        return Ok(stock.ToStockDto());
    }

    // DELETE api/stock/{id} ---> Delete stock
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var stock = await stockRepo.DeleteAsync(id);

        if (stock == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
}