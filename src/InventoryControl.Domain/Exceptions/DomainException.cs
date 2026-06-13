namespace InventoryControl.Domain.Exceptions;

public class DomainException : InventoryControlException
{
    public DomainException(string message) : base(message)
    {
    }
}
