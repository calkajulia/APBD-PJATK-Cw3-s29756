namespace APBD_PJATK_Cw3_s29756.Exceptions;

public class RoomNotActiveException(int id) 
    : Exception($"Room with id {id} is not active");