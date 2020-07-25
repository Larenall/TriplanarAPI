using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pTriplanar;

namespace pTriplanar.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class user_statsController : ControllerBase
    {
        [HttpGet]
        public object getStats()
        {
            using (postgresContext db = new postgresContext())
            {
                var result = (from e in db.user_stats
                              join d
                              in db.user_data on e.user_id equals d.user_id
                              select new
                              {
                                  d.user_id,
                                  d.nickname,
                                  e.maxmatterlvl,
                                  e.maxenergylvl,
                                  e.maxnaturelvl
                              });
                var fin = result.ToList().OrderBy(s => -s.maxmatterlvl).Take(10).ToList();
                fin.AddRange(result.ToList().OrderBy(s => -s.maxenergylvl).Take(10).ToList());
                fin.AddRange(result.ToList().OrderBy(s => -s.maxnaturelvl).Take(10).ToList());
                fin.Distinct();
                return fin;
            }
        }
    }





}
