namespace RoachHotel.Mvc.Models
{
    public class Client
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}