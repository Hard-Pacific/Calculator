namespace Calculator;

/// <summary>
/// Defines the ArrayStack,which implements IStack interface using array.
/// </summary>
public class ArrayStack : IStack
{
    private double[] values;

    private int currentLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayStack"/> class that is empty and has a base capacity of 10.
    /// </summary>
    public ArrayStack()
    {
        this.currentLength = 0;
        this.values = new double[10];
    }

    /// <inheritdoc/>
    public void Push(double value)
    {
        if (this.currentLength >= this.values.Length)
        {
            this.Extend();
        }

        this.values[this.currentLength++] = value;
    }

    /// <inheritdoc/>
    public bool TryPop(out double value)
    {
        if (this.currentLength > 0)
        {
            value = this.values[--this.currentLength];
            return true;
        }

        value = -1;
        return false;
    }

    private void Extend()
    {
        Array.Resize(ref this.values, this.values.Length * 2);
    }
}
