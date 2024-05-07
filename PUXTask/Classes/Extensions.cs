using System.Collections.Generic;
using System.IO;

namespace PUXTask.Classes
{
    public static class Extensions
    {
        public static List<MyFileInfo> ToMyFileInfo(this IEnumerable<FileInfo> fileInfo)
        {
            if (fileInfo == null)
                return new List<MyFileInfo>();

            List<MyFileInfo> list = new List<MyFileInfo>();
            foreach (var item in fileInfo)
            {
                list.Add(new MyFileInfo()
                {
                    Name = item.Name,
                    Attributes = item.Attributes,
                    CreationTime = item.CreationTime,
                    Directory = item.Directory,
                    DirectoryName = item.DirectoryName,
                    Exists = item.Exists,
                    Extension = item.Extension,
                    FullName = item.FullName,
                    LastAccessTime = item.LastAccessTime,
                    LastWriteTime = item.LastWriteTime,
                    Length = item.Length
                });
            }
            return list;
        }
    }
}