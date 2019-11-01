using AdapterUtils;
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
using System.Windows.Shapes;

namespace ElectronDashboardDummyDataAdapter
{
    /// <summary>
    /// Interaction logic for MeasPickerWindow.xaml
    /// </summary>
    public partial class MeasPickerWindow : Window
    {
        // This Configuration data varaible Config_ can be handy here while dealing application secrets or configurations...
        public ConfigurationManager Config_ { get; set; } = new ConfigurationManager();
        public MeasPickerWindow()
        {
            InitializeComponent();
            Config_.Initialize();
            LoadMeasurements();
        }

        private void LoadMeasurements()
        {
            // get your list of measurements here, may be from a database or an API.
            List<string> measIds = new List<string>() { "first_meas_id", "second_meas_id", "third_meas_id", "fourth_meas_id" };
            
            // Populate measurements in the UI for user to pick the measurement
            UtilNamesComboBox.ItemsSource = measIds;
            UtilNamesComboBox.SelectedIndex = 0;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ShutdownApp();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            // send selected measurement inforamtion to the console
            string selectedUtil = UtilNamesComboBox.SelectedItem.ToString();
            string resultText = $"{selectedUtil}";
            ConsoleUtils.FlushMeasData(resultText, resultText, resultText);

            // Close the app after sending the data
            ShutdownApp();
        }

        private void ShutdownApp()
        {
            Application.Current.Shutdown();
        }
    }
}
