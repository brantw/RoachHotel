namespace RoachHotel.Data.Entities
{
    public class Task
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual Item Item { get; set; }
    }
}