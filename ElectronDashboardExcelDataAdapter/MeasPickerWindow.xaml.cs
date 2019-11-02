using AdapterUtils;
using Microsoft.Win32;
using OfficeOpenXml;
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
using System.Windows.Shapes;

namespace ElectronDashboardExcelDataAdapter
{
    /// <summary>
    /// Interaction logic for MeasPickerWindow.xaml
    /// </summary>
    public partial class MeasPickerWindow : Window
    {
        // This Configuration data varaible Config_ can be handy here while dealing application secrets or configurations...
        public MeasPickerWindow()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ShutdownApp();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            // send selected measurement inforamtion to the console
            string excelFilename = ExcelFilenameTextBox.Text;
            string selectedDataCol = DataColumnNamesComboBox.SelectedItem?.ToString();
            string selectedTimeCol = TimeColumnNamesComboBox.SelectedItem?.ToString();
            string resultText = $"{excelFilename}|{selectedDataCol}|{selectedTimeCol}";
            ConsoleUtils.FlushMeasData(resultText, resultText, resultText);

            // Close the app after sending the data
            ShutdownApp();
        }

        private void ShutdownApp()
        {
            Application.Current.Shutdown();
        }

        private void OpenExcelFilenameBtn_Click(object sender, RoutedEventArgs e)
        {
            // https://www.wpf-tutorial.com/dialogs/the-openfiledialog/
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fname = openFileDialog.FileName;
                ExcelFilenameTextBox.Text = fname;
                //check if file exists
                if (!File.Exists(fname))
                {
                    MessageBox.Show($"could not find a file by name - {fname}");
                }
                //populate excel columns - https://stackoverflow.com/a/13162400/2746323
                List<string> columnNames = new List<string>();
                FileInfo excelFileInfo = new FileInfo(fname);
                ExcelPackage package = new ExcelPackage(excelFileInfo);
                ExcelWorksheet sheet = package.Workbook.Worksheets[1];
                foreach (var rowCell in sheet.Cells[sheet.Dimension.Start.Row, sheet.Dimension.Start.Column, 1, sheet.Dimension.End.Column])
                {
                    columnNames.Add(rowCell.Text);
                }
                // changing combobox options
                DataColumnNamesComboBox.ItemsSource = columnNames;
                TimeColumnNamesComboBox.ItemsSource = columnNames;
                if (columnNames.Count > 0)
                {
                    DataColumnNamesComboBox.SelectedIndex = 0;
                    TimeColumnNamesComboBox.SelectedIndex = 0;
                }
            }
        }
    }
}
