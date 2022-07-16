using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.Models
{
    public class FolderItemInfo : ItemInfo
    {
        public List<FileInfo> Contents { get; } = new List<FileInfo>();


        public FolderItemInfo(string name) : base(name) { }

        public override string GetSize()
        {
            throw new NotImplementedException();
        }
    }
}
