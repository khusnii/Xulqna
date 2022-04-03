using System;
using Xulqna.Domain.Commons;
using Xulqna.Domain.Enums;

namespace Xulqna.Domain.Entities.Departaments
{
    public class EmployeeSalary : IAuditable
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
