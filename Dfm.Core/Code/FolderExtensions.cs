using Dfm.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfm.Core.Code
{
    //TODO change to internal
    public static class FolderExtensions
    {

        public static FolderItemInfo GetTree(string path)
        {
            if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                throw new ValidationException("Invalid folder path");

            var dir = new DirectoryInfo(path);
            var folder = new FolderItemInfo(dir.Name)
            {
                Location = dir.Parent?.FullName ?? string.Empty,
                Created = dir.CreationTime,
            };

            foreach (var item in Directory.EnumerateFileSystemEntries(path))
            {
                if (File.GetAttributes(item).HasFlag(FileAttributes.Directory))
                    folder.Folders.Add(GetTree(item));
                else
                {
                    var file = new FileInfo(item);
                    var fileItem = new FileItemInfo(file.Name)
                    {
                        Location = file?.DirectoryName ?? string.Empty,
                        Size = file.Length,
                        Created = file.CreationTime,
                        Modified = file.LastWriteTime
                    };

                    folder.Files.Add(fileItem);
                }
            }

            return folder;
        }

        public static IEnumerable<string> GetTreePath(string path)
        {
            var paths = new List<string>();

            if (!File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                paths.Add(path);
            else
            {
                foreach (var item in Directory.EnumerateFileSystemEntries(path))
                {
                    if (File.GetAttributes(item).HasFlag(FileAttributes.Directory))
                        GetTreePath(item).ToList().ForEach(f => paths.Add(f));
                    else
                    {
                        paths.Add(item);
                    }
                }
            }

            return paths;
        }
    }
}

