namespace Dfm.Web.Models
{
    public class TreeModel<T>
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public T Children { get; set; }
        public State State { get; set; }
        public string UniqueIdentifier { get; set; }
    }

    public class State
    {
        public bool Opened { get; set; }
        public bool Disabled { get; set; }
        public bool Selected { get; set; }
    }
}
