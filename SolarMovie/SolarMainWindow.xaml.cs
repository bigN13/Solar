using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MahApps.Metro;
using MahApps.Metro.Controls;
using SolarMovie.Models;
using System.Data;
using System.Data.Entity;
using System.Data.SqlServerCe;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace SolarMovie
{
    public partial class SolarMainWindow
    {
        #region Properties
        private Theme currentTheme = Theme.Light;
        private Accent currentAccent = ThemeManager.DefaultAccents.First(x => x.Name == "Blue");
        #endregion

        #region Contstructor
        public SolarMainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
            var t = new DispatcherTimer(TimeSpan.FromSeconds(2), DispatcherPriority.Normal, Tick, this.Dispatcher);
        }
        #endregion

        #region Theme Related functionst
        void Tick(object sender, EventArgs e)
        {
            var dateTime = DateTime.Now;
            transitioning.Content = new TextBlock {Text = "Transitioning Content! " + dateTime, SnapsToDevicePixels = true};
            customTransitioning.Content = new TextBlock {Text = "Custom transistion! " + dateTime, SnapsToDevicePixels = true};
        }

        private void ChangeAccent(string accentName)
        {
            this.currentAccent = ThemeManager.DefaultAccents.First(x => x.Name == accentName);

            ThemeManager.ChangeTheme(this, this.currentAccent, this.currentTheme);
        }

        private void AccentRed(object sender, RoutedEventArgs e)
        {
            this.ChangeAccent("Red");
        }

        private void AccentGreen(object sender, RoutedEventArgs e)
        {
            this.ChangeAccent("Green");
        }

        private void AccentBlue(object sender, RoutedEventArgs e)
        {
            this.ChangeAccent("Blue");
        }

        private void AccentPurple(object sender, RoutedEventArgs e)
        {
            this.ChangeAccent("Purple");
        }

        private void AccentOrange(object sender, RoutedEventArgs e)
        {
            this.ChangeAccent("Orange");
        }

        private void ThemeLight(object sender, RoutedEventArgs e)
        {
            this.currentTheme = Theme.Light;
            ThemeManager.ChangeTheme(this, this.currentAccent, Theme.Light);
        }

        private void ThemeDark(object sender, RoutedEventArgs e)
        {
            this.currentTheme = Theme.Dark;
            ThemeManager.ChangeTheme(this, this.currentAccent, Theme.Dark);
        }

        private void LaunchVisualStudioDemo(object sender, RoutedEventArgs e)
        {
            new VSDemo().Show();
        }

        private void LaunchFlyoutDemo(object sender, RoutedEventArgs e)
        {
            new FlyoutDemo().Show();
        }

        private void LaunchPanoramaDemo(object sender, RoutedEventArgs e)
        {
            new PanoramaDemo().Show();
        }

        private void LaunchIcons(object sender, RoutedEventArgs e)
        {
            new IconsWindow().Show();
        }

        private void LauchCleanDemo(object sender, RoutedEventArgs e)
        {
            new CleanWindowDemo().Show();
        }

        private void LaunchRibbonDemo(object sender, RoutedEventArgs e)
        {
#if NET_4_5
            //new RibbonDemo().Show();
#else
            MessageBox.Show("Ribbon is only supported on .NET 4.5 or higher.");
#endif
        }

        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var flipview = ((FlipView)sender);
            switch (flipview.SelectedIndex)
            {
                case 0:
                    flipview.BannerText = "Cupcakes!";
                    break;
                case 1:
                    flipview.BannerText = "Xbox!";
                    break;
                case 2:
                    flipview.BannerText = "Chess!";
                    break;
            }
        }

        private void MetroTabControl_TabItemClosingEvent(object sender, BaseMetroTabControl.TabItemClosingEventArgs e)
        {
            if (e.ClosingTabItem.Header.ToString().StartsWith("sizes"))
                e.Cancel = true;
        }

        private void InteropDemo(object sender, RoutedEventArgs e)
        {
            new InteropDemo().Show();

        }


        #endregion


        private void btn_CreateDatabase_Click(object sender, RoutedEventArgs e)
        {

            //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

            using (var db = new MoviesContext())
            {
                var category = new Category();
                category.Name = "Funny";
                db.Categories.Add(category);
                db.SaveChanges();

                var query = from b in db.Categories
                            orderby b.Name
                            select b;

                lst_Categories.ItemsSource = query.ToList();

                
            }
        }
    }
}
