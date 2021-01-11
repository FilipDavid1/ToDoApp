using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Models;

namespace ToDoApp
{
    class ToDosService
    {


        string filePath;

        public ObservableCollection<ToDo> ToDos { get; private set; }

        public ToDosService(string filePath)
        {
            this.filePath = filePath;
            ToDos = new ObservableCollection<ToDo>();
        }

    }
}