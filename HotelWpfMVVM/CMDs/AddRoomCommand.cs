using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;

namespace HotelWpfMVVM.CMDs
{
    class AddRoomCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public AddRoomCommand(HotelContext context) => Context = context;

        public override bool CanExecute(object parameter) => (parameter as Room) != null &&
                !string.IsNullOrEmpty((parameter as Room).RoomNumber)
                && (parameter as Room).RoomType != RoomTypes.None;

        public override void Execute(object parameter)
        {
            Context.Rooms.Add(new Room { RoomNumber = ((Room)parameter).RoomNumber, RoomType = ((Room)parameter).RoomType });
            Context.SaveChanges();
        }
    }
}
