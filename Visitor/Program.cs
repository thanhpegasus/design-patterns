namespace Visitor;

class Program
{
    static void Main(string[] args)
    {
        var documentElements = new List<IDocumentElement>
        {
            new TextElement { Text = "Hello, World!" },
            new ImageElement { ImagePath = "image.png" },
            new TableElement { Rows = new List<string[]> { new[] { "Header1", "Header2" }, new[] { "Row1Col1", "Row1Col2" } } }
        };

        var htmlExporterVisitor = new HtmlExporterVisitor();
        foreach (var element in documentElements)
        {
            element.Accept(htmlExporterVisitor);
        }
    }
}