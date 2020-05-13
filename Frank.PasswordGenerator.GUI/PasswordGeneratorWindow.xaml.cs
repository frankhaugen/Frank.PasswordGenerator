using System.Windows;

namespace Frank.PasswordGenerator.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PasswordGeneratorWindow : Window
    {
        public PasswordGeneratorWindow()
        {
            InitializeComponent();
        }

        private void GeneratePasswordButton_OnClick(object sender, RoutedEventArgs e)
        {
            var passwordGenerator = new PasswordGenerator();
            MessageBox.Show(passwordGenerator.GeneratePassword());
        }
    }
}