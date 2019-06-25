using HotelWpfMVVM.Model;
using System.Data.Entity.ModelConfiguration;

namespace HotelWpfMVVM.HotelDBContext
{
    public class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            Property(client => client.Account).IsOptional().HasMaxLength(20);
            HasRequired(client => client.Room).WithMany(room => room.Clients).WillCascadeOnDelete(true);

            ToTable("Clients");
        }
    }
}
