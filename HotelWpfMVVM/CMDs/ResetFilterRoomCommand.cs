using HotelWpfMVVM.Model;

namespace HotelWpfMVVM.CMDs
{
    public class ResetFilterRoomCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => (parameter as Room) != null &&
            (!string.IsNullOrEmpty((parameter as Room).RoomNumber) ||
            (parameter as Room).RoomType != 0 ||
            (parameter as Room).RoomFree != 0);

        public override void Execute(object parameter)
        {
            Room room = parameter as Room;
            room.RoomNumber = string.Empty;
            room.RoomType = 0;
            room.RoomFree = 0;
        }
    }
}
