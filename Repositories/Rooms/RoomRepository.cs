using APBD_PJATK_Cw3_s29756.Data;
using APBD_PJATK_Cw3_s29756.Models;

namespace APBD_PJATK_Cw3_s29756.Repositories.Rooms;

public class RoomRepository : IRoomRepository
{
    private readonly List<Room> _rooms = SampleData.Rooms;

    public IEnumerable<Room> GetAll()
    {
        return _rooms;
    }

    public IEnumerable<Room> GetByBuildingCode(string buildingCode)
    {
        return _rooms.Where(r => r.BuildingCode == buildingCode);
    }

    public Room? GetById(int id)
    {
        return _rooms.FirstOrDefault(r => r.Id == id);
    }

    public void Add(Room room)
    {
        room.Id = _rooms.Any() ? _rooms.Max(r => r.Id) + 1 : 1;
        _rooms.Add(room);
    }

    public bool Update(Room room)
    {
        var existing = GetById(room.Id);
        if (existing is null)
            return false;

        existing.Name = room.Name;
        existing.BuildingCode = room.BuildingCode;
        existing.Floor = room.Floor;
        existing.Capacity = room.Capacity;
        existing.HasProjector = room.HasProjector;
        existing.IsActive = room.IsActive;
        return true;
    }

    public bool Remove(int id)
    {
        var room = GetById(id);
        if (room is null)
            return false;

        _rooms.Remove(room);
        return true;
    }

    public bool Exists(int id)
    {
        return _rooms.Any(r => r.Id == id);
    }
}