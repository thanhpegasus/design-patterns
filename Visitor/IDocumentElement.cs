namespace Visitor;

public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
}