using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pTriplanar
{
    [Serializable]
    public class user_maxrecords
    {
        public string nickname;
        public int maxmatterlvl;
        public int maxenergylvl;
        public int maxnaturelvl;
    }
}
