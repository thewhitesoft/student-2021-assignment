using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteSoft.Classes
{
    abstract class DiskEntity //Абстрактый класс объекта на диске
    {
        private long size;
        private string name;
        private string path;

        public long Size { get => size; set => size = value; }
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
    }
}
