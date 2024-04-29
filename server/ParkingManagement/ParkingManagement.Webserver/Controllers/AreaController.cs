using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Webserver.Controllers
{
    //[Authorize]
    [Route("api/area")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listAreas = await _areaService.GetListAsync();

                var result = listAreas.Select(s => new
                {
                    AreaId = s.AreaId,
                    AreaName = s.AreaName,
                    UserId = s.UserId
                });
                return Ok(new ServerResponse(result, Message: "Get list area success"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null
                    , false, ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Area area)
        {
            try 
            {
                var createArea = await _areaService.CreateAsync(area);
                var areaDtos = new
                {
                    AreaId = createArea.AreaId,
                    AreaName = createArea.AreaName,
                    UserId = createArea.UserId
                };
                if(createArea == null)
                {
                    return BadRequest(new ServerResponse(null, false, "Create area is faild"));
                }

                return Ok(new ServerResponse(areaDtos, Message: "Created"));
            }catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null
                   , false, ex.Message));
            }
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var listAreas = await _areaService.GetByNameAsync(name);
                if(listAreas == null)
                {
                    return BadRequest(new ServerResponse(null
                  , false, "Find area by name is faild"));
                }
                var result = listAreas.Select(s => new
                {
                    AreaId = s.AreaId,
                    AreaName = s.AreaName,
                    UserId = s.UserId
                });

                return Ok(new ServerResponse(result, Message: "Find area by name success"));
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null
                   , false, ex.Message));
            }
        }



        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var area = await _areaService.GetByIdAsync(id);
                if(area == null)
                {
                    return BadRequest(new ServerResponse(null, false, $"Find area with id : {id} faild"));
                }
                var result = new
                {
                    AreaId = area.AreaId,
                    AreaName = area.AreaName,
                    UserId = area.UserId
                };
                return Ok(new ServerResponse(result, Message: "Find area success"));
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null
                   , false, ex.Message));
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(Area area)
        {
            try
            {
                bool isSuccess = await _areaService.UpdateAsync(area);
                if(isSuccess)
                {
                    return Ok(new ServerResponse(null, Message: "Updated"));
                }
                return BadRequest(new ServerResponse(null, false, "Update faild"));
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null
                   , false, ex.Message));
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isSuccess = await _areaService.DeleteAsync(id);
                if (isSuccess)
                {
                    return Ok(new ServerResponse(null, Message: "Deleted"));
                }
                return BadRequest(new ServerResponse(null, false, "Delete faild"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }
    }
}
