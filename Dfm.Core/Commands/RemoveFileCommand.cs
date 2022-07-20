using Dfm.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Dfm.Core.Commands
{
    internal class RemoveFileCommand : ICommand
    {
        private readonly FileItemInfo source;

        public RemoveFileCommand(FileItemInfo folder)
        {
            this.source = folder;
        }

        public void Execute()
        {
            if (!File.Exists(source.FullPath))
                throw new ValidationException($"File doesn't exists");

            File.Delete(source.FullPath);
        }
    }
}
