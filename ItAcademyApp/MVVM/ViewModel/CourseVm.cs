using ItAcademyApp.MVVM.Models;
using ItAcademyApp.MVVM.Utilities;
using ItAcademyApp.MVVM.Utilities.Navigation;
using ItAcademyApp.MVVM.Views.Pages;
using System;


namespace ItAcademyApp.MVVM.ViewModel
{
    public class CourseVm : BaseViewModel
    {
        public RelayCommand first {  get; set; }
        public RelayCommand second { get; set; }
        public RelayCommand third { get; set; }
        public RelayCommand fourth { get; set; }
        private User _user;
        public CourseVm(User user)
        {
            first = new RelayCommand(executeFirst);
            second = new RelayCommand(executeSecond);
            third = new RelayCommand(executeThird);
            fourth = new RelayCommand(executeFourth);
            _user = user;
        }

        private void executeFourth(object obj)
        {
            NavigationService.NavigateTo(new CourseInfo(), new CourseInfoVm(_user, "Программирование C++", "Курс “Программирование на C++” предназначен для тех, кто хочет изучить один из самых популярных и мощных языков программирования. Вы узнаете об основных принципах языка, научитесь работать с данными, управлять памятью, разрабатывать эффективные алгоритмы и структурировать код. В процессе обучения вы создадите несколько проектов, которые помогут закрепить полученные знания и приобрести практические навыки.", "Штин А.А."));
        }

        private void executeThird(object obj)
        {
            NavigationService.NavigateTo(new CourseInfo(), new CourseInfoVm(_user, "Android-разработчик", "Курс по Android разработке подготовит вас к карьере в качестве Android разработчика. Вы изучите основы программирования, проектирования и разработки приложений для Android, получите навыки работы с библиотеками и инструментами, освоите создание пользовательских интерфейсов и использование различных компонентов.", "Шалимов В.А."));

        }

        private void executeSecond(object obj)
        {
            NavigationService.NavigateTo(new CourseInfo(), new CourseInfoVm(_user, "Web программирование C#", "Курс по C# Web - это интенсивное изучение основ программирования на языке C# для создания современных веб-приложений и API. Участники научатся разрабатывать динамические сайты, использовать инструменты .NET Core и Entity Framework, работать с базами данных, создавать безопасные и масштабируемые приложения. Курс включает в себя теорию, практические задания и проекты для закрепления полученных навыков.", "Петров П.Д."));

        }

        private void executeFirst(object obj)
        {
            NavigationService.NavigateTo(new CourseInfo(), new CourseInfoVm(_user, "Программирование C#", "Курс по C# охватывает основы языка программирования C#, включая такие темы, как типы данных, переменные, операторы, управляющие структуры, классы, интерфейсы, методы, свойства, события и многое другое. Вы изучите концепции объектно-ориентированного программирования (ООП) и функциональное программирование, чтобы создавать надежные и эффективные приложения. Курс подходит для начинающих программистов, а также для тех, кто хочет улучшить свои навыки в области разработки на C#.", "Иванов А.А."));
        }
    }
}
