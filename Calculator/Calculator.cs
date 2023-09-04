namespace Calculator;

/// <summary>
/// Defines a static class which provides a method to calculate an expression in Postfix Polish Notation.
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Calculates an expression in Postfix Polish Notation.
    /// </summary>
    /// <param name="expression">The PPN expression.</param>
    /// <param name="stack">Stack data structure.</param>
    /// <returns>A tuple that contains a calculation status message and the result of the calculation.</returns>
    public static (string, double) Calculate(string expression, IStack stack)
    {
        string[] commands = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var command in commands)
        {
            if (int.TryParse(command, out int valueIn))
            {
                stack.Push(valueIn);
                continue;
            }

            if (stack.TryPop(out double valueOut2) && stack.TryPop(out double valueOut1))
            {
                switch (command)
                {
                    case "+":
                        stack.Push(valueOut1 + valueOut2);
                        break;
                    case "-":
                        stack.Push(valueOut1 - valueOut2);
                        break;
                    case "*":
                        stack.Push(valueOut1 * valueOut2);
                        break;
                    case "/":
                        if (Math.Abs(valueOut2) < .001)
                        {
                            return ("Error! Division by zero", -1);
                        }

                        stack.Push(valueOut1 / valueOut2);
                        break;
                    default:
                        return ("Wrong Expression", -1);
                }

                continue;
            }

            return ("Wrong Expression", -1);
        }

        return stack.TryPop(out double result) && !stack.TryPop(out _) ?
            ((string, double))("ok", result) :
            ("Wrong Expression", -1);
    }
}
