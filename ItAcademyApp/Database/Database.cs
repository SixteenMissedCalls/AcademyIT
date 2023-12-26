using ItAcademyApp.MVVM.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reactive.Linq;

namespace ItAcademyApp.Database
{
    public class DatabaseControl
    {
        private readonly string file = "F:\\Программная инженерия\\ItAcademyApp\\ItAcademyApp\\Users.json";
        private readonly string file2 = "F:\\Программная инженерия\\ItAcademyApp\\ItAcademyApp\\Orders.json";
        private List<User> users;
        public ObservableCollection<Order> orders;
        public DatabaseControl()
        {
            string f = File.ReadAllText(file);
            string f2 = File.ReadAllText(file2);
            users = JsonConvert.DeserializeObject<List<User>>(f);
            orders = JsonConvert.DeserializeObject<ObservableCollection<Order>>(f2);
        }

        public void CreateUser(User user)
        {
            user.Id = users.Count + 1; 
            users.Add(user);
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(file, json);
        }
        public User GetUser(string login, string password)
        {
            var itemUser = users.FirstOrDefault(item => item.Login == login && item.Password == password);
            if (itemUser != null)
            {
                return itemUser;
            }
            else return null;
        }
        public User GetUser(int id)
        {
            var itemUser = users.FirstOrDefault(item => item.Id == id);
            if (itemUser != null)
            {
                return itemUser;
            }
            else return null;
        }

        public void MakeRequest(User user, string group, string teacher)
        {
            var itemUser = users.FirstOrDefault(item => item.Id == user.Id);
            if (itemUser != null)
            {
                itemUser.Group = group;
                itemUser.Teacher = teacher;
            }
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(file, json);
        }

        public void EditUser(User user, string login, string name, string lastName)
        {
            var itemUser = users.FirstOrDefault(item => item.Id == user.Id);
            if (itemUser != null)
            {
                itemUser.FirstName = name;
                itemUser.Surname = lastName;
                itemUser.Login = login;
            }
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(file, json);
        }

        public void CreateOrder(User user, string group)
        {
            var itemUser = users.FirstOrDefault(item => item.Id == user.Id);
            if (itemUser != null)
            {
                Order order = new Order();
                order.Group = group;
                order.Id = user.Id;
                order.Login = user.Login;
                orders.Add(order);
            }
            string json = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(file2, json);
        }
        public void DeleteOrder(Order order)
        {
            orders.Remove(order);
            var itemUser = users.FirstOrDefault(item => item.Id == order.Id);
            itemUser.Teacher = "";
            itemUser.Group = "";
            string json = JsonConvert.SerializeObject(orders, Formatting.Indented);
            string json2 = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(file2, json);
            File.WriteAllText(file, json2);
        }
    }
}
