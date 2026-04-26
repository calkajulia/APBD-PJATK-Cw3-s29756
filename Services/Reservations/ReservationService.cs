using APBD_PJATK_Cw3_s29756.DTOs.Reservation;
using APBD_PJATK_Cw3_s29756.Enums;
using APBD_PJATK_Cw3_s29756.Exceptions;
using APBD_PJATK_Cw3_s29756.Mappers;
using APBD_PJATK_Cw3_s29756.Repositories.Reservations;
using APBD_PJATK_Cw3_s29756.Repositories.Rooms;

namespace APBD_PJATK_Cw3_s29756.Services.Reservations;

public class ReservationService(IReservationRepository reservationRepository, IRoomRepository roomRepository) 
    : IReservationService
{
    public IEnumerable<ReservationDto> GetAll(DateOnly? date, ReservationStatus? status, int? roomId)
    {
        var reservations = reservationRepository.GetAll();

        if (date.HasValue)
            reservations = reservations.Where(r => r.Date == date.Value);

        if (status.HasValue)
            reservations = reservations.Where(r => r.Status == status.Value);

        if (roomId.HasValue)
            reservations = reservations.Where(r => r.RoomId == roomId.Value);

        return reservations.Select(r => r.ToDto());
    }

    public ReservationDto GetById(int id)
    {
        var reservation = reservationRepository.GetById(id);

        return reservation is null
            ? throw new ReservationNotFoundException(id)
            : reservation.ToDto();
    }

    public ReservationDto Add(CreateReservationDto dto)
    {
        ValidateRoom(dto.RoomId, dto.Date, dto.StartTime, dto.EndTime, null);

        var reservation = dto.ToDomain();
        reservationRepository.Add(reservation);

        return reservation.ToDto();
    }

    public ReservationDto Update(int id, UpdateReservationDto dto)
    {
        if (!reservationRepository.Exists(id))
            throw new ReservationNotFoundException(id);

        ValidateRoom(dto.RoomId, dto.Date, dto.StartTime, dto.EndTime, id);

        var reservation = dto.ToDomain();
        reservation.Id = id;
        reservationRepository.Update(reservation);

        return reservation.ToDto();
    }

    private void ValidateRoom(int roomId, DateOnly date, TimeOnly startTime, TimeOnly endTime, int? excludeReservationId)
    {
        var room = roomRepository.GetById(roomId);

        if (room is null)
            throw new RoomNotFoundException(roomId);

        if (!room.IsActive)
            throw new RoomNotActiveException(roomId);

        var hasConflict = reservationRepository.GetByRoomId(roomId)
            .Any(r => (!excludeReservationId.HasValue || r.Id != excludeReservationId.Value)
                      && r.Date == date && r.StartTime < endTime && r.EndTime > startTime);

        if (hasConflict)
            throw new ReservationConflictException(roomId, date);
    }

    public void Remove(int id)
    {
        if (!reservationRepository.Exists(id))
            throw new ReservationNotFoundException(id);

        reservationRepository.Remove(id);
    }
}