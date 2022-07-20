namespace Dfm.Core.Models
{
    public class FileItemInfo : ItemInfo
    {
        public FileItemInfo(string name, long size) : base(name)
        {
            Extension = Path.GetExtension(name);
            Size = size;
        }

        public string FullName => $"{Name}{Extension}";
        public string Extension { get; }
        public long Size { get; }
        public DateTime Modified { get; set; }

        public override string FullPath => $"{base.FullPath}{Extension}";

        public override string GetSize()
        {
            return $"Size {Size}";
        }
    }
}
