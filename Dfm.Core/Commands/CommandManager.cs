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
