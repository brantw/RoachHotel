using FluentNHibernate.Mapping;
using RoachHotel.Data.Entities;

namespace RoachHotel.Data.Mappings
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