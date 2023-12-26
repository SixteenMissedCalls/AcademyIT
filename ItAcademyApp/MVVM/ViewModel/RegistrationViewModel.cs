using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using ItAcademyApp.MVVM.Utilities;
using ItAcademyApp.MVVM.Utilities.Validators.Utilities;
using ItAcademyApp.Database;
using ItAcademyApp.MVVM.Views.Windows;
using System.Windows;
using ItAcademyApp.MVVM.Models;

namespace ItAcademyApp.MVVM.ViewModel
{
    public class RegistrationViewModel : BaseViewModel
    {
        private string _firstName = string.Empty;
        private string _surname = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;
        public DatabaseControl database { get; set; }
        private static RegistrationViewModel _instanse;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyyChanged(nameof(FirstName));
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyyChanged(nameof(Surname));
            }
        }
        public RelayCommand SingUpCommand { get; set; }
        public RelayCommand LoginChanged { get; set; }
        public string Login
        {
            get
            {
                return _login;
            }
            set { _login = value; OnPropertyyChanged(nameof(Login)); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value ; OnPropertyyChanged(nameof(Password)); }
        }

        public static RegistrationViewModel Instanse
        {
            get
            {
                if(_instanse == null)
                {
                    _instanse = new RegistrationViewModel();
                }
                return _instanse;
            }
        }

        public RegistrationViewModel()
        {
            SingUpCommand = new RelayCommand(executeSingUpCommand, canExecuteSimgUpCommand);
            LoginChanged = new RelayCommand(executeSelectCommand);

            database = new DatabaseControl();
        }

        private void executeSelectCommand(object obj)
        {
            var newWindow = new LoginWindow();
            LogInViewModel vm = new LogInViewModel(newWindow);
            newWindow.DataContext = vm;
            Application.Current.MainWindow.Close();
            newWindow.Show();
        }

        private bool canExecuteSimgUpCommand(object obj)
        {
            if (!ValiodatorConfigFunc.IsMatch(FirstName, new Regex("^[А-Яа-я]+$")) 
                && !ValiodatorConfigFunc.IsMatch(FirstName, 2, 25)
                && !ValiodatorConfigFunc.IsMatch(Surname, new Regex("^[А-Яа-я]+$"))
                && !ValiodatorConfigFunc.IsMatch(Surname, 2, 25))
            {
                return true;
            }
            return false;
        }

        private void executeSingUpCommand(object obj)
        {
            var passwordBox = obj as PasswordBox;
            var password = passwordBox.Password;
            var user = new Models.User
            {
                Login = Login,
                Password = password,
                FirstName = FirstName,
                Surname = Surname,
            };
            Instanse.database.CreateUser(user);
            if(user.Login != "admin")
            {
                var newWindow = new UserInfo();
                UserVm vm = new UserVm(user);
                newWindow.DataContext = vm;
                newWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                var newWindow = new AdminInfo();
                AdminVm vm = new AdminVm(user);
                newWindow.DataContext = vm;
                newWindow.Show();
                Application.Current.MainWindow.Close();
            }
        }
    }
}
