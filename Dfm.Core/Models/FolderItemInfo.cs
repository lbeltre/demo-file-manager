namespace Dfm.Core.Models
{
    public class FolderItemInfo : ItemInfo
    {
        public List<FileItemInfo> Files { get; } = new();
        public List<FolderItemInfo> Folders { get; } = new();


        public FolderItemInfo(string name) : base(name) { }

        public override string GetSize()
        {
            return $"Content: {Files.Count} | Size: {Files.Sum(s => s.Size)}";
        }
    }
}
