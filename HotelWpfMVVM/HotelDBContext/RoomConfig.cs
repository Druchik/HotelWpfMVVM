using HotelWpfMVVM.Model;
using System.Data.Entity.ModelConfiguration;

namespace HotelWpfMVVM.HotelDBContext
{
    public class RoomConfig : EntityTypeConfiguration<Room>
    {
        public RoomConfig()
        {
            HasKey(room => room.RoomId);
            Property(room => room.RoomNumber).IsRequired().HasMaxLength(5);
            Property(room => room.RoomType).IsRequired();

            ToTable("Rooms");
        }
    }
}
