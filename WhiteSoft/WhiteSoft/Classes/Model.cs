using System.IO;
using System;
using System.Collections.Generic;

//Класс, реализующий основную логику приложения 
namespace WhiteSoft.Classes
{
    class Model
    {
        private readonly string source;
        private readonly string dest ;

        public Model(string src, string dst)
        {
            source = src;
            dest = dst;
        }

        public void Activate()
        {
          
            ADirectory src_dir = new ADirectory(@"C:\Test-task-for-the-white-soft\WhiteSoft\src\Utrom's secrets");
           
            ADirectory working_dir = new ADirectory(src_dir.Copy(@"C:\Test-task-for-the-white-soft\WhiteSoft\src\Utrom's secrets", @"C:\Test-task-for-the-white-soft\WhiteSoft\dest" + '/' + src_dir.Name, true)); //Получаем путь к скопированной в папку dest директории source 

            CheckForDouble(working_dir.Path);
            Dir_CheckForDouble(working_dir);
        }

        private void Dir_CheckForDouble(ADirectory directory) //Для каталогов 
        {
            List<ADirectory> subdirs = new List<ADirectory> { };           //Получение списка субдиректорий и информации о них
            List<string> names_wout_uuid = new List<string> { };          //Имена директорий без UUID
            int double_counter = 0;

            foreach (DirectoryInfo dir in directory.Info.GetDirectories())
            {
                subdirs.Add(new ADirectory(dir.FullName));
                
                names_wout_uuid.Add(DeleteUUID(dir.Name,0));
            }

           

            for (int i = 0; i < subdirs.Count; i++) //Для каждой субдиректории из директории directory
            {
                for (int j = i+1; j < subdirs.Count; j++) //Проверяем каждую другую субдиректорию в directory
                {
                    if (names_wout_uuid[i] == names_wout_uuid[j]) //Если совпадают имена двух директорий (без UUID)
                    {
                       
                        foreach(AFile file1 in subdirs[i].files) //Проверяем количество совпадающих файлов в директориях
                        {
                            foreach (AFile file2 in subdirs[j].files)
                            {
                                
                                if (DeleteUUID(file1.Name,file1.Extension.Length) == DeleteUUID(file2.Name, file2.Extension.Length) &&
                                    file1.Extension == file2.Extension)
                                {
                                    double_counter++;
                                }
                            }
                        }
                        if(subdirs[i].files.Count == subdirs[j].files.Count && double_counter == subdirs[i].files.Count) //Если все файлы в двух директориях совпадают
                        {
                           subdirs[i].Info.Delete(true); //то удаляем первую директорию со всем содержимым
                            
                        }    
                        else subdirs[i].Rename(names_wout_uuid[i]); //Иначе переименовываем
                        
                    }
                    
                }
                
            }

        }

        private void CheckForDouble(string path) // Удаление дубликатов в выбранной папке
        {
            ADirectory directory = new ADirectory(path);
            List<string> names_wout_uuid = new List<string> { };

            foreach (AFile file in directory.files)
            {
                names_wout_uuid.Add(DeleteUUID(file.Name,file.Extension.Length));
            }

            for (int i = 0; i < directory.files.Count; i++)
            {
                for (int j = i + 1; j < directory.files.Count; j++)
                {
                    if (names_wout_uuid[i] == names_wout_uuid[j] && directory.files[i].Extension == directory.files[j].Extension) //Если у файлов одинаковые имена 
                    {                                                                                                          //без UUID и расширения
                        if (directory.files[i].Size == directory.files[j].Size)                                               //а также одинаковый размер
                        {                                                                                                    //тогда
                            directory.files[j].Info.Delete();                                                               //Удаляем дубликат
                        }
                    }
                }
                directory.files[i].Rename(names_wout_uuid[i]); //Переименовываем первый файл после завершения проверки на дубликаты
            }
        }


        private string DeleteUUID(string name, int extension_lenght) //Функция удаления UUID из имени
        {
            string name_wout_id = ""; //Имя без UUID
            int j = 0;

                for (int i = name.Length - extension_lenght - 37; i >= 0; i--) //Поскольку UUID состоит из 36 символов, то последние 37 символов
                {                                           //плюс расширение исходного имени игнорируются, а новое имя посимвольно записывается
                    name_wout_id += name[j];                 //в name_wout_id
                    j++;
                }   
            return name_wout_id;
        }

    }
}
