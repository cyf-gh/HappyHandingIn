using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHandIn {
    public class HHI_HandIn {
        public int id { get; set;  }
        public string name { get; set; }
        public bool isSubItemFolder { get; set; }
        public string path { get; set; }
        public string regex { get; set; }
        public string prefix_name { get; set; }
    }
    public class HHI_Prefix {
        public int id { get; set; }
        public string name { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public List<int>numbers { get; set;}
        public string include { get; set; }
        public string exclude { get; set; }
    }
}
