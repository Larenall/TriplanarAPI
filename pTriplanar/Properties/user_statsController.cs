using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
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
        [HttpGet("{getEmail}")]
        public object getStats(string getEmail)
        {
            using (postgresContext db = new postgresContext())
            {
                var result = (from e in db.user_stats
                              join d
                              in db.user_data on e.user_id equals d.user_id
                              select new
                              {
                                  d.email,
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
                fin.Add(result.ToList().Where(el => el.email == getEmail).FirstOrDefault());
                return fin;
            }
        }
        [HttpPost]
        public void setRecord(user_stats records)
        {
            using (postgresContext db = new postgresContext())
            {
                var user = db.user_stats.ToList().Where(x => x.user_id == records.user_id).ToList()[0];
                user.maxmatterlvl = records.maxmatterlvl;
                user.maxenergylvl = records.maxenergylvl;
                user.maxnaturelvl = records.maxnaturelvl;
                db.user_stats.Update(user);
                db.SaveChanges();
            }
        }
    }





}
