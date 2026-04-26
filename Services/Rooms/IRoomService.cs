using APBD_PJATK_Cw3_s29756.DTOs.Room;

namespace APBD_PJATK_Cw3_s29756.Services.Rooms;

public interface IRoomService
{
    IEnumerable<RoomDto> GetAll(int? minCapacity, bool? hasProjector, bool? activeOnly);
    IEnumerable<RoomDto> GetByBuildingCode(string buildingCode);
    RoomDto GetById(int id);
    RoomDto Add(CreateRoomDto dto);
    RoomDto Update(int id, UpdateRoomDto dto);
    void Remove(int id);
}