using System. Collections.Generic;

namespace Visitor.Exercise;
class Program
{
    static void Main(string[] args)
    {
        // Create a list of financial records
        var records = new List<IFinancialRecord>
        {
            new InvoiceRecord
            {
                InvoiceNumber = "INV001",
            },
            new ReceiptRecord
            {
                ReceiptNumber = "REC001",
            },
            new RefundRecord
            {
                RefundNumber = "REF001",
            }
        };


        var csvExporterVisitor = new CsvExporterVisitor();
        foreach (var record in records)
        {
            record.Accept(csvExporterVisitor);
        }
    }
}