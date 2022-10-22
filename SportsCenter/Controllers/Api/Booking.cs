﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsCenter.Models.Entity;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsCenter.Controllers.Api
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly db_a8ea3c_sportscenterContext DbContext;

        public BookingController(db_a8ea3c_sportscenterContext dbContext)
        {
            DbContext = dbContext;
        }
     

        // GET api/<BookingController>/5    
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


 

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    public class CommonApiFormat<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
    }

    public class TempBookingModel
    {
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string OrderBranch { get; set; }
        public string LocationName { get; set; }
        public int? OrderPrice { get; set; }


    }

}
