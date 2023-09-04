namespace Calculator;

/// <summary>
/// LIFO queue interface.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Adds a number to the top of the stack.
    /// </summary>
    /// <param name="value">A number to be added to the top of the stack.</param>
    void Push(double value);

    /// <summary>
    /// Returns a value that indicates whether there is an object at the top of the Stack, and if one is present, copies it to the result parameter, and removes it from the Stack.
    /// </summary>
    /// <param name="value">The number at the top of the Stack.</param>
    /// <returns>True if the stack is not empty, false otherwise.</returns>
    bool TryPop(out double value);
}