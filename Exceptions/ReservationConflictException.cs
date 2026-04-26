namespace APBD_PJATK_Cw3_s29756.Exceptions;

public class ReservationConflictException(int roomId, DateOnly date)
    : Exception($"Room {roomId} already has a conflicting reservation on {date}");