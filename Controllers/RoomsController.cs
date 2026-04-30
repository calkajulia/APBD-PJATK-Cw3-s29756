using APBD_PJATK_Cw3_s29756.DTOs.Room;
using APBD_PJATK_Cw3_s29756.Exceptions;
using APBD_PJATK_Cw3_s29756.Services.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw3_s29756.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController(IRoomService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] int? minCapacity,
        [FromQuery] bool? hasProjector,
        [FromQuery] bool? activeOnly
    ) {
        return Ok(service.GetAll(minCapacity, hasProjector, activeOnly));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(
        [FromRoute] int id
    ){
        try
        {
            return Ok(service.GetById(id));
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("building/{buildingCode}")]
    public IActionResult GetByBuilding(
        [FromRoute] string buildingCode
    ){
        return Ok(service.GetByBuildingCode(buildingCode));
    }

    [HttpPost]
    public IActionResult Create(
        [FromBody] CreateRoomDto dto
    ){
        var created = service.Add(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(
        [FromRoute] int id, 
        [FromBody] UpdateRoomDto dto
    ){
        try
        {
            return Ok(service.Update(id, dto));
        }
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
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
        catch (RoomNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (RoomHasReservationsException e)
        {
            return Conflict(e.Message);
        }
    }
}