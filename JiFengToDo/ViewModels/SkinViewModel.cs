using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JiFengToDo.ViewModels
{
    public class SkinViewModel : BindableBase
    {
        private readonly PaletteHelper paletteHelper = new();


        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;

        public DelegateCommand<Object> ChangeHueCommand { get; private set; }

        private bool isDarkTheme = true;
        public bool IsDarkTheme
        {
            get => isDarkTheme;
            set
            {
                if (SetProperty(ref isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
            }
        }

        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }

        private void ChangeHue(object? obj)
        {
            var color = (Color)obj!;
            Theme theme = paletteHelper.GetTheme();

            theme.PrimaryLight = new ColorPair(color.Lighten());
            theme.PrimaryMid = new ColorPair(color);
            theme.PrimaryDark = new ColorPair(color.Darken());

            theme.SecondaryLight = new ColorPair(color.Lighten());
            theme.SecondaryMid = new ColorPair(color);
            theme.SecondaryDark = new ColorPair(color.Darken());

            paletteHelper.SetTheme(theme);

            //var hue = (Color)obj!;

            //SelectedColor = hue;
            //if (ActiveScheme == ColorScheme.Primary)
            //{
            //    _paletteHelper.ChangePrimaryColor(hue);
            //    _primaryColor = hue;
            //    _primaryForegroundColor = _paletteHelper.GetTheme().PrimaryMid.GetForegroundColor();
            //}
            //else if (ActiveScheme == ColorScheme.Secondary)
            //{
            //    _paletteHelper.ChangeSecondaryColor(hue);
            //    _secondaryColor = hue;
            //    _secondaryForegroundColor = _paletteHelper.GetTheme().SecondaryMid.GetForegroundColor();
            //}
            //else if (ActiveScheme == ColorScheme.PrimaryForeground)
            //{
            //    SetPrimaryForegroundToSingleColor(hue);
            //    _primaryForegroundColor = hue;
            //}
            //else if (ActiveScheme == ColorScheme.SecondaryForeground)
            //{
            //    SetSecondaryForegroundToSingleColor(hue);
            //    _secondaryForegroundColor = hue;
            //}
        }

        private void InitCommands()
        {
            ChangeHueCommand = new DelegateCommand<Object>(ChangeHue);
        }

        public SkinViewModel()
        {

        }

    }
}
