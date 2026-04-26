using APBD_PJATK_Cw3_s29756.DTOs.Reservation;
using APBD_PJATK_Cw3_s29756.Enums;

namespace APBD_PJATK_Cw3_s29756.Services.Reservations;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetAll(DateOnly? date, ReservationStatus? status, int? roomId);
    ReservationDto GetById(int id);
    ReservationDto Add(CreateReservationDto dto);
    ReservationDto Update(int id, UpdateReservationDto dto);
    void Remove(int id);
}