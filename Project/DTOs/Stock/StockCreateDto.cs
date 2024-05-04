﻿namespace Project.DTOs.Stock;

public class StockCreateDto
{
    public string Symbol { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public decimal Purchase { get; set; }
    public decimal LastDividend { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCapital { get; set; }
}