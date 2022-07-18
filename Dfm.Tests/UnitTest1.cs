using Dfm.Core.UoW;

namespace Dfm.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var uow = new UnitOfWork(new Core.Commands.CommandManager());

            var ddd = uow.GetTree(@"C:\temp");
        }
    }
}