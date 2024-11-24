using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Finance.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand AddTransactionViewCommand { get; set; }
        public ICommand BudgetViewCommand { get; set; }
        public ICommand ReportsViewCommand { get; set; }
        public ICommand UserWindowCommand { get; set; }
        public MainViewModel()
        {
            AddTransactionViewCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                AddTransactionView Window = new AddTransactionView();
                Window.ShowDialog();
            }
           );

            BudgetViewCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                BudgetView Window = new BudgetView();
                Window.ShowDialog();
            }
           );

            ReportsViewCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                ReportsView Window = new ReportsView();
                Window.ShowDialog();
            }
           );

            UserWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                UserWindow Window = new UserWindow();
                Window.ShowDialog();
            }
           );
        }
    }
}
