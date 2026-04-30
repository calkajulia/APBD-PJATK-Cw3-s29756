using APBD_PJATK_Cw3_s29756.DTOs.Reservation;
using APBD_PJATK_Cw3_s29756.Enums;
using APBD_PJATK_Cw3_s29756.Exceptions;
using APBD_PJATK_Cw3_s29756.Services.Reservations;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3_s29756.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] DateOnly? date,
        [FromQuery] ReservationStatus? status,
        [FromQuery] int? roomId
    ){
        return Ok(service.GetAll(date, status, roomId));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(
        [FromRoute] int id
    ){
        try
        {
            return Ok(service.GetById(id));
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Create(
        [FromBody] CreateReservationDto dto
    ){
        try
        {
            var created = service.Add(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created
            );
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (RoomNotActiveException e)
        {
            return Conflict(e.Message);
        }
        catch (ReservationConflictException e)
        {
            return Conflict(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(
        [FromRoute] int id, 
        [FromBody] UpdateReservationDto dto
    ){
        try
        {
            return Ok(service.Update(id, dto));
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (RoomNotActiveException e)
        {
            return Conflict(e.Message);
        }
        catch (ReservationConflictException e)
        {
            return Conflict(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(
        [FromRoute] int id
    ){
        try
        {
            service.Remove(id);
            return NoContent();
        }
        catch (ReservationNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}