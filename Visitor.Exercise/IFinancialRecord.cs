namespace Visitor.Exercise;

public interface IFinancialRecord
{
    void Accept(IFinancialVisitor visitor);
}
