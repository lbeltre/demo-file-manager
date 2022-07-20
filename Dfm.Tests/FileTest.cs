using Dfm.Core.Commands;
using Dfm.Core.Models;

namespace Dfm.Tests
{
    public class FileTest
    {
        static (string Filename, long Size) GenerateFile(string directory)
        {
            var file = Path.Combine(directory, $"{Guid.NewGuid()}.txt");

            using var streamWriter = File.CreateText(file);
            streamWriter.WriteLine(Guid.NewGuid());
            streamWriter.WriteLine(DateTime.Now.ToLongTimeString());
            streamWriter.Flush();

            return (file, streamWriter.BaseStream.Length);
        }

        [Fact]
        public void Command_Copy()
        {
            var directory = $@"C:\temp-test_{Guid.NewGuid()}";
            Directory.CreateDirectory(directory);

            (string Filename, long Size) = GenerateFile(directory);

            var directoryTo = $@"C:\temp-test_to_{Guid.NewGuid()}";
            Directory.CreateDirectory(directoryTo);

            var source = new FileItemInfo(Filename, Size);
            var cmd = new CopyFileCommand(source, new FolderItemInfo(directoryTo));
            cmd.Execute();

            Assert.True(File.Exists(Filename) && File.Exists(Path.Combine(directoryTo, source.FullName)));
        }

        [Fact]
        public void Command_Move()
        {
            var directory = $@"C:\temp-test_{Guid.NewGuid()}";
            Directory.CreateDirectory(directory);

            (string Filename, long Size) = GenerateFile(directory);

            var directoryTo = $@"C:\temp-test_move_{Guid.NewGuid()}";
            Directory.CreateDirectory(directoryTo);

            var source = new FileItemInfo(Filename, Size);
            var cmd = new MoveFileCommand(source, new FolderItemInfo(directoryTo));
            cmd.Execute();

            Assert.True(!File.Exists(Filename) && File.Exists(Path.Combine(directoryTo, source.FullName)));
        }


        [Fact]
        public void Command_Remove()
        {
            var directory = $@"C:\temp-test_{Guid.NewGuid()}";
            Directory.CreateDirectory(directory);
            (string Filename, long Size) = GenerateFile(directory);

            var cmd = new RemoveFileCommand(new FileItemInfo(Filename, Size));
            cmd.Execute();

            Assert.True(!File.Exists(Filename));
        }
    }
}