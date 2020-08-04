using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pTriplanar
{
    [Serializable]
    public class user_records
    {
        public string email;
        public int maxmatterlvl;
        public int maxenergylvl;
        public int maxnaturelvl;
    }
}
