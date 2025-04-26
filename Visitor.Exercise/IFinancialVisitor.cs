namespace Visitor.Exercise;

public interface IFinancialVisitor
{
    void Visit(InvoiceRecord invoiceRecord);
    void Visit(ReceiptRecord receiptRecord);
    void Visit(RefundRecord refundRecord);
}