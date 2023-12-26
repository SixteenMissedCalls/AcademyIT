using ItAcademyApp.MVVM.Models;
using ItAcademyApp.MVVM.Utilities;
using ItAcademyApp.MVVM.Utilities.Navigation;
using ItAcademyApp.MVVM.Views.Pages;
using ItAcademyApp.MVVM.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ItAcademyApp.MVVM.ViewModel
{
    public class UserVm : BaseViewModel
    {
        private User _user;
        public RelayCommand switcherCourse {  get; set; }
        public RelayCommand switcherAccount { get; set; }
        public UserVm(User user)
        {
            User = user;
            switcherCourse = new RelayCommand(executeCourseSwitchCommand);
            switcherAccount = new RelayCommand(executeAccountSwitchCommand);
            Navigator(new Course(), new CourseVm(user));
        }

        private void executeAccountSwitchCommand(object obj)
        {
            NavigationService.NavigateTo(new Account(), new AccountVM(_user));
        }

        private void executeCourseSwitchCommand(object obj)
        {
            NavigationService.NavigateTo(new Course(), new CourseVm(_user));
        }

        private void Navigator(Page page, BaseViewModel baseVm)
        {
            NavigationService.NavigateTo(page, baseVm);
        }

        public User User { get => _user; set => _user = value; }
    }
}
