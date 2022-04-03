using System;
using Xulqna.Domain.Enums;

namespace Xulqna.Domain.Commons
{
    public interface IAuditable
    {
        public Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        Guid? UpdatedBy { get; set; }
        ItemState State { get; set; }
    }
}
