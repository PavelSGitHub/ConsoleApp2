using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class FileMaster
    {
        private string _filepath;
        public FileMaster(string filepath)
        {
            this._filepath = filepath;
        }
        public string extension()
        {
            return _filepath.Split('.').Last();
        }
        public string filename()
        {
            return _filepath.Split('/').Last().Split('.').First();
        }
        public string dirpath()
        {
            return _filepath[0.._filepath.IndexOf(_filepath.Split('/').Last())];
        }
    }
}
