using JiFengToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JiFengToDo.ViewModels
{
    public class ToDoViewModel:BindableBase
    {
        private ObservableCollection<ToDoDto> todoDtos;

        public ObservableCollection<ToDoDto> TodoDtos
        {
            get { return todoDtos; }
            set { todoDtos = value; RaisePropertyChanged(); } 
        }

        private bool drawerStatus;

        public bool DrawerStatus
        {
            get { return drawerStatus; }
            set { drawerStatus = value; RaisePropertyChanged(); }
        }

        public DelegateCommand AddCommand { get; private set; }


        private void CreateToDoDtos()
        {
            TodoDtos = new ObservableCollection<ToDoDto>();
            for (int i = 0; i < 35; i++)
            {
                TodoDtos.Add(new ToDoDto
                {
                    Id = i + 1,
                    Title = $"待办事项 {i + 1}",
                    Content = $"这是待办事项 {i + 1} 的内容",
                    Status = i % 2 // 假设偶数为未完成，奇数为已完成
                });
            }

        }

        private void InitCommands()
        {
            AddCommand = new DelegateCommand(() =>
            {
                DrawerStatus = true;
            });
        }

        public ToDoViewModel()
        {
            CreateToDoDtos();
            InitCommands();
        }
    }
}
