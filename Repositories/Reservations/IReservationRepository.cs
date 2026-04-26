using APBD_PJATK_Cw3_s29756.Models;

namespace APBD_PJATK_Cw3_s29756.Repositories.Reservations;

public interface IReservationRepository
{
    IEnumerable<Reservation> GetAll();
    IEnumerable<Reservation> GetByRoomId(int roomId);
    Reservation? GetById(int id);
    void Add(Reservation reservation);
    bool Update(Reservation reservation);
    bool Remove(int id);
    bool Exists(int id);
}