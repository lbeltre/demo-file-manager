using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.Models
{
    public abstract class ItemInfo
    {
        protected ItemInfo(string name) => Name = name;

        public string Name { get; set; } 
        public float Size { get; set; }
        public string Location { get; set; } = string.Empty;

        public string FullPath => $@"{Location}\{Name}";
        public DateTime Created { get; set; }

        public abstract string GetSize();
    }
}
