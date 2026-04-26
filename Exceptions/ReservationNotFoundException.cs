namespace APBD_PJATK_Cw3_s29756.Exceptions;

public class ReservationNotFoundException(int id) 
    : Exception($"Reservation with id {id} not found");