using System;
using System.Collections.Generic;

namespace pTriplanar
{
    public class user_data
    {
        public int user_id { get; set; }
        public string nickname { get; set; }
        public string email { get; set; }
        public string savestring { get; set; }
        public user_data(int user_id, string nickname, string email, string savestring) {
            this.user_id = user_id;
            this.nickname = nickname;
            this.email = email;
            this.savestring = savestring;
        }
    }
}
