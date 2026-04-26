using APBD_PJATK_Cw3_s29756.DTOs.Room;
using APBD_PJATK_Cw3_s29756.Exceptions;
using APBD_PJATK_Cw3_s29756.Mappers;
using APBD_PJATK_Cw3_s29756.Repositories.Reservations;
using APBD_PJATK_Cw3_s29756.Repositories.Rooms;

namespace APBD_PJATK_Cw3_s29756.Services.Rooms;

public class RoomService(IRoomRepository roomRepository, IReservationRepository reservationRepository) 
    : IRoomService
{
    public IEnumerable<RoomDto> GetAll(int? minCapacity, bool? hasProjector, bool? activeOnly)
    {
        var rooms = roomRepository.GetAll();

        if (minCapacity.HasValue)
            rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);

        if (hasProjector.HasValue)
            rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);

        if (activeOnly.HasValue && activeOnly.Value)
            rooms = rooms.Where(r => r.IsActive);

        return rooms.Select(r => r.ToDto());
    }

    public IEnumerable<RoomDto> GetByBuildingCode(string buildingCode)
    {
        return roomRepository.GetByBuildingCode(buildingCode).Select(r => r.ToDto());
    }

    public RoomDto GetById(int id)
    {
        var room = roomRepository.GetById(id);

        return room is null
            ? throw new RoomNotFoundException(id)
            : room.ToDto();
    }

    public RoomDto Add(CreateRoomDto dto)
    {
        var room = dto.ToDomain();
        roomRepository.Add(room);

        return room.ToDto();
    }

    public RoomDto Update(int id, UpdateRoomDto dto)
    {
        var room = dto.ToDomain();
        room.Id = id;

        return !roomRepository.Update(room)
            ? throw new RoomNotFoundException(id)
            : room.ToDto();
    }

    public void Remove(int id)
    {
        if (!roomRepository.Exists(id))
            throw new RoomNotFoundException(id);

        var hasReservations = reservationRepository.GetByRoomId(id).Any();
        if (hasReservations)
            throw new RoomHasReservationsException(id);

        roomRepository.Remove(id);
    }
}