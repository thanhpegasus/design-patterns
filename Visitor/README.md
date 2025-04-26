# Visitor Pattern

## Step 1: Example Problem
Imagine you're building a document editor. In your system, you have different types of document elements, like:
* Plain text
* Images
* Tables
Now, suppose you want to perform different operations on these elements like:
* Export to HTML
* Export to PDF
* Spell check
* Word count

## Step 2: Solution + Basic Implementation
The **Visitor Pattern** lets you define a new operation without changing the classes of the elements on which it operates.

Let’s walk through a basic implementation of the problem above (in C# syntax).

🧱 Document Element Interfaces

```csharp
public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
}
```

🖊 Text, 🖼 Image, 📊 Table

```csharp
public class TextElement : IDocumentElement
{
    public string Text { get; set; }
    public void Accept(IDocumentVisitor visitor) => visitor.Visit(this);
}

public class ImageElement : IDocumentElement
{
    public string ImagePath { get; set; }
    public void Accept(IDocumentVisitor visitor) => visitor.Visit(this);
}

public class TableElement : IDocumentElement
{
    public List<string[]> Rows { get; set; }
    public void Accept(IDocumentVisitor visitor) => visitor.Visit(this);
}
```

🔍 Visitor Interface

```csharp
public interface IDocumentVisitor
{
    void Visit(TextElement text);
    void Visit(ImageElement image);
    void Visit(TableElement table);
}
```

🖨 Example Visitor: HTML Exporter

```csharp
public class HtmlExporter : IDocumentVisitor
{
    public void Visit(TextElement text) => Console.WriteLine($"<p>{text.Text}</p>");
    public void Visit(ImageElement image) => Console.WriteLine($"<img src='{image.ImagePath}' />");
    public void Visit(TableElement table)
    {
        Console.WriteLine("<table>");
        foreach (var row in table.Rows)
        {
            Console.WriteLine("<tr>" + string.Join("", row.Select(cell => $"<td>{cell}</td>")) + "</tr>");
        }
        Console.WriteLine("</table>");
    }
}
```

🧪 Now, each new operation (like SpellCheckerVisitor, PdfExporterVisitor, etc.) is added without modifying the document elements. Clean and open for extension!

## Step 3: Definition + UML Diagram

### 📘 Definition of Visitor Pattern

> Visitor Pattern is a behavioral design pattern that lets you separate algorithms from the objects on which they operate.

In short:
* It allows you to add new operations to a group of objects without changing the objects themselves.
* It works well when you have a fixed object structure and you want to perform a growing list of operations on those objects.

### 📊 UML Diagram (simplified):

```pgsql
            +--------------------+          +---------------------+
            | IDocumentElement   |<>--------| IDocumentVisitor    |
            | + Accept(visitor)  |          | + Visit(Text)       |
            +--------------------+          | + Visit(Image)      |
                   /   |   \                | + Visit(Table)      |
                  /    |    \               +---------------------+
                 ↓     ↓     ↓                       
     +-------------+  +-------------+  +---------------+
     | TextElement |  | ImageElement|  | TableElement  |
     +-------------+  +-------------+  +---------------+
     | +Accept()   |  | +Accept()   |  | +Accept()     |
     +-------------+  +-------------+  +---------------+
```
* The IDocumentElement defines an Accept() method that takes a visitor.
* Concrete elements implement Accept() by calling visitor.Visit(this).
* The IDocumentVisitor interface defines Visit() overloads for each element type.

### ❓Quick Check:
Why do each of the Accept() methods in the element classes call visitor.Visit(this)?

### ✅ Here’s the answer:
Each element’s Accept() method calls visitor.Visit(this) to achieve double dispatch.

Why is that important?
* Single dispatch (like regular method calls in C#) chooses the method based on the runtime type of the object you're calling it on.
* But in the Visitor Pattern, we want to choose the right method based on two things:
    1. The type of the element (TextElement, ImageElement, etc.)
    2. The type of the visitor (HtmlExporter, PdfExporter, etc.)

## Step 4: Real Problem + Implementation
Let’s now work through a small real-world implementation you write yourself.
Here’s your challenge 👇

### 💼 Real-World Exercise
You're designing a report generator for a system that supports different types of financial records:
* Invoice
* Receipt
* Refund

Each record needs to support:
* Export to PDF
* Export to CSV

Implement this using the **Visitor Pattern**.

💡HINT: the implementation is in the Visitor.Exercise project

## Step 5: Pros & Cons

### 👍 Pros of Visitor Pattern
* ✅ Open for extension: You can add new operations (visitors) without touching existing element classes.
* ✅ Separation of concerns: Keeps business logic out of the core data structures.
* ✅ Centralizes operations: Related logic is grouped in one place (visitors), making maintenance easier.

### 👎 Cons of Visitor Pattern
* 🚫 Hard to add new element types: Every new element (e.g., TaxRecord) requires updating every existing visitor.
* 🧩 Boilerplate overload: Requires a lot of interfaces and method overloads for each element type.
* 🔄 Breaks encapsulation sometimes: Visitors may need to access internal data of elements, which could violate encapsulation.

## Step 6: When To & When NOT To Use It

Use the Visitor Pattern when:
* You have a fixed set of element types, but you need to add new operations frequently.
* You want to cleanly separate algorithms from the data structures.
* You need double dispatch behavior in a statically typed language like C# or Java.

Avoid the Visitor Pattern when:
* You expect the element classes to change often (adding a new type means updating every visitor).
* You have only a few operations, and it’s simpler to keep them inside the element classes.
* You want to minimize complexity and boilerplate in small projects.