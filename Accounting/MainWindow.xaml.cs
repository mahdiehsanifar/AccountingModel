using AccountingLib;
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

namespace Accounting
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

        private static Customer SetRegular()
        {
            var customer = new Customer();
            var standard = new ServiceAgreement()
            {
                Rate = 10
            };

            var rule = new MultiplyByRatePR(EntryTypeConst.Base_Usage);
            standard.AddPostingRule(AccountingEventTypeConst.Usage, rule, DateTime.Parse("1999/10/01"));
            customer.ServiceAgreement = standard;

            return customer;
        }

        private void TestUsage(Customer customer)
        {
            var whenEccurred = DateTime.Parse("1999/10/01");
            var whenNoticed = DateTime.Parse("1999/10/01");
            var usageEvent = new UsageAccountingEvent(50, whenEccurred, whenNoticed, customer);
            usageEvent.Process();
            var resultingEntry = customer.GetEntries();
        }

        private void Do_Click(object sender, RoutedEventArgs e)
        {
            var acmeCoffeeMakersCustomer = SetRegular();

            TestUsage(acmeCoffeeMakersCustomer);
        }

        private class AccountingEventTypeConst
        {
            public static readonly AccountingEventType Usage = new AccountingEventType();
        }

        private class EntryTypeConst
        {
            public static readonly EntryType Base_Usage = new EntryType();
        }
    }
}
