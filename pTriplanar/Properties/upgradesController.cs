using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pTriplanar;

namespace pTriplanar.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class upgradesController : ControllerBase
    {
        [HttpGet("{upgId}/{upgString}")]
        public void importUpg(int upgId,string upgString)
        {
            using (postgresContext db = new postgresContext())
            {
                upgrades newUpg = new upgrades { id = upgId, upg_data = upgString };
                db.upgrades.Add(newUpg);
                db.SaveChanges();
            }

        }
    }
}