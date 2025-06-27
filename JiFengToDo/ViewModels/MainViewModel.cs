using JiFengToDo.Common.Models;
using JiFengToDo.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiFengToDo.ViewModels
{
    public class MainViewModel : BindableBase
    {

        #region Commands

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        public DelegateCommand GoBackCommand { get; private set; }

        public DelegateCommand GoForwardCommand { get; private set; }


        #endregion

        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        private void InitCommands()
        {
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);

            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                {
                    journal.GoBack();
                }
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                {
                    journal.GoForward();
                }
            });
        }


        private void Navigate(MenuBar bar)
        {
            if (bar == null || string.IsNullOrEmpty(bar.NameSpace))
            {
                return;
            }

            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(bar.NameSpace, callback =>
            {
                journal = callback.Context.NavigationService.Journal;
            });
        }

        private void CreateMenuBars()
        {
            MenuBars = new ObservableCollection<MenuBar>
            {
                new MenuBar { Icon = "Home", Title = "首页", NameSpace = "IndexView" },
                new MenuBar { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "ToDoView" },
                new MenuBar { Icon = "NoteAlert", Title = "备忘录", NameSpace = "MemoView" },
                new MenuBar { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" },

            };
        }

        public MainViewModel(IRegionManager regionManager)
        {
            CreateMenuBars();
            this.regionManager = regionManager;
            InitCommands();
        }

    }
}
