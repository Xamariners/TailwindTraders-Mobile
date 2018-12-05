using System.Windows.Input;
using TailwindTraders.Mobile.Features.Common;
using TailwindTraders.Mobile.Features.LogIn;
using TailwindTraders.Mobile.Features.Product.Category;
using TailwindTraders.Mobile.Features.Scanning.Photo;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.Features.Shell
{
    internal class TheShellViewModel : BaseViewModel
    {
        public ICommand PhotoCommand => new AsyncCommand(
            _ => App.NavigateModallyToAsync(new CameraPage(), animated: false));

        public ICommand ARCommand => FeatureNotAvailableCommand;

        public ICommand LogOutCommand => new AsyncCommand(_ => App.NavigateModallyToAsync(new LogInPage()));

        public ICommand ProductTypeCommand => new AsyncCommand(
            typeId => (App.Current.MainPage as TheShell).GoToAsync($"app:///tailwindtraders/a/b/home/category?id={typeId}", true));

        public ICommand ProfileCommand => FeatureNotAvailableCommand;

        public ICommand GoToCategoryCommand => new Command<string>(GoToCategory);

        void GoToCategory(string id)
        {
            (App.Current.MainPage as TheShell).GoToAsync($"app:///tailwindtraders/a/b/home/category?id={id}", true);
        }
    }
}