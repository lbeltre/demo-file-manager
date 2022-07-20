using Dfm.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Dfm.Core.Commands
{
    internal class CreateFolderCommand : ICommand
    {
        private readonly FolderItemInfo folder;


        public CreateFolderCommand(FolderItemInfo folder)
        {
            this.folder = folder;
        }

        public void Execute()
        {
            if (Directory.Exists(folder.FullPath))
                throw new ValidationException($"Folder alredy exists");

            Directory.CreateDirectory(folder.FullPath);
        }
    }
}
