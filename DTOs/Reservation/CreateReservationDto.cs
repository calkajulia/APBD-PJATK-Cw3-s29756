using System.ComponentModel.DataAnnotations;
using APBD_PJATK_Cw3_s29756.Enums;

namespace APBD_PJATK_Cw3_s29756.DTOs.Reservation;

public class CreateReservationDto
{
    [Required]
    public int RoomId { get; set; }

    [Required, MaxLength(100)]
    public string OrganizerName { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string Topic { get; set; } = string.Empty;

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }

    [Required]
    public ReservationStatus Status { get; set; }
}
