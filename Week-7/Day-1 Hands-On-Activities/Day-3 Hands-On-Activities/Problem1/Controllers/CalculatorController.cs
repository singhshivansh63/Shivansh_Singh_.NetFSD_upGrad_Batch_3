using Microsoft.AspNetCore.Mvc;

[Route("calc")]
public class CalculatorController : Controller
{
 
    [HttpGet("add")]
    public IActionResult Add()
    {
        return View();
    }

   
    [HttpPost("add")]
    public IActionResult Add(int num1, int num2)
    {
        int sum = num1 + num2;

        ViewData["Num1"] = num1;
        ViewData["Num2"] = num2;
        ViewData["Result"] = sum;

        return View();
    }
}