public class CalculatorService
{
    private readonly ICalculatorLogger _logger;

    // Constructor (Dependency Injection)
    public CalculatorService(ICalculatorLogger logger)
    {
        _logger = logger;
    }

    public int Add(int a, int b)
    {
        _logger.Log("Addition performed");
        return a + b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException();

        return a / b;
    }
}