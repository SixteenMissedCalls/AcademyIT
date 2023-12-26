using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ItAcademyApp.MVVM.Models;
using ItAcademyApp.MVVM.Utilities;
using ItAcademyApp.MVVM.Utilities.Validators.Utilities;
using ItAcademyApp.MVVM.Views.Windows;

namespace ItAcademyApp.MVVM.ViewModel
{
    public class LogInViewModel : BaseViewModel
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        private LoginWindow _loginWindow;
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand Sing { get; set; }
        public LogInViewModel(LoginWindow window)
        {
            _loginWindow = window;
            LoginCommand = new RelayCommand(executeSingCommand, CanSingExecute);
            Sing = new RelayCommand(executeCommand);
        }

        private void executeCommand(object obj)
        {
            RegistrationViewModel vm = new RegistrationViewModel();
            var newWindow = new MainWindow();
            newWindow.DataContext = vm;
            newWindow.Show();
            _loginWindow.Close();
        }

        private bool CanSingExecute(object obj)
        {
            if (!ValiodatorConfigFunc.IsMatch(Login, 2, 25))
            {
                return true;
            }
            return false;
        }

        private void executeSingCommand(object obj)
        {
            var passwordBox = obj as PasswordBox;
            var password = passwordBox.Password;
            var user = RegistrationViewModel.Instanse.database.GetUser(Login, password);
            if(user == null)
            {
                MessageBox.Show("Такого пользователя нет");
                return;
            }
            if(user.Login == "Admin")
            {
                AdminVm viewModel = new AdminVm(user);
                var window = new AdminInfo();
                window.DataContext = viewModel;
                window.Show();
               _loginWindow.Close();
                return;
            }
            var newWindow = new UserInfo();
            UserVm vm = new UserVm(user);
            newWindow.DataContext = vm;
            newWindow.Show();
            _loginWindow.Close();
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyyChanged(nameof(Login)); } 
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyyChanged(nameof(Password)); }
        }
    }
}
