using Dfm.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (Directory.Exists(folder.FullPath))
                throw new ValidationException($"Folder alredy exists");

            Directory.Delete(folder.FullPath);            
        }
    }
}
