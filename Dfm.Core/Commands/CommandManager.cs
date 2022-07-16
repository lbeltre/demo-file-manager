using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.Commands
{
    public class CommandManager
    {
        public void Invoke(ICommand command)
        {
            command.Execute();
        }
    }
}
