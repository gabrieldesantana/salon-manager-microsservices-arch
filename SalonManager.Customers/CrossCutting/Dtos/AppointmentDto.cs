using SalonManager.Customers.Core.Entities;
using SalonManager.Customers.CrossCutting.Enums;

namespace SalonManager.Customers.CrossCutting.Dtos
{
    public class AppointmentDto
    {

        public Guid EmployeeAppointmentId { get; set; }
        public Guid CustomerAppointmentId { get; set; }
        public Guid ServiceAppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public EAppointmentStatus Status { get; set; }
        public string? Details { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentWay { get; set; }
        public double Earnings { get; set; }

        public bool Finished { get; set; }
        public DateTime? FinishedDate { get; set; }

        #region BaseEntity
        public Guid Id { get; set; }
        //public DateTime CreatedAt { get; set; }

        public Guid TenantId { get; set; }
        //public Guid UserCreatorId { get; set; }

        //public DateTime UpdatedAt { get; set; }
        //public bool IsActived { get; set; }

        #endregion  
    }
}
