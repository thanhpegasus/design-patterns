namespace Visitor;

public class ImageElement : IDocumentElement
{
    public required string ImagePath { get; set; }

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}
