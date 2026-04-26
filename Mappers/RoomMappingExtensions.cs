using APBD_PJATK_Cw3_s29756.DTOs.Room;
using APBD_PJATK_Cw3_s29756.Models;

namespace APBD_PJATK_Cw3_s29756.Mappers;

public static class RoomMappingExtensions
{
    public static RoomDto ToDto(this Room room)
    {
        return new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            BuildingCode = room.BuildingCode,
            Floor = room.Floor,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        };
    }

    public static Room ToDomain(this CreateRoomDto dto)
    {
        return new Room
        {
            Name = dto.Name,
            BuildingCode = dto.BuildingCode,
            Floor = dto.Floor,
            Capacity = dto.Capacity,
            HasProjector = dto.HasProjector,
            IsActive = dto.IsActive
        };
    }

    public static Room ToDomain(this UpdateRoomDto dto)
    {
        return new Room
        {
            Name = dto.Name,
            BuildingCode = dto.BuildingCode,
            Floor = dto.Floor,
            Capacity = dto.Capacity,
            HasProjector = dto.HasProjector,
            IsActive = dto.IsActive
        };
    }
}