using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.DTOs.Stock;
using Project.Models;
using Project.Repositories.Contracts;

namespace Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IStockContract _contract;

    public StockController(DataContext context, IMapper mapper, IStockContract contract)
    {
        _context = context;
        _mapper = mapper;
        _contract = contract;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadDto>>> GetStocks()
    {
        return Ok(_mapper.Map<IEnumerable<ReadDto>>(await _contract.GetStocksAsync()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DetailDto>> GetStock(int id)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (stock == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<DetailDto>(stock));
    }

    [HttpPost]
    public async Task<ActionResult<Stock>> PostStock(CreateDto createDto)
    {
        var stock = _mapper.Map<Stock>(createDto);
        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStock), new { id = stock.Id }, stock);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStock(int id, UpdateDto updateDto)
    {
        if (id != updateDto.Id)
        {
            return BadRequest();
        }

        var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

        if (stock == null)
        {
            return NotFound();
        }

        _mapper.Map(updateDto, stock);

        try
        {
            _context.Update(stock);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StockExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        var stock = await _context.Stocks.FindAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StockExists(int id)
    {
        return _context.Stocks.Any(e => e.Id == id);
    }
}
