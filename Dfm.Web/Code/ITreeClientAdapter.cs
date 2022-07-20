using Dfm.Core.Models;
using Dfm.Web.Models;

namespace Dfm.Web.Code
{
    internal interface ITreeClientAdapter
    {
        TreeModel<List<TreeModel<bool>>>[] GetRoot();
        List<TreeModel<bool>> GetChilds();
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

        public List<TreeModel<bool>> GetChilds()
        {
            return model.Folders.Select(s => new TreeModel<bool>
            {
                Id = s.FullPath.Replace(root, string.Empty),
                Text = s.Name,
                Children = s.Folders.Any()
            }).ToList();
        }

        public TreeModel<List<TreeModel<bool>>>[] GetRoot()
        {
            return new TreeModel<List<TreeModel<bool>>>[] {
                new TreeModel<List<TreeModel<bool>>>
                {
                        Id = String.Empty,
                        Text = model.Name,
                        State = new State
                        {
                            Opened = true,
                            Disabled = true
                        },
                        Children = TreeViewModel.Transform(model.Folders, root)
                    }
                };
        }
    }
}
