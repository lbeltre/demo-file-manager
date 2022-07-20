using Dfm.Core.Commands;
using Dfm.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Dfm.Core.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CommandManager commandManager;

        public UnitOfWork(CommandManager manager)
        {
            commandManager = manager;
        }

        public void CreateFolder(FolderItemInfo item) => commandManager.Invoke(new CreateFolderCommand(item));
        public void CopyFolder(FolderItemInfo from, FolderItemInfo to) => commandManager.Invoke(new CopyFolderCommand(from, to));
        public void RemoveFolder(FolderItemInfo item) => commandManager.Invoke(new RemoveFolderCommand(item));
        public void MoveFolder(FolderItemInfo from, FolderItemInfo to) => commandManager.Invoke(new MoveFolderCommand(from, to));


        public FolderItemInfo GetTree(string path)
        {
            if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                throw new ValidationException("Invalid folder path");

            var dir = new DirectoryInfo(path);
            var folder = new FolderItemInfo(dir.Name)
            {
                Location = dir.Parent?.FullName ?? string.Empty,
                Created = dir.CreationTime,
            };

            foreach (var item in Directory.EnumerateFileSystemEntries(path))
            {
                if (File.GetAttributes(item).HasFlag(FileAttributes.Directory))
                    folder.Folders.Add(GetTree(item));
                else
                {
                    var file = new FileInfo(item);
                    var fileItem = new FileItemInfo(file.Name, file.Length)
                    {
                        Location = file?.DirectoryName ?? string.Empty,
                        Created = file.CreationTime,
                        Modified = file.LastWriteTime
                    };

                    folder.Files.Add(fileItem);
                }
            }

            return folder;
        }
    }
}
