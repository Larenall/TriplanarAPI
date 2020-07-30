using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pTriplanar;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;

namespace pTriplanar.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class upgradesController : ControllerBase
    {
        //[HttpGet("{upgId}/{upgString}")]
        [HttpPost]
        public void importUpg(upgrades data)
        {
            using (postgresContext db = new postgresContext())
            {
                upgrades newUpg = new upgrades { id = data.id, upg_data = data.upg_data };
                db.upgrades.Add(newUpg);
                db.SaveChanges();
            }
        }
    }

}