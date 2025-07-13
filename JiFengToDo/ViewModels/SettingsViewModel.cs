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
    public class SettingsViewModel:BindableBase
    {
        private ObservableCollection<MenuBar> menuBars;

        private IRegionManager regionManager;


        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }

        private void Navigate(MenuBar menuBar)
        {
            if (menuBar == null) return;
            regionManager.RequestNavigate(PrismManager.SettingsRegionName, menuBar.NameSpace);
        }

        private void InitCommands()
        {
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
        }

        private void CreateMenuBars()
        {
            MenuBars = new ObservableCollection<MenuBar>
            {
                new MenuBar
                {
                    Icon = "Palette",
                    Title = "个性化",
                    NameSpace = "SkinView"
                },
                new MenuBar
                {
                    Icon = "Cog",
                    Title = "系统设置",
                    NameSpace = ""
                },
                 new MenuBar
                {
                    Icon = "Information",
                    Title = "关于更多",
                    NameSpace = "AboutView"
                }
            };
        }


        public SettingsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            CreateMenuBars();
            InitCommands();
        }
    }
}
