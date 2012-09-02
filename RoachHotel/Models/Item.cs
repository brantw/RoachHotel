using System.Collections.Generic;

namespace RoachHotel.Mvc.Models
{
    public class Item
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string AssignedTo { get; set; }
        public virtual Client Client { get; set; }
        public virtual IList<Task> Tasks { get; protected set; }

        public Item()
        {
            Tasks = new List<Task>();
        }

        public virtual void AddTask(Task task)
        {
            task.Item = this;
            Tasks.Add(task);
        }
    }
}