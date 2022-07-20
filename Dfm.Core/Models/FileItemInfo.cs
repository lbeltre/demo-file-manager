namespace Dfm.Core.Models
{
    public class FileItemInfo : ItemInfo
    {
        public FileItemInfo(string name) : base(name) { }

        public long Size { get; set; }
        public DateTime Modified { get; set; }

        public override string GetSize()
        {
            return $"Size {Size}";
        }
    }
}
