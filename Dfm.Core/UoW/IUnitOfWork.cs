using Dfm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.UoW
{
    public interface IUnitOfWork
    {
        void CreateFolder(FolderItemInfo item);
        void CopyFolder(FolderItemInfo from, FolderItemInfo to);
        void RemoveFolder(FolderItemInfo item);
        void MoveFolder(FolderItemInfo from, FolderItemInfo to);

        FolderItemInfo GetTree(string path);
    }
}
