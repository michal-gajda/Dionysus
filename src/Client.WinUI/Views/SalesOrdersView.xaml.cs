namespace Dionysus.Client.WinUI.Views;

using CommunityToolkit.Mvvm.DependencyInjection;
using Dionysus.Client.WinUI.ViewModels;

public partial class SalesOrdersView : System.Windows.Window
{
    public SalesOrdersView()
    {
        InitializeComponent();
        this.DataContext = Ioc.Default.GetService<SalesOrdersViewModel>();
    }

    public SalesOrdersViewModel ViewModel => (SalesOrdersViewModel)this.DataContext;
}
