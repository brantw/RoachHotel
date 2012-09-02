using FluentNHibernate.Mapping;
using RoachHotel.Mvc.Models;

namespace RoachHotel.Mvc.Mappings
{
    public class TaskMap : ClassMap<Task>
    {
         public TaskMap()
         {
             Id(x => x.Id);
             Map(x => x.Name);
             References(x => x.Item);
         }
    }
}