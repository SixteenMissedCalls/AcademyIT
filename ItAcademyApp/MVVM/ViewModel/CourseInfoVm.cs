using ItAcademyApp.MVVM.Models;
using ItAcademyApp.MVVM.Utilities;
using ItAcademyApp.MVVM.Utilities.Navigation;
using ItAcademyApp.MVVM.Views.Pages;
using System;
using System.Windows;

namespace ItAcademyApp.MVVM.ViewModel
{
    public class CourseInfoVm : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        private User _user;

        public RelayCommand createRequestFirst {  get; set; }
        public RelayCommand createRequestSecond { get; set; }
        public CourseInfoVm(User user, string name, string description, string teacher)
        {
            Name = name;
            Description = description;
            Teacher = teacher;
            _user = user;
            createRequestFirst = new RelayCommand(executeRequestOne);
            createRequestSecond = new RelayCommand(executeRequestTwo);
        }

        private void executeRequestOne(object obj)
        {
            if (_user.Group == "" || _user.Group == null)
            {
                RegistrationViewModel.Instanse.database.MakeRequest(_user, $"{Name} вечерняя", Teacher);
                RegistrationViewModel.Instanse.database.CreateOrder(_user, $"{Name} вечерняя");
                NavigationService.NavigateTo(new Account(), new AccountVM(_user));
            }
            else
                MessageBox.Show("Вы уже записаны на курс");
            
        }

        private void executeRequestTwo(object obj)
        {
            if (_user.Group == "" || _user.Group == null)
            {
                RegistrationViewModel.Instanse.database.MakeRequest(_user, $"{Name} утренняя", Teacher);
                RegistrationViewModel.Instanse.database.CreateOrder(_user, $"{Name} утренняя");
                NavigationService.NavigateTo(new Account(), new AccountVM(_user));
            }
            else
                MessageBox.Show("Вы уже записаны на курс");
        }
    }
}
