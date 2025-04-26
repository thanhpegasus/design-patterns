namespace Visitor;

public class HtmlExporterVisitor : IDocumentVisitor
{
    public void Visit(TextElement textElement)
    {
        Console.WriteLine($"<p>{textElement.Text}</p>");
    }

    public void Visit(ImageElement imageElement)
    {
        Console.WriteLine($"<img src=\"{imageElement.ImagePath}\" />");
    }

    public void Visit(TableElement tableElement)
    {
        var html = "<table>";
        foreach (var row in tableElement.Rows)
        {
            html += "<tr>";
            foreach (var cell in row)
            {
                html += $"<td>{cell}</td>";
            }
            html += "</tr>";
        }
        html += "</table>";
        Console.WriteLine(html);
    }
}