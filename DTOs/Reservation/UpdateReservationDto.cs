using System.ComponentModel.DataAnnotations;
using APBD_PJATK_Cw3_s29756.Enums;

namespace APBD_PJATK_Cw3_s29756.DTOs.Reservation;

public class UpdateReservationDto : IValidatableObject
{
    [Required]
    public int RoomId { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public string OrganizerName { get; set; } = string.Empty;

    [Required, MinLength(1), MaxLength(200)]
    public string Topic { get; set; } = string.Empty;

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }

    [Required]
    public ReservationStatus Status { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndTime <= StartTime)
            yield return new ValidationResult("EndTime must be later than StartTime", [nameof(EndTime)]);
    }
}
