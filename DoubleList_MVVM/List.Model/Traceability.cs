using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.Model
{
    public class Traceability
    {
        public int id { get; set; }
        public string traceability { get; set; }

        public Traceability(int id, string traceability)
        {
            this.id = id;
            this.traceability = traceability;
        }
    }
}
