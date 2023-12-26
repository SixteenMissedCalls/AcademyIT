using ItAcademyApp.MVVM.Models;
using ItAcademyApp.MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademyApp.MVVM.ViewModel
{
    class AdminVm : BaseViewModel
    {
        private User _user;
        public ObservableCollection<Order> Orders;
        public User User { get => _user; set => _user = value; }
        private string _login;
        private string _firstName;
        private string _surname;
        private string _group;
        public string Login
        {
            get
            {
                return _login;
            }
            set { _login = value; OnPropertyyChanged(nameof(Login)); }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set { _firstName = value; OnPropertyyChanged(nameof(FirstName)); }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set { _surname = value; OnPropertyyChanged(nameof(Surname)); }
        }
        public string Group
        {
            get
            {
                return _group;
            }
            set { _group = value; OnPropertyyChanged(nameof(Group)); }
        }
        private int orderNumb = 0;


        public RelayCommand NextOrder { get; set; }
        public RelayCommand DeleteOrder { get; set; }
        public AdminVm(User user)
        {
            NextOrder = new RelayCommand(executeNext, canExecuteNext);
            DeleteOrder = new RelayCommand(executeDelete);
            User = user;
            Orders = RegistrationViewModel.Instanse.database.orders;
            ShowOrder();
        }

        private void executeDelete(object obj)
        {
            if(Orders.Count > 0)
            {
                RegistrationViewModel.Instanse.database.DeleteOrder(Orders[orderNumb]);
            }
            if (Orders.Count == 0)
            {
                Login = "";
                FirstName = "";
                Surname = "";
                Group = "";
                return;
            }

            var order = Orders[orderNumb];
            if (order == null)
            {
                return;
            }
            var user = RegistrationViewModel.Instanse.database.GetUser(order.Id);
            if (user == null)
            {
                return;
            }
            Login = user.Login;
            FirstName = user.FirstName;
            Surname = user.Surname;
            Group = user.Group;
        }

        private bool canExecuteNext(object obj)
        {
            if(Orders.Count - 1 > orderNumb)
            {
                return true;
            }
            return false;
        }

        private void executeNext(object obj)
        {
            orderNumb++;
            ShowOrder();
        }

        public void ShowOrder()
        {
            var order = Orders[orderNumb];
            if(order == null)
            {
                return;
            }
            var user = RegistrationViewModel.Instanse.database.GetUser(order.Id);
            if(user == null)
            {
                return;
            }
            Login = user.Login;
            FirstName = user.FirstName;
            Surname = user.Surname;
            Group = user.Group;
        }

        
    }
}
