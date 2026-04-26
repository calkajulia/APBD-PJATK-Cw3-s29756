using System.ComponentModel.DataAnnotations;

namespace APBD_PJATK_Cw3_s29756.DTOs.Room;

public class UpdateRoomDto
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(10)]
    public string BuildingCode { get; set; } = string.Empty;

    [Required]
    public int Floor { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int Capacity { get; set; }

    [Required]
    public bool HasProjector { get; set; }

    [Required]
    public bool IsActive { get; set; }
}