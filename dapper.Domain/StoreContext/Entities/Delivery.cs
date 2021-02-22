using System;
using dapper.Domain.StoreContext.Enums;

namespace dapper.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public Delivery(DateTime estimated)
        {
            CreateDate = DateTime.Now;
            Status = EDeliveryStatus.Waiting;

            EstimatedDeliveryDate = estimated;
        }
    }
}