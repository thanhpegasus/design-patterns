namespace Visitor;

public class TableElement : IDocumentElement
{
    public List<string[]> Rows { get; set; } = new ();

    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}
