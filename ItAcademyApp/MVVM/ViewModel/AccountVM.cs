using ItAcademyApp.MVVM.Models;
using ItAcademyApp.MVVM.Utilities;
using ItAcademyApp.MVVM.Utilities.Navigation;
using ItAcademyApp.MVVM.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademyApp.MVVM.ViewModel
{
    public class AccountVM : BaseViewModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public string Teacher { get; set; }
        private User _user;

        public RelayCommand EditInfo { get; set; }
        public AccountVM(User user)
        {
            Login = user.Login;
            FirstName = user.FirstName;
            Surname = user.Surname;
            Group = user.Group;
            Teacher = user.Teacher;
            EditInfo = new RelayCommand(executeEdit);
            _user = user;
        }

        private void executeEdit(object obj)
        {
            NavigationService.NavigateTo(new EditInfo(), new EditInfoVM(_user));
        }
    }
}
