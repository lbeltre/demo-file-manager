namespace Dfm.Core.Models
{
    public abstract class ItemInfo
    {
        protected ItemInfo(string name)
        {
            Name = Path.GetFileNameWithoutExtension(name);

            var directory = Path.GetDirectoryName(name);
            Location = directory.EndsWith(@"\") ? directory.Remove(directory.Length - 1) : directory;
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public virtual string FullPath => String.IsNullOrEmpty(Location) ? Name : $@"{Location}\{Name}";
        public DateTime Created { get; set; }

        public abstract string GetSize();
    }
}
