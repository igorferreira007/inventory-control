namespace InventoryControl.Domain.Exceptions;

public abstract class InventoryControlException : Exception
{
    protected InventoryControlException(string message) : base(message)
    {
    }
}
