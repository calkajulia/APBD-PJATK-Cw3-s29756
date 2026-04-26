using APBD_PJATK_Cw3_s29756.DTOs.Reservation;
using APBD_PJATK_Cw3_s29756.Models;

namespace APBD_PJATK_Cw3_s29756.Mappers;

public static class ReservationMappingExtensions
{
    public static ReservationDto ToDto(this Reservation reservation)
    {
        return new ReservationDto
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            OrganizerName = reservation.OrganizerName,
            Topic = reservation.Topic,
            Date = reservation.Date,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
            Status = reservation.Status
        };
    }

    public static Reservation ToDomain(this CreateReservationDto dto)
    {
        return new Reservation
        {
            RoomId = dto.RoomId,
            OrganizerName = dto.OrganizerName,
            Topic = dto.Topic,
            Date = dto.Date,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Status = dto.Status
        };
    }

    public static Reservation ToDomain(this UpdateReservationDto dto)
    {
        return new Reservation
        {
            RoomId = dto.RoomId,
            OrganizerName = dto.OrganizerName,
            Topic = dto.Topic,
            Date = dto.Date,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Status = dto.Status
        };
    }
}