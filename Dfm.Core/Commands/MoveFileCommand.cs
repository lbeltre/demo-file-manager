using Dfm.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Dfm.Core.Commands
{
    internal class MoveFileCommand : ICommand
    {
        private readonly FileItemInfo source;
        private readonly FolderItemInfo destination;


        public MoveFileCommand(FileItemInfo from, FolderItemInfo to)
        {
            source = from;
            destination = to;
        }

        public void Execute()
        {
            string toFile = Path.Combine(destination.FullPath, source.FullName);
            File.Move(source.FullPath, toFile);
        }
    }
}
