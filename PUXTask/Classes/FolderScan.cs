using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PUXTask.Classes
{
    public class FolderScan
    {
        private IEnumerable<FileInfo> scanDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            // muze vyhodit vyjimky, v tomto ukazkovem pripade nebudu osetrovat
            return di.GetFiles("*.*", SearchOption.AllDirectories);
        }

        public MyFolder InicialFolderScan(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new NullReferenceException("Cesta nemuze byt prazdna!");
            }

            IEnumerable<FileInfo> files = scanDirectory(path);

            MyFolder myFolder = new MyFolder()
            {
                Path = path,
                MyFiles = files.ToMyFileInfo()
            };

            return myFolder;
        }

        public MyFolder ChangesFolderScan(MyFolder storage, out List<MyFileInfo> newFiles, out List<MyFileInfo> changeFiles, out List<MyFileInfo> deletedFiles)
        {
            // overeni dat z local storage
            if (storage == null)
            {
                throw new NullReferenceException("Nebyl proveden inicialni scan!");
            }

            // znovu naskenovat adresar
            IEnumerable<MyFileInfo> rescan = scanDirectory(storage.Path).ToMyFileInfo();

            // zjistit seznam novych souboru
            newFiles = new List<MyFileInfo>();
            newFiles.AddRange(rescan.Where(x => !storage.MyFiles.Any(a => a.FullName == x.FullName)));
            storage.MyFiles.AddRange(newFiles);

            // zjistit seznam zmen
            List<MyFileInfo> _changeFiles = new List<MyFileInfo>();
            _changeFiles.AddRange(rescan.Where(x => storage.MyFiles.Any(a => a.FullName == x.FullName && a.Length != x.Length)));
            changeFiles = _changeFiles;
            //storage.MyFiles.Where(x => changeFiles.Any(a => a.FullName == x.FullName)).ForEach(x => x.Version++);
            storage.MyFiles.Where(x => _changeFiles.Any(a => a.FullName == x.FullName)).ToList().ForEach(x =>
            {
                MyFileInfo change = _changeFiles.First(a => a.FullName == x.FullName);

                x.Name = change.Name;
                x.Attributes = change.Attributes;
                x.CreationTime = change.CreationTime;
                x.Directory = change.Directory;
                x.DirectoryName = change.DirectoryName;
                x.Exists = change.Exists;
                x.Extension = change.Extension;
                x.FullName = change.FullName;
                x.LastAccessTime = change.LastAccessTime;
                x.LastWriteTime = change.LastWriteTime;
                x.Length = change.Length;
                x.Version++;
            });

            // zjistit seznam smazanych souboru
            List<MyFileInfo> _deletedFiles = new List<MyFileInfo>();
            _deletedFiles.AddRange(storage.MyFiles.Where(x => !rescan.Any(a => a.FullName == x.FullName) && !x.Deleted));
            deletedFiles = _deletedFiles;
            storage.MyFiles.Where(x => _deletedFiles.Any(a => a.FullName == x.FullName)).ToList().ForEach(x => x.Deleted = true);

            // ulozit zmeny do local storage
            return storage;
        }
    }
}