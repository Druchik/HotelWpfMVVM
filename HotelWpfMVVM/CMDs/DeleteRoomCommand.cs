using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System.Linq;
using System.Windows;

namespace HotelWpfMVVM.CMDs
{
    class DeleteRoomCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public DeleteRoomCommand(HotelContext context) => Context = context;

        public override bool CanExecute(object parameter) => (parameter as Room) != null && (parameter as Room).RoomType != 0;

        public override void Execute(object parameter)
        {
            Room room = Context.Rooms.SingleOrDefault(r => r.RoomId == ((Room)parameter).RoomId);
            if (room != null)
            {
                Context.Rooms.Remove(room);
                Context.SaveChanges();
            }
            else
                MessageBox.Show("Упс...");
        }
    }
}
