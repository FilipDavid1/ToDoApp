using System;
using System.IO;
using ToDoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    public partial class App : Application
    {

        ToDosService toDosService;

        public App()
        {
            InitializeComponent();
            toDosService = new ToDosService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "todos.xml"));
            toDosService.LoadToDos();

            MainPage = new NavigationPage(new ToDoListPage(toDosService));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
