using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using WhiteSoft.Classes;


namespace WhiteSoft
{
    public partial class MainWindow : Window
    {
        private string source_folder_path;
        private string dest_folder_path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChooseSourceFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                source_folder_path = fbd.SelectedPath;

                Source.Text = source_folder_path;
            }
            else throw new SystemException("Ошибка выбора папки");
        }

        private void ChooseDestFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                dest_folder_path = fbd.SelectedPath;

                Dest.Text = dest_folder_path;
            }
            else throw new SystemException("Ошибка выбора папки");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Model model = new Model(source_folder_path, dest_folder_path);
            model.Activate(); 
        }


        
    }
}

