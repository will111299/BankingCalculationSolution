using Banking.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BonusCalculationApi.Controllers;

public class BonusCalculationController : ControllerBase
{
    private readonly ICalculateBonusesForAccounts _bonusCalculator;

    public BonusCalculationController(ICalculateBonusesForAccounts bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    [HttpGet("/bonuscalculations")]
    public ActionResult GetBonusFor([FromQuery] decimal balance, [FromQuery] decimal amount)
    {
        var bonus = _bonusCalculator.AccountDepositOf(balance, amount);
        var response = new GetBonusResponse(balance, amount, bonus);
        return Ok(response);
    }
}


public record GetBonusResponse(decimal balance, decimal amount, decimal bonusEarned);