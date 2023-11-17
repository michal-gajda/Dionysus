namespace Dionysus.Client.WinUI.Views;

using CommunityToolkit.Mvvm.DependencyInjection;
using Dionysus.Client.WinUI.ViewModels;

public partial class PurchaseOrdersView : System.Windows.Window
{
    public PurchaseOrdersView()
    {
        InitializeComponent();
        this.DataContext = Ioc.Default.GetService<PurchaseOrdersViewModel>();
    }

    public PurchaseOrdersViewModel ViewModel => (PurchaseOrdersViewModel)this.DataContext;
}
