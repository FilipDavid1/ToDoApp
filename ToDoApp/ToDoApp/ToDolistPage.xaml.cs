using System;
using ToDoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoListPage : ContentPage
    {
        ToDosService toDosService;

        public ToDoListPage(ToDosService toDosService)
        {
            this.toDosService = toDosService;

            InitializeComponent();

            BindingContext = toDosService;
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoDetailPage(toDosService)
            {
                BindingContext = new ToDo { IsDone = false }
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ToDoDetailPage(toDosService)
                {
                    BindingContext = e.SelectedItem as ToDo
                });

                listView.SelectedItem = null;
            }
        }

        private void CheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            toDosService.SaveToDos();
        }
    }
}