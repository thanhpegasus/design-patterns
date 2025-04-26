using System;

namespace Visitor.Exercise;

public class CsvExporterVisitor : IFinancialVisitor
{
    public void Visit(InvoiceRecord invoiceRecord)
    {
        // Export invoice record to CSV format
        Console.WriteLine($"Invoice, {invoiceRecord.InvoiceNumber}");

    }
    public void Visit(ReceiptRecord receiptRecord)
    {
        // Export receipt record to CSV format
        Console.WriteLine($"Receipt, {receiptRecord.ReceiptNumber}");
    }

    public void Visit(RefundRecord refundRecord)
    {
        // Export refund record to CSV format
        Console.WriteLine($"Refund, {refundRecord.RefundNumber}");
    }
}
