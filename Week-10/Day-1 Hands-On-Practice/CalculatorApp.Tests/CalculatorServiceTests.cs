using Moq;
using NUnit.Framework;
using System.Timers;

[TestFixture]
public class CalculatorServiceTests
{
    private Mock<ICalculatorLogger> _mockLogger;
    private CalculatorService _service;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ICalculatorLogger>();
        _service = new CalculatorService(_mockLogger.Object);
    }

    [Test]
    public void Add_ReturnsCorrectSum()
    {
        int a = 5, b = 3;
        var result = _service.Add(a, b);
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Add_CallsLogger()
    {
        _service.Add(2, 3);
        _mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void Divide_ReturnsCorrectResult()
    {
        var result = _service.Divide(10, 2);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _service.Divide(10, 0));
    }
}