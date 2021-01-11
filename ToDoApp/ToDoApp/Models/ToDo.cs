using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ToDoApp.Models
{
    public class ToDo : INotifyPropertyChanged
    {
        private string text;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
