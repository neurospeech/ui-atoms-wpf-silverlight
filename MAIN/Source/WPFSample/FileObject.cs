using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;

namespace UIAtoms.WPFSamples
{
    class FileObject
    {

        public FileObject()
        {

        }

        public FileObject(string path)
        {
            FilePath = path;
            FileInfo fi = new FileInfo(FilePath);
            Name = string.IsNullOrEmpty(fi.Name) ? FilePath : fi.Name;
            if (fi.Exists)
                Size = fi.Length;
            IsDirecty = (fi.Attributes & FileAttributes.Directory) > 0;

            if (IsDirecty)
            {
                Files.Add(new FileObject { Name = "" });
                HasDummyChild = true;
            }
        }

        public string FilePath { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public bool IsDirecty { get; set; }

        public bool HasDummyChild { get; set; }

        #region Property IsExpandad
        private bool _IsExpanded = false;
        public bool IsExpanded
        {
            get
            {
                return _IsExpanded;
            }
            set
            {
                _IsExpanded = value;
                if (_IsExpanded && HasDummyChild)
                {
                    _Files.Clear();
                    HasDummyChild = false;
                    FileInfo fi = new FileInfo(FilePath);
                    foreach (string d in Directory.GetDirectories(FilePath))
                        _Files.Add(new FileObject(d));
                    foreach (string f in Directory.GetFiles(FilePath))
                        _Files.Add(new FileObject(f));
                }
            }
        }

        #endregion

        #region Propery Files
        private ObservableCollection<FileObject> _Files = new ObservableCollection<FileObject>();
        public ObservableCollection<FileObject> Files
        {
            get
            {
                if (!IsDirecty)
                    return null;
                return _Files;
            }
        }
        #endregion
    }
}
