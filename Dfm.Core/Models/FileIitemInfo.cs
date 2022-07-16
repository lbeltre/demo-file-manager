using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.Models
{
    public class FileIitemInfo : ItemInfo
    {
        public FileIitemInfo(string name) : base(name) { }

        public DateTime Modified { get; set; }

        public override string GetSize()
        {
            throw new NotImplementedException();
        }
    }
}
