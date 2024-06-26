﻿using Currency1.Server.Models;
using Currency1.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Currency1.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        ICurrencyService currencyService;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
            currencyService = new CurrencyRequestService();
        }

        [HttpGet(Name = "GetCurrency")]
        public async Task<IEnumerable<Currency>> Get()
        {
            var response = await currencyService.GetExchangeRates();

            return response!;
        }

        [HttpPost(Name = "PostRates")]
        public async Task<Response<decimal?>> Post([FromBody]RatesModel model)
        {
            try
            {
                var errors = model.Validate(new ValidationContext(model, null, null));
                if (errors.Any())
                    return new Response<decimal?>(null, ["Model is invalid"]);//TO DO: make errors more specific

                var getRateResult = await currencyService.GetRate(model.Amount, model.From, model.To, model.Date);//TO DO: retun

                return new Response<decimal?>(getRateResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response<decimal?>(null, ["No result found"]);//TO Fix: get error from api, log exception
            }
            
        }
    }
}
