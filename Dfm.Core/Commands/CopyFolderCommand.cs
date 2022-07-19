using Dfm.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.Commands
{
    internal class CopyFolderCommand : ICommand
    {
        private readonly FolderItemInfo source;
        private readonly FolderItemInfo destination;


        public CopyFolderCommand(FolderItemInfo from, FolderItemInfo to)
        {
            source = from;
            destination = to;
        }

        public void Execute()
        {
            if (!Directory.Exists(destination.FullPath))
                throw new ValidationException($"Folder destination doesn't exists");

            foreach (var item in Directory.GetDirectories(source.FullPath, "*", SearchOption.AllDirectories))
            {
                string toFolder = item.Replace(source.FullPath, destination.FullPath);
                if (!Directory.Exists(toFolder))
                    Directory.CreateDirectory(toFolder);
            }

            foreach (var item in Directory.GetFiles(source.FullPath, "*", SearchOption.AllDirectories))
            {
                string toFile = item.Replace(source.FullPath, destination.FullPath);
                File.Copy(item, toFile, true);
            }
        }
    }
}
