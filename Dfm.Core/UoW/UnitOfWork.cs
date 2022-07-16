using Dfm.Core.Commands;
using Dfm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CommandManager commandManager;

        public UnitOfWork(CommandManager manager)
        {
            commandManager = manager;
        }

        public void CreateFolder(FolderItemInfo item)
        {
            commandManager.Invoke(new CreateFolderCommand(item));
        }
    }
}
