using Dfm.Core.Models;

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
