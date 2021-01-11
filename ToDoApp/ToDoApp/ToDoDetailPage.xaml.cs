using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoDetailPage : ContentPage
    {
        ToDosService toDosService;

        public ToDoDetailPage(ToDosService toDosService)
        {
            this.toDosService = toDosService;

            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            ToDo toDo = (ToDo)BindingContext;

            if (!toDosService.ToDos.Contains(toDo))
            {
                toDo.Date = DateTime.Now;
                toDosService.AddToDo(toDo);
            }

            toDosService.SaveToDos();

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            ToDo toDo = (ToDo)BindingContext;

            toDosService.RemoveToDo(toDo);
            toDosService.SaveToDos();

            await Navigation.PopAsync();
        }
    }
}