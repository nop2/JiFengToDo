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
        private ObservableCollection<ToDoDto> todoDtos;
        private ObservableCollection<MemoDto> memoDtos;


        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<ToDoDto> TodoDtos
        {
            get { return todoDtos; }
            set { todoDtos = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
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

        private void CteateDtos()
        {
            TodoDtos = new ObservableCollection<ToDoDto>
            {
                new ToDoDto { Id = 1, Title = "完成项目报告", Content = "完成项目报告", },
                new ToDoDto { Id = 2, Title = "准备会议材料", Content = "准备会议材料" },
                new ToDoDto { Id = 3, Title = "更新代码库", Content = "更新代码库" },
                new ToDoDto { Id = 1, Title = "完成项目报告", Content = "完成项目报告" },
                new ToDoDto { Id = 2, Title = "准备会议材料", Content = "准备会议材料" },
                new ToDoDto { Id = 3, Title = "更新代码库", Content = "更新代码库" },
                new ToDoDto { Id = 1, Title = "完成项目报告", Content = "完成项目报告" },
                new ToDoDto { Id = 2, Title = "准备会议材料", Content = "准备会议材料" },
                new ToDoDto { Id = 3, Title = "更新代码库", Content = "更新代码库" },
            };

            MemoDtos = new ObservableCollection<MemoDto>
            {
                new MemoDto { Id = 1, Title = "会议纪要", Content = "会议纪要内容" },
                new MemoDto { Id = 2, Title = "项目计划", Content = "项目计划内容" },
                new MemoDto { Id = 3, Title = "个人备忘", Content = "个人备忘内容" },
            };
        }

        public IndexViewModel()
        {
            CreateTaskBars();
            CteateDtos();
        }

    }
}
