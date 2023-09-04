namespace Calculator.Tests;

public class CalculatorTest
{
    private static readonly object[] WrongInputsTest =
    {
            new object[] { "Wrong Expression", -1, "" },
            new object[] { "Wrong Expression", -1, "bla bla bla 123" },
            new object[] { "Wrong Expression", -1, "1 2 3 +" },
            new object[] { "Wrong Expression", -1, "1 2 ^" },
        };

    private static readonly object[] DivisionByZeroTest =
    {
            new object[] { "Error! Division by zero", -1, "123 1 1 - /"},
            new object[] { "Error! Division by zero", -1, "10 1 999999 / /"},
            new object[] { "Error! Division by zero", -1, "123 5 2 3 + - /"},
        };

    private static readonly object[] CalculationTest =
    {
            new object[] { "ok", 3, "1 2 +" },
            new object[] { "ok", 5, "1 2 3 + *" },
    };

    [Test, TestCaseSource(nameof(WrongInputsTest)), TestCaseSource(nameof(DivisionByZeroTest)), TestCaseSource(nameof(CalculationTest))]
    public void TestStacks(string expectMsg, double expectValue, string s)
    {
        Assert.Multiple(() =>
        {
            Assert.That(Calculator.Calculate(s, new ArrayStack()), Is.EqualTo((expectMsg, expectValue)));
            Assert.That(Calculator.Calculate(s, new ListStack()), Is.EqualTo((expectMsg, expectValue)));
        });
    }
}