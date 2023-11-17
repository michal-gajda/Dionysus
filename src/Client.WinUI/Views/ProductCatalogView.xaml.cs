namespace Dionysus.Client.WinUI.Views;

using CommunityToolkit.Mvvm.DependencyInjection;
using Dionysus.Client.WinUI.ViewModels;

public partial class ProductCatalogView : System.Windows.Window
{
    public ProductCatalogView()
    {
        InitializeComponent();
        this.DataContext = Ioc.Default.GetService<ProductCatalogViewModel>();
    }

    public ProductCatalogViewModel ViewModel => (ProductCatalogViewModel)this.DataContext;
}
