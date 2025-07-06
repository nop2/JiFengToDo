using JiFengToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiFengToDo.ViewModels
{
    public class MemoViewModel:BindableBase
    {
        private bool isDrawerOpen = false;

        public bool IsDrawerOpen
        { 
            get => isDrawerOpen;
            set { isDrawerOpen = value; RaisePropertyChanged(); } 
        }

        public DelegateCommand AddCommand { get; set; }

        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; }
        }



        public MemoViewModel()
        {
            CreateMemoDtos();
            InitCommands();
        }

        private void InitCommands()
        {
            AddCommand = new DelegateCommand(() =>
            {
                IsDrawerOpen = true;
            });
        }

        private void CreateMemoDtos()
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            for (int i = 0; i < 35; i++)
            {
                MemoDtos.Add(new MemoDto
                {
                    Id = i + 1,
                    Title = $"备忘录 {i + 1}",
                    Content = $"这是备忘录 {i + 1} 的内容, ",
                    Status = i % 2 // 假设偶数为未完成，奇数为已完成
                });
            }
        }
    }
}
