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
using Microsoft.Data.SqlClient;

namespace pTriplanar.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class upgradesController : ControllerBase
    {
        [HttpPost]
        public void importUpg(upgrades data)
        {
            using (postgresContext db = new postgresContext())
            {
                var upgList = db.upgrades.ToList();
                if (upgList.Where(el => el.id == data.id).ToList().Count == 0)
                {
                    db.upgrades.Add(data);
                    db.SaveChanges();
                    return;
                }
                var updatedUpg = upgList.Where(el => el.id == data.id).ToList()[0];
                updatedUpg.upg_data = data.upg_data;
                db.upgrades.Update(updatedUpg);
                db.SaveChanges();
            }
        }
        [HttpDelete("{getId}")]
        public void deleteUpg(int getId)
        {
            using (postgresContext db = new postgresContext())
            {
                var upgrade = db.upgrades.ToList().Where(el => el.id == getId).ToList()[0];
                db.upgrades.Remove(upgrade);
                db.SaveChanges();
            }
        }
        [HttpGet]
        public List<string> getUpgs()
        {
            using (postgresContext db = new postgresContext())
            {
                var upgrades = db.upgrades.ToList();
                List<string> upgList = new List<string>();
                var sorteUpgrades = upgrades.OrderBy(x => x.id);
                foreach (upgrades el in sorteUpgrades) {
                    upgList.Add(el.upg_data);
                }
                return upgList;
            }
        }
    }


}