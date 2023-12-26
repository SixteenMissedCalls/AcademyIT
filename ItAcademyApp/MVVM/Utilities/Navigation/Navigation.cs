using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ItAcademyApp.MVVM.Utilities.Navigation
{
    public static class NavigationService
    {
        static private Frame _frame { get; set; }

        public static void Initialize(Frame frame)
        {
            _frame = frame;
        }
        public static void NavigateTo(Page page, BaseViewModel viewModel)
        {
            page.DataContext = viewModel;
            _frame.Navigate(page);
        }
    }
}
