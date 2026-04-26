using APBD_PJATK_Cw3_s29756.Data;
using APBD_PJATK_Cw3_s29756.Models;

namespace APBD_PJATK_Cw3_s29756.Repositories.Reservations;

public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = SampleData.Reservations;

    public IEnumerable<Reservation> GetAll()
    {
        return _reservations;
    }

    public IEnumerable<Reservation> GetByRoomId(int roomId)
    {
        return _reservations.Where(r => r.RoomId == roomId);
    }

    public Reservation? GetById(int id)
    {
        return _reservations.FirstOrDefault(r => r.Id == id);
    }

    public void Add(Reservation reservation)
    {
        reservation.Id = _reservations.Any() ? _reservations.Max(r => r.Id) + 1 : 1;
        _reservations.Add(reservation);
    }

    public bool Update(Reservation reservation)
    {
        var existing = GetById(reservation.Id);
        if (existing is null)
            return false;

        existing.RoomId = reservation.RoomId;
        existing.OrganizerName = reservation.OrganizerName;
        existing.Topic = reservation.Topic;
        existing.Date = reservation.Date;
        existing.StartTime = reservation.StartTime;
        existing.EndTime = reservation.EndTime;
        existing.Status = reservation.Status;
        return true;
    }

    public bool Remove(int id)
    {
        var reservation = GetById(id);
        if (reservation is null)
            return false;

        _reservations.Remove(reservation);
        return true;
    }

    public bool Exists(int id)
    {
        return _reservations.Any(r => r.Id == id);
    }
}