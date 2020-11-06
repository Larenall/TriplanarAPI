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
    public class game_descrController : ControllerBase
    {
        [HttpGet]
        public string getDescr()
        {
            using (postgresContext db = new postgresContext())
            {
                string desc = db.game_descr.ToList()[0].description;
                return desc;
            }

        }
    }
}
