using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int Quality { get; set; }
        public string Url { get; set; }
    }
}
