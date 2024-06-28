using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpendWise_Server.Business.Services;

namespace SpendWise_Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private readonly CurrenciesService _currenciesService;
    private readonly ILogger _logger;
    public CurrenciesController(CurrenciesService currenciesService, ILogger logger)
    {
        _currenciesService = currenciesService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCurrencyById(int id){
        var currency = await _currenciesService.GetCurrency(id);
        return Ok(currency);
    }
    [HttpGet]
    public async Task<IActionResult> GetCurrencies(){
        var listOfCurrencies = await _currenciesService.GetCurrencies();
        return Ok(listOfCurrencies);
    }

}