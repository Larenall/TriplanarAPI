using System;
using System.Collections.Generic;

namespace pTriplanar
{
    public partial class user_stats
    {
        public int? user_id { get; set; }
        public int? maxmatterlvl { get; set; }
        public int? maxenergylvl { get; set; }
        public int? maxnaturelvl { get; set; }

        public virtual user_data User { get; set; }
    }
}
