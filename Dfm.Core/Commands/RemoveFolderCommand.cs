using Dfm.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Dfm.Core.Commands
{
    internal class RemoveFolderCommand : ICommand
    {
        private readonly FolderItemInfo folder;


        public RemoveFolderCommand(FolderItemInfo folder)
        {
            this.folder = folder;
        }

        public void Execute()
        {
            if (!Directory.Exists(folder.FullPath))
                throw new ValidationException($"Folder doesn't exists");

            Directory.Delete(folder.FullPath);
        }
    }
}
