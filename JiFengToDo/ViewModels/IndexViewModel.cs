using JiFengToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiFengToDo.ViewModels
{
    public class IndexViewModel:BindableBase
    {
        private ObservableCollection<TaskBar> taskBars;


        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }


        private void CreateTaskBars()
        {
            TaskBars = new ObservableCollection<TaskBar>
            {
                new TaskBar
                {
                    Icon = "ClockFast",
                    Title = "汇总",
                    Content = "99",
                    Color = "#FF3F51B5",
                    Target = "IndexView"
                },
                new TaskBar
                {
                    Icon = "ClockCheckOutline",
                    Title = "已完成",
                    Content = "352",
                    Color = "#FF4CAF50",
                    Target = "ToDoView"
                },
                new TaskBar
                {
                    Icon = "ChartLineVariant",
                    Title = "完成率",
                    Content = "100%",
                    Color = "#FF9C27B0",
                    Target = "MemoView"
                },
                new TaskBar
                {
                    Icon = "PlaylistStar",
                    Title = "备忘录",
                    Content = "19",
                    Color = "#FF2196F3",
                    Target = "SettingsView"
                }
            };
        }

        public IndexViewModel()
        {
            CreateTaskBars();
        }

    }
}
