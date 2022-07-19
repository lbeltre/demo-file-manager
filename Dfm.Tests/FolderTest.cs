using Dfm.Core.Code;
using Dfm.Core.Commands;
using Dfm.Core.Models;
using Dfm.Core.UoW;

namespace Dfm.Tests
{
    public class FolderTest
    {
        [Fact]
        public void Command_Create()
        {
            var directory = $@"C:\temp-test_{Guid.NewGuid()}";
            var source = new FolderItemInfo(directory);

            var cmd = new CreateFolderCommand(source);
            cmd.Execute();

            Assert.True(Directory.Exists(directory));

            Directory.Delete(directory);
        }


        [Fact]
        public void Command_Copy()
        {
            var directory = $@"C:\temp-test_{Guid.NewGuid()}";
            Directory.CreateDirectory(directory);

            var file = Path.Combine(directory, $"{Guid.NewGuid()}.txt");
            
            using var streamWriter = File.CreateText(file);
            streamWriter.WriteLine(Guid.NewGuid());
            streamWriter.WriteLine(DateTime.Now.ToLongTimeString());    
            streamWriter.Flush();

            var directoryTo = $@"C:\temp-test_to_{Guid.NewGuid()}";
            Directory.CreateDirectory(directoryTo);

            var cmd = new CopyFolderCommand(new FolderItemInfo(directory), new FolderItemInfo(directoryTo));
            cmd.Execute();

            Assert.True(Directory.Exists(directory) && Directory.Exists(directoryTo));
        }

        [Fact]
        public void Command_Move()
        {
            var directory = $@"C:\temp-test_{Guid.NewGuid()}";
            Directory.CreateDirectory(directory);

            var file = Path.Combine(directory, $"{Guid.NewGuid()}.txt");

            using var streamWriter = File.CreateText(file);
            streamWriter.WriteLine(Guid.NewGuid());
            streamWriter.WriteLine(DateTime.Now.ToLongTimeString());
            streamWriter.Flush();

            var directoryTo = $@"C:\temp-test_move_{Guid.NewGuid()}";
            Directory.CreateDirectory(directoryTo);

            var cmd = new MoveFolderCommand(new FolderItemInfo(directory), new FolderItemInfo(directoryTo));
            cmd.Execute();

            Assert.True(!Directory.Exists(directory) && Directory.Exists(directoryTo));
        }


        [Fact]
        public void Command_Remove()
        {
            var directory = $@"C:\temp-test_{Guid.NewGuid()}";
            Directory.CreateDirectory(directory);

            var cmd = new RemoveFolderCommand(new FolderItemInfo(directory));
            cmd.Execute();

            Assert.True(!Directory.Exists(directory));
        }
    }
}