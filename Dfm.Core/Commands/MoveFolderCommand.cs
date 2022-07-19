using Dfm.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.Commands
{
    internal class MoveFolderCommand : ICommand
    {
        private readonly FolderItemInfo source;
        private readonly FolderItemInfo destination;


        public MoveFolderCommand(FolderItemInfo from, FolderItemInfo to)
        {
            source = from;
            destination = to;
        }

        public void Execute()
        {
            if (!Directory.Exists(destination.FullPath))
                throw new ValidationException($"Folder destination doesn't exists");

            var toFolder = Path.Combine(destination.FullPath, source.Name);
            Directory.Move(source.FullPath, toFolder);
        }
    }
}
