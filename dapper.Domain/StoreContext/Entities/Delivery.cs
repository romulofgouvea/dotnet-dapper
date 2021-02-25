using dapper.Domain.StoreContext.Enums;
using System;

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

        public void Ship()
        {
            // Se a Data estimada de entrega for no passado, n�o entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            // Se o status j� estiver entregue, n�o pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}