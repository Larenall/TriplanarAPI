using System;
using System.Collections.Generic;

namespace pTriplanar
{
    [Serializable]
    public partial class user_stats
    {
        public int user_id { get; set; }
        public int maxmatterlvl { get; set; }
        public int maxenergylvl { get; set; }
        public int maxnaturelvl { get; set; }

        public virtual user_data User { get; set; }
        public user_stats(int user_id, int maxmatterlvl, int maxenergylvl, int maxnaturelvl)
        {
            this.user_id = user_id;
            this.maxmatterlvl = maxmatterlvl;
            this.maxenergylvl = maxenergylvl;
            this.maxnaturelvl = maxnaturelvl;
        }
    }
}
