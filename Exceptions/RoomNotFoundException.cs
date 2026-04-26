namespace APBD_PJATK_Cw3_s29756.Exceptions;

public class RoomNotFoundException(int id) 
    : Exception($"Room with id {id} not found");