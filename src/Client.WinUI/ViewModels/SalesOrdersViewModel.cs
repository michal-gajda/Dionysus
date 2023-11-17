namespace Dionysus.Client.WinUI.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using MvvmDialogs;

public partial class SalesOrdersViewModel : ObservableObject, IModalDialogViewModel
{
    public bool? DialogResult { get; } = true;
}
