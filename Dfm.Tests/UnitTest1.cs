using Dfm.Core.Code;
using Dfm.Core.Commands;
using Dfm.Core.Models;
using Dfm.Core.UoW;

namespace Dfm.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var source = new FolderItemInfo(@"C:\temp");
            var destination = new FolderItemInfo(@"C:\temp-test");

            var cmd = new CopyFolderCommand(source, destination);
            cmd.Execute();


            Assert.True(true);
        }
    }
}