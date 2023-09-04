namespace Calculator;

/// <summary>
/// Defines the ListStack,which implements IStack interface using custom list.
/// </summary>
public class ListStack : IStack
{
    private StackElement? head = null;

    /// <inheritdoc/>
    public void Push(double value)
        => this.head = new StackElement(value, this.head);

    /// <inheritdoc/>
    public bool TryPop(out double value)
    {
        if (this.head == null)
        {
            value = -1;
            return false;
        }

        value = this.head.Value;
        this.head = this.head.Next;
        return true;
    }

    private class StackElement
    {
        public StackElement(double value, StackElement? next)
        {
            this.Value = value;
            this.Next = next;
        }

        public double Value { get; set; }

        public StackElement? Next { get; set; }
    }
}
