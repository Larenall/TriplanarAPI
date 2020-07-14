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

        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var _users = db.user_data.ToList();
                return _users;
            }
        }
        [HttpPost]
        public string Post([FromBody] User postuser)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { id = postuser.id, nickname = postuser.nickname, token = postuser.token, savestring = postuser.savestring};
                db.user_data.Update(user1);
                db.SaveChanges();
                return db.user_data.nickname;
            }

        }
    }
}
