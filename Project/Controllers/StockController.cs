using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs.Stock;
using Project.Models;
using Project.Repositories.Contracts;

namespace Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IStockContract _contract;

    public StockController(IMapper mapper, IStockContract contract)
    {
        _mapper = mapper;
        _contract = contract;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StockReadDto>>> GetStocks()
    {
        return Ok(_mapper.Map<IEnumerable<StockReadDto>>(await _contract.GetStocksAsync()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StockDetailDto>> GetStock(int id)
    {
        var stock = await _contract.GetStockAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<StockDetailDto>(stock));
    }

    [HttpPost]
    public async Task<ActionResult<Stock>> PostStock(StockCreateDto createDto)
    {
        var stock = await _contract.AddStockAsync(_mapper.Map<Stock>(createDto));
        return CreatedAtAction(nameof(GetStock), new { id = stock.Id }, stock);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutStock(int id, StockUpdateDto updateDto)
    {
        if (id != updateDto.Id)
        {
            return BadRequest();
        }

        var stock = _mapper.Map<Stock>(updateDto);

        try
        {
            await _contract.UpdateStockAsync(id, stock);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        try
        {
            await _contract.DeleteStockAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
