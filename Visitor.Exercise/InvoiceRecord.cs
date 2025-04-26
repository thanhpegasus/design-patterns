namespace Visitor.Exercise;

public class InvoiceRecord : IFinancialRecord
{
    public required string InvoiceNumber { get; set; }

    public void Accept(IFinancialVisitor visitor)
    {
        visitor.Visit(this);
    }
}
