namespace Dionysus.Client.WinUI.Views;

using CommunityToolkit.Mvvm.DependencyInjection;
using Dionysus.Client.WinUI.ViewModels;

public partial class ShellView : System.Windows.Window
{
    public ShellView()
    {
        this.InitializeComponent();
        this.DataContext = Ioc.Default.GetService<ShellViewModel>();
    }

    public ShellViewModel ViewModel => (ShellViewModel)this.DataContext;
}
