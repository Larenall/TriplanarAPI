using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;


namespace pTriplanar.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class TriplanarController : ControllerBase
    {
        private readonly ILogger<TriplanarController> _logger;

        public TriplanarController(ILogger<TriplanarController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{getEmail}/{getName}")]
        public string OnLogin(string getEmail, string getName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var _users = db.user_data.ToList();
                if (_users.Where(el => el.email == getEmail).ToList().Count == 0)
                {
                    int maxId = 0;
                    foreach (User i in _users)
                    {
                        maxId = Math.Max(maxId, i.id);
                    }
                    User newUser = new User(maxId + 1, getName, null, getEmail);
                    db.user_data.Add(newUser);
                    db.SaveChanges();
                    _users = db.user_data.ToList();
                }
                return _users.Where(el => el.email == getEmail).ToList<User>()[0].savestring; 

            }
        }
        [HttpPost]
        public string Post([FromBody] User postuser)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User(postuser.id, postuser.nickname, postuser.savestring, postuser.email);
                db.user_data.Update(user1);
                db.SaveChanges();
                return "Posted";
            }

        }
        [HttpPatch]
        public IEnumerable<User> Patch([FromBody] string patchEmail)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var _users = db.user_data.ToList();
                _users.Where(el => el.email == patchEmail);
                _users[0].savestring = null;
                db.user_data.Update(_users[0]);
                db.SaveChanges();
                var newList = db.user_data.ToList();
                return newList.Where(el => el.email == patchEmail);
            }

        }
    }
}
