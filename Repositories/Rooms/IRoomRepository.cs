using APBD_PJATK_Cw3_s29756.Models;

namespace APBD_PJATK_Cw3_s29756.Repositories.Rooms;

public interface IRoomRepository
{
    IEnumerable<Room> GetAll();
    IEnumerable<Room> GetByBuildingCode(string buildingCode);
    Room? GetById(int id);
    void Add(Room room);
    bool Update(Room room);
    bool Remove(int id);
    bool Exists(int id);
}