using FluentNHibernate.Mapping;
using RoachHotel.Mvc.Models;

namespace RoachHotel.Mvc.Mappings
{
    public class ItemMap : ClassMap<Item>
    {
         public ItemMap()
         {
             Id(x => x.Id);
             Map(x => x.Name);
             Map(x => x.Description);
             Map(x => x.AssignedTo);
             References(x => x.Client);
             HasMany(x => x.Tasks)
                 .Inverse()
                 .Cascade.All();
         }
    }
}