using System.Collections.Generic;
using System.IO;
using System;

//Класс для работы с директорией

namespace WhiteSoft.Classes
{
    class ADirectory : DiskEntity
    {
        private DirectoryInfo info;
        public List<AFile> files = new List<AFile>{};

        public DirectoryInfo Info { get => info; set => info = value; }

        public ADirectory()
        {
            Name = "Unknown";
            Size = 0;
            Info = null;
            Path = "Unknown";
        }

        public ADirectory(ADirectory other_directory)
        {
            Name = other_directory.Name;
            Size = other_directory.Size;
            info = other_directory.Info;
            Path = other_directory.Path;
            files.Clear();
            foreach (FileInfo file in info.GetFiles())
            {
                files.Add(new AFile(file.FullName));
            }
        }

        public ADirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new System.Exception("Указанной папки не существует!");
            }

            info = new DirectoryInfo(path);
            Name = info.Name;
            Path = path;
            CountSize();

           foreach (FileInfo file in info.GetFiles())
            {
                files.Add(new AFile(file.FullName));         
            }

        }

        public string Copy(string sourceDirPath, string destDirPath, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirPath);
            DirectoryInfo[] subdirs = dir.GetDirectories();

            if (new DirectoryInfo(destDirPath).Exists)
            {
                throw new System.Exception("Такая папка уже существует по указанному пути!");
            }

            Directory.CreateDirectory(destDirPath);

            FileInfo[] files = dir.GetFiles(); //Копирование файлов в исходной директории
            foreach (FileInfo file in files)
            {
                string tempPath = System.IO.Path.Combine(destDirPath, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs) //Копирование вложенных директорий
            {
                foreach (DirectoryInfo subdir in subdirs)
                {
                    string tempPath = System.IO.Path.Combine(destDirPath, subdir.Name);
                    Copy(subdir.FullName, tempPath, copySubDirs);
                }
            }

            return destDirPath;
        }

        private void CountSize()
        {
            Size = 0; //Сброс установленного размера

            DirectoryInfo[] subdirs = info.GetDirectories();
            FileInfo[] files = info.GetFiles();

            foreach (FileInfo file in files)
            {
                Size += file.Length;
            }

            foreach (DirectoryInfo directory in subdirs)
            {
                ADirectory dir = new ADirectory(directory.FullName);
                Size += dir.Size;
            }
        }

        public void Rename(string new_name)
        {
            int copy_number = 0; 

            while((new DirectoryInfo(info.Parent.FullName + '/' + new_name)).Exists)
            {
                copy_number++;
                new_name = new_name + " (" + copy_number + ')'; 
            }
            
            info.MoveTo(info.Parent.FullName + '/' + new_name);
        }
    }
}
