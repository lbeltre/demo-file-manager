using Dfm.Core.Models;

namespace Dfm.Web.Models
{
    public class TreeViewModel
    {

        public static TreeModel<List<TreeModel<bool>>>[] Transform(FolderItemInfo item)
        {
            TreeModel<List<TreeModel<bool>>>[] arr = new TreeModel<List<TreeModel<bool>>>[1];

            var result = new TreeModel<List<TreeModel<bool>>>
            {
                Id = "",
                Text = "root",
                State = new State
                {
                    Opened = true,
                    Disabled = true
                }
            };

            arr[0] = result;

            return arr;
        }


        public static List<TreeModel<bool>> Transform(List<FolderItemInfo> models, string root)
        {
            var data = models.Select(s => new TreeModel<bool>
            {
                Id = s.FullPath.Replace(root, string.Empty),
                Text = s.Name,
                Children = s.Folders.Any()
            }).ToList();

            return data;
        }
    }
}
