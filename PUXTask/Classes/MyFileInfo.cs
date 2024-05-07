using System;
using System.IO;

namespace PUXTask.Classes
{
    public class MyFileInfo
    {
        public MyFileInfo()
        {
            _version = 1;
            _deleted = false;
        }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Extension { get; set; }
        public DirectoryInfo Directory { get; set; }
        public string DirectoryName { get; set; }
        public long Length { get; set; }
        public bool Exists { get; set; }
        public FileAttributes Attributes { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }

        private int _version;
        public int Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }

        private bool _deleted;
        public bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                _deleted = value;
            }
        }
    }
}