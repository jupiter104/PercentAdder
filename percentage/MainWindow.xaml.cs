using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace percentage
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAmount.Text == "Amount")
                txtAmount.Text = "";
        }

        private void txtAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text.Last()) && !(e.Text.Last() == '.');
        }

        private void txtPercentage_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPercentage.Text == "Per")
                txtPercentage.Text = "";
        }

        private void txtPercentage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text.Last()) && !(e.Text.Last() == '.');
        }

        float amount = 0;
        float percent = 0;
        float total = 0;
        float interest = 0;
        string strTotal = "";
        string strInterest = "";

        private void lblEqual_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (txtAmount.Text == "Amount" || string.IsNullOrWhiteSpace(txtAmount.Text)
                || txtPercentage.Text == "Per" || string.IsNullOrWhiteSpace(txtPercentage.Text))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                amount = float.Parse(txtAmount.Text, CultureInfo.InvariantCulture);
                percent = float.Parse(txtPercentage.Text, CultureInfo.InvariantCulture);
                total = amount * (percent / 100 + 1);
                interest = amount * (percent / 100);
                strTotal = string.Format("{0:N0}", total);
                strInterest = string.Format("{0:N0}", interest);
                lblTotal.Content = strTotal.ToString();
                lblInterest.Content = strInterest.ToString();
            }
        }
    }
}
