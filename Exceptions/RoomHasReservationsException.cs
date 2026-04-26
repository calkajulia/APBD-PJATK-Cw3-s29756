namespace APBD_PJATK_Cw3_s29756.Exceptions;

public class RoomHasReservationsException(int id) 
    : Exception($"Cannot delete room {id} because it has existing reservations");