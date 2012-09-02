namespace RoachHotel.Mvc.Models
{
    public class Task
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual Item Item { get; set; }
    }
}