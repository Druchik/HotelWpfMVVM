using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System.Linq;
using System.Windows;

namespace HotelWpfMVVM.CMDs
{
    class UpdateRoomCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public UpdateRoomCommand(HotelContext context) => Context = context;

        public override bool CanExecute(object parameter) => (parameter as Room) != null &&
                !string.IsNullOrEmpty((parameter as Room).RoomNumber) &&
                (parameter as Room).RoomType != RoomTypes.None;

        public override void Execute(object parameter)
        {
            Room room = Context.Rooms.Local.SingleOrDefault(r => r.RoomId == ((Room)parameter).RoomId);
            if (room != null)
            {
                room.RoomNumber = ((Room)parameter).RoomNumber;
                room.RoomType = ((Room)parameter).RoomType;
                Context.SaveChanges();
            }
            else
                MessageBox.Show("Упс...");
        }
    }
}
