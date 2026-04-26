using APBD_PJATK_Cw3_s29756.Enums;
using APBD_PJATK_Cw3_s29756.Models;

namespace APBD_PJATK_Cw3_s29756.Data;

public static class SampleData
{
    public static List<Room> Rooms = new List<Room>
    {
        new Room { Id = 1, Name = "Aula 101", BuildingCode = "A", Floor = 1, Capacity = 120, HasProjector = true, IsActive = true },
        new Room { Id = 2, Name = "Lab 204", BuildingCode = "B", Floor = 2, Capacity = 24, HasProjector = true, IsActive = true },
        new Room { Id = 3, Name = "Sala 305", BuildingCode = "A", Floor = 3, Capacity = 40, HasProjector = false, IsActive = true },
        new Room { Id = 4, Name = "Lab 110", BuildingCode = "C", Floor = 1, Capacity = 16, HasProjector = true, IsActive = false },
        new Room { Id = 5, Name = "Sala 202", BuildingCode = "B", Floor = 2, Capacity = 30, HasProjector = true, IsActive = true }
    };

    public static List<Reservation> Reservations = new List<Reservation>
    {
        new Reservation { Id = 1, RoomId = 1, OrganizerName = "Jan Nowak", Topic = "Wyklad z algorytmow", Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(8, 0), EndTime = new TimeOnly(10, 0), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 2, RoomId = 2, OrganizerName = "Anna Kowalska", Topic = "Warsztaty z HTTP i REST", Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(12, 30), Status = ReservationStatus.Confirmed },
        new Reservation { Id = 3, RoomId = 3, OrganizerName = "Piotr Zielinski", Topic = "Konsultacje projektowe", Date = new DateOnly(2026, 5, 11), StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(15, 30), Status = ReservationStatus.Planned },
        new Reservation { Id = 4, RoomId = 1, OrganizerName = "Maria Wisniewska", Topic = "Seminarium magisterskie", Date = new DateOnly(2026, 5, 12), StartTime = new TimeOnly(12, 0), EndTime = new TimeOnly(14, 0), Status = ReservationStatus.Planned },
        new Reservation { Id = 5, RoomId = 5, OrganizerName = "Tomasz Kaczmarek", Topic = "Szkolenie BHP", Date = new DateOnly(2026, 5, 10), StartTime = new TimeOnly(9, 0), EndTime = new TimeOnly(11, 0), Status = ReservationStatus.Cancelled }
    };
}
