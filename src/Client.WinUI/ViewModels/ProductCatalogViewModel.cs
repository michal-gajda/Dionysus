namespace Dionysus.Client.WinUI.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using MvvmDialogs;

public partial class ProductCatalogViewModel : ObservableObject, IModalDialogViewModel
{
    public bool? DialogResult { get; } = true;
}
