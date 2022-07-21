using Dfm.Core.Models;
using Dfm.Web.Models;

namespace Dfm.Web.Code
{
    internal interface ITreeClientAdapter
    {
        TreeModel<List<TreeModel<bool>>>[] GetRoot();
        List<TreeModel<bool>> GetChilds(bool all = false);
    }

    public class TreeClientAdapter : ITreeClientAdapter
    {
        private readonly FolderItemInfo model;
        private readonly string root;

        public TreeClientAdapter(FolderItemInfo model, string root)
        {
            this.model = model;
            this.root = root;
        }

        public List<TreeModel<bool>> GetChilds(bool all = false)
        {
            var dat = new List<TreeModel<bool>>();
            dat.AddRange(model.Folders.Select(s => new TreeModel<bool>
            {
                Id = s.FullPath.Replace(root, string.Empty),
                Text = s.Name,
                UniqueIdentifier = GetChildIdentifier(model.Created, model.Name, s.Name),
                Children = s.Folders.Any()
            }));

            if (all)
                dat.AddRange(model.Files.Select(s => new TreeModel<bool>
                {
                    Id = s.FullPath.Replace(root, string.Empty),
                    Text = s.Name,
                    Type = "file",
                    UniqueIdentifier = GetChildIdentifier(model.Created, model.Name, s.Name)
                }));

            return dat;
        }

        public TreeModel<List<TreeModel<bool>>>[] GetRoot()
        {
            return new TreeModel<List<TreeModel<bool>>>[] {
                new TreeModel<List<TreeModel<bool>>>
                {
                        Id = string.Empty,
                        Text = model.Name,
                        UniqueIdentifier = GetChildIdentifier(model.Created, model.Name),
                        State = new State
                        {
                            Opened = true,
                            Disabled = true
                        },
                        Children = GetChilds()
                    }
                };
        }

        private string GetChildIdentifier(DateTime date, params string[] names)
        {
            return $"{string.Join(string.Empty, names.Select(s => s.Replace(" ", "_")))}_{date.Ticks}";
        }
    }
}
