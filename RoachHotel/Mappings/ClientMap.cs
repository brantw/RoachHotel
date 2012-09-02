using FluentNHibernate.Mapping;
using RoachHotel.Mvc.Models;

namespace RoachHotel.Mvc.Mappings
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.PhoneNumber);
        }
    }
}