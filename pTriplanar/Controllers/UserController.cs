using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace pTriplanar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriplanarController : ControllerBase
    {
        private readonly ILogger<TriplanarController> _logger;

        public TriplanarController(ILogger<TriplanarController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{getEmail}")]
        public IEnumerable<User> Get(string getEmail)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                
                var _users = db.user_data.ToList();
                return _users.Where(el=>el.email == getEmail);
            }
        }
        [HttpPost]
        public string Post([FromBody] User postuser)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { id = postuser.id, nickname = postuser.nickname, savestring= postuser.savestring, email=postuser.email };
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
