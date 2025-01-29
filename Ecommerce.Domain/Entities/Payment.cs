﻿namespace Ecommerce.Domain.Entities;

internal class Payment
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public float TotalPaid { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public Order Order { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
