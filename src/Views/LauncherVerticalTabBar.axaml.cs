using System;

using Avalonia.Controls;
using Avalonia.Input;

namespace SourceGit.Views
{
    public partial class LauncherVerticalTabBar : LauncherTabBarBase
    {
        public LauncherVerticalTabBar()
        {
            Width = Math.Clamp(ViewModels.Preferences.Instance.Layout.LauncherVerticalTabsWidth, MIN_WIDTH, MAX_WIDTH);
            InitializeComponent();
        }

        private void OnTabsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox { SelectedItem: { } selected } list)
                list.ScrollIntoView(selected);

            e.Handled = true;
        }

        private void OnResizeThumbDragDelta(object _, VectorEventArgs e)
        {
            Width = Math.Clamp(Width + e.Vector.X, MIN_WIDTH, MAX_WIDTH);
            ViewModels.Preferences.Instance.Layout.LauncherVerticalTabsWidth = Width;
            e.Handled = true;
        }

        private const double MIN_WIDTH = 120;
        private const double MAX_WIDTH = 480;
    }
}
