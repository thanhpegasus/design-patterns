namespace Visitor.Exercise;

public class ReceiptRecord : IFinancialRecord
{
    public required string ReceiptNumber { get; set; }

    public void Accept(IFinancialVisitor visitor)
    {
        visitor.Visit(this);
    }
}
