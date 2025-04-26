namespace Visitor.Exercise;

public class RefundRecord : IFinancialRecord
{
    public required string RefundNumber { get; set; }

    public void Accept(IFinancialVisitor visitor)
    {
        visitor.Visit(this);
    }
}
