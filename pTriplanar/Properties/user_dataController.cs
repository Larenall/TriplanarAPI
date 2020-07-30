using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace pTriplanar
{
    [Route("api/[controller]")]
    [ApiController]
    public class user_dataController : ControllerBase
    {
        [HttpGet("{getEmail}/{getName}")]
        public string OnLogin(string getEmail, string getName)
        {
            using (postgresContext db = new postgresContext())
            {
                var userList = db.user_data.ToList();
                if (userList.Where(el => el.email == getEmail).ToList().Count == 0)
                {
                    int maxId = 0;
                    foreach (user_data user in userList)
                    {
                        maxId = Math.Max(maxId, user.user_id);
                    }
                    user_data newUser = new user_data(maxId + 1, getName, getEmail, "");
                    user_stats newStats = new user_stats(maxId + 1,0,0,0);
                    db.user_data.Add(newUser);
                    db.user_stats.Add(newStats);
                    db.SaveChanges();
                    return getName;
                }
                return userList.Where(el => el.email == getEmail).ToList()[0].nickname;
            }
        }





        [HttpPatch("update/{getEmail}/{patchName}")]
        public void PatchName(string getEmail, string patchName)
        {
            using (postgresContext db = new postgresContext()) {
            var _user = db.user_data.ToList().Where(el => el.email == getEmail).ToList();
            _user[0].nickname = patchName;
            db.user_data.Update(_user[0]);
            db.SaveChanges();
        }
        }
        [HttpPatch]
        public void ResetProgress([FromBody]string getEmail)
        {
            using (postgresContext db = new postgresContext())
            {
                var _user = db.user_data.ToList().Where(el => el.email == getEmail).ToList()[0];
                _user.savestring = "";
                db.user_data.Update(_user);
                db.SaveChanges();
            }
        }
    }
}


    

