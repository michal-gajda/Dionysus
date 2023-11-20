namespace Dionysus.Client.WinUI;

using System.ComponentModel;
using Dionysus.Client.WinUI.ViewModels;
using Dionysus.Client.WinUI.Views;
using MvvmDialogs.DialogTypeLocators;

public sealed class DialogTypeLocator : IDialogTypeLocator
{
    public Type Locate(INotifyPropertyChanged viewModel)
    {
        if (viewModel is null)
        {
            throw new ArgumentNullException(nameof(viewModel));
        }

        return viewModel switch
        {
            PurchaseOrdersViewModel => typeof(PurchaseOrdersView),
            ShellViewModel => typeof(ShellView),
            _ => throw new ArgumentException($"No dialog view type found for view model type {viewModel.GetType()}"),
        };
    }
}
