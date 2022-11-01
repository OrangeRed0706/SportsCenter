﻿using Microsoft.AspNetCore.Mvc;
using SportsCenter.DataAccess;
using SportsCenter.DataAccess.Entity;

namespace SportsCenter.Controllers.Api
{
    [Route("api/Venue/{action}")]
    [ApiController]
        public class VenueApiController: ControllerBase
        {

            private readonly SportsCenterDbContext _context;
            public VenueApiController(SportsCenterDbContext _context)
            {
                this._context = _context;
            }
            #region  回傳Location資料

            [HttpGet]

            public object Get()
            {
                return _context.Location.Select(x=> new {
                    x.Area,
                    x.ImagePath,
                    x.Id,
                    x.Name,
                    x.EnglishName,
                    x.Description,
                    x.Website,
                    x.ContactPhone,
                    x.Address,
                    categoryIds = x.LocationBranch.Select(x=>x.CategoryId).ToList()
                });

            }

        #endregion
        #region 回傳詳細資料畫面viaId
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetDetail(int id)
        {
            var data = _context.Location.Where(x => x.Id == id).Select(x => new DataAccess.Entity.Location
            {
                    Id= x.Id,
                    Area= x.Area,
                    ImagePath = x.ImagePath,
                    Name=x.Name,
                    EnglishName=x.EnglishName,
                    Description = x.Description,
                    Website=x.Website,
                    ContactPhone=x.ContactPhone,
                    Address=x.Address,
            }).FirstOrDefault();

            return Ok(data);
        }

        #endregion





        #region  CreateLocation資料

        [HttpPost]
            public IActionResult PostLocation([FromBody] Location location)
            {
                var i = new Location
                {
                    Name = location.Name,
                    EnglishName = location.EnglishName,
                    Address = location.Address,
                    ContactPhone = location.ContactPhone,
                    Website = location.Website,
                    ImagePath = location.ImagePath,
                };
                _context.Location.Add(i);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDetail), new { id = location.Id }, location);
            }

            #endregion
            #region  刪除

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var location = _context.Location.SingleOrDefault(i => i.Id == id);
                if (location != null)
                {
                    _context.Remove(location);
                    _context.SaveChanges();
                    return NoContent();
                }

                return NotFound();
            }
            #endregion
        }
    }



        //[HttpPut("{id}")]
        //public IActionResult updateLocation(int id, [FromBody] Location update)
        //{
        //    var location = _context.Location.SingleOrDefault(i => i.Id == update.Id);
        //    if (location != null)
        //    {
        //        //location.Name = update.Name;
        //        //location.EnglishName = update.EnglishName;
        //        //location.Address = update.Address;
        //        //location.ContactPhone = update.ContactPhone;
        //        //location.Website = update.Website;
        //        //location.ImagePath = update.ImagePath;
        //        location = update;
        //        _context.Update(location);
        //        _context.SaveChanges();
        //        return CreatedAtAction(nameof(GetbyId), new { id = location.Id }, location);
        //    }
        //    return BadRequest();
        //}


