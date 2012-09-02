using FluentNHibernate.Mapping;
using RoachHotel.Data.Entities;

namespace RoachHotel.Data.Mappings
{
    public class ItemMap : ClassMap<Item>
    {
         public ItemMap()
         {
             Id(x => x.Id);
             Map(x => x.Name);
             Map(x => x.Description);
             HasMany(x => x.Tasks)
                 .Inverse()
                 .Cascade.All();
         }
    }
}