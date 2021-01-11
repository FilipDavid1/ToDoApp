﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using System.Xml.Serialization;
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

        public void SaveToDos()
        {
            XmlSerializer serializer = new XmlSerializer(ToDos.GetType());
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                serializer.Serialize(sw, ToDos);
            }
        }

        

    }
}