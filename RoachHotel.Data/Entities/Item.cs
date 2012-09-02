using System.Collections.Generic;

namespace RoachHotel.Data.Entities
{
    public class Item
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Task> Tasks { get; private set; }

        public Item()
        {
            Tasks = new List<Task>();
        }
    }
}
