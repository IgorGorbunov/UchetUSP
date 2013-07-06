using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace UchetUSP.DifferentCalsses
{
    public sealed class TemporaryFile : IDisposable
    {
        public TemporaryFile() : this(Program.PathString) { }

        public TemporaryFile(string directory) {
            Create(Path.Combine(directory, Path.GetRandomFileName()+".bmp"));
        }

        ~TemporaryFile() {
            Delete();
         }

        public void Dispose() {
            Delete();
            GC.SuppressFinalize(this);
        }

        private string filePath = "";

        public string FilePath { get { return filePath; } private set { filePath = value; } }

        private void Create(string path)
        {            
            FilePath = path;
            using (File.Create(FilePath)) { };
        }

        private void Delete() {
            if (FilePath == null) return;
            File.Delete(FilePath);
            FilePath = null;        
        }

    }
}
