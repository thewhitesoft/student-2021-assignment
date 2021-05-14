using System.IO;

//Класс для работы с файлом

namespace WhiteSoft.Classes
{
    class AFile: DiskEntity
    {
        private FileInfo info;
        private string extension;

        public FileInfo Info { get => info; set => info = value; }
        public string Extension { get => extension; set => extension = value; }

        public AFile()
        {
            Name = "Unknown";
            Extension = "Unknown";
            Size = 0;
            Info = null;
        }

        public AFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new System.Exception("Указанный файл не существует!");
            }

            info = new FileInfo(path);
            Name = info.Name;
            Extension = info.Extension;
            Size = info.Length;
        }

        public AFile(AFile other_file)
        {
            Name = other_file.Name;
            Extension = other_file.Extension;
            Size = other_file.Size;
            Info = other_file.Info;
        }

        public void Rename(string new_name)
        {
            int copy_number = 0;

            string name = new_name;

            while ((new FileInfo(info.Directory.FullName + '/' + new_name + info.Extension)).Exists)
            {
                copy_number++;
                new_name = name + "(" + copy_number + ')';
            }

            info.MoveTo(info.Directory.FullName + '/' + new_name + info.Extension);
        }

    }
}
