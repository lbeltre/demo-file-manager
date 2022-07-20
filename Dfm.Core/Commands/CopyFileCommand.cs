using Dfm.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Dfm.Core.Commands
{
    internal class CopyFileCommand : ICommand
    {
        private readonly FileItemInfo source;
        private readonly FolderItemInfo destination;


        public CopyFileCommand(FileItemInfo from, FolderItemInfo to)
        {
            source = from;
            destination = to;
        }

        public void Execute()
        {
            string toFile = Path.Combine(destination.FullPath, source.FullName);
            File.Copy(source.FullPath, toFile, true);
        }
    }
}
