using ItAcademyApp.MVVM.Models;
using ItAcademyApp.MVVM.Utilities;
using ItAcademyApp.MVVM.Utilities.Navigation;
using ItAcademyApp.MVVM.Utilities.Validators.Utilities;
using ItAcademyApp.MVVM.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ItAcademyApp.MVVM.ViewModel
{
    public class EditInfoVM : BaseViewModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        private User _user;

        public RelayCommand saveChangesCommand { get; set; }
        public EditInfoVM(User user)
        {
            _user = user;
            Login = user.Login;
            FirstName = user.FirstName;
            Surname = user.Surname;
            saveChangesCommand = new RelayCommand(executeCommand, canexecuteCommand);
        }

        private bool canexecuteCommand(object obj)
        {
            if (!ValiodatorConfigFunc.IsMatch(FirstName, new Regex("^[А-Яа-я]+$"))
                && !ValiodatorConfigFunc.IsMatch(FirstName, 2, 25)
                && !ValiodatorConfigFunc.IsMatch(Surname, new Regex("^[А-Яа-я]+$"))
                && !ValiodatorConfigFunc.IsMatch(Surname, 2, 25)
                && !ValiodatorConfigFunc.IsMatch(Login, 2, 25))
                {
                    return true;
                }
            return false;
        }

        private void executeCommand(object obj)
        {
            RegistrationViewModel.Instanse.database.EditUser(_user, Login, FirstName, Surname);
            NavigationService.NavigateTo(new Account(), new AccountVM(_user));
        }
    }
}
