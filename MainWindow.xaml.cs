using GM_Studio_2_Translate_Tool.Models;
using GM_Studio_2_Translate_Tool.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GM_Studio_2_Translate_Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string filePath = @"C:\Program Files\GameMaker Studio 2";
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("O programa só conseguirá salvar o arquivo no modo administrador!");
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            // TableLines name do datagrid
            TableLines.ItemsSource = FileTranslateReader.Read($"{filePath}\\Languages\\portuguese.csv");
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            List<FileStructure> fileStructures = (List<FileStructure>)TableLines.ItemsSource;
            FileTranslateReader.Write($"{filePath}\\Languages\\portuguese.csv", fileStructures);
        }
    }
}
