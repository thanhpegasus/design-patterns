namespace Visitor;

public class TextElement : IDocumentElement
{
    public required string Text { get; set; }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}
