namespace Ecommerce.Service.Contracts;

public class PaymentRequest
{
    public Guid StatusId {  get; set; }
    public float TotalPayable {  get; set; }
    public float TotalPaid { get; set; }
    public string? Note { get; set; }
    public int InstallmentsNumber { get; set; }
}

public class PaymentHistoryRequest
{
    public Guid PaymentId {  get; set; }
    public Guid StatusId {  get; set; }
    public float TotalPaid { get; set; }
    public string? Note { get; set; }
}
