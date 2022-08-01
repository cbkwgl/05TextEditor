using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _05TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newFile_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Document.Blocks.Clear();
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            //Open a file using OpenFileDialog function. If selected: 1. Read the data through StreamReader 2. Document.Blocks.Clear to empty the box 3. AppendText to append text at the end 4. Clear the file reader
            OpenFileDialog fd = new OpenFileDialog();
            if(fd.ShowDialog()==true)
            {
                StreamReader reader = new StreamReader(fd.FileName);
                txtBox.Document.Blocks.Clear();
                txtBox.AppendText(reader.ReadToEnd());
                reader.Close();
            }
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if(sf.ShowDialog()==true)
            {
                StreamWriter writer = new StreamWriter(sf.FileName);
                string text = new TextRange(txtBox.Document.ContentStart, txtBox.Document.ContentEnd).Text;
                Console.Write(text);
                writer.Write(text);
                writer.Close();
            }    
        }

        private void closeFile_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
