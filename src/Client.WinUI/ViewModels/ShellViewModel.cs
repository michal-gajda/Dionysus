namespace Dionysus.Client.WinUI.ViewModels;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dionysus.Client.WinUI.Models;
using MediatR;
using Microsoft.Extensions.Logging;

public partial class ShellViewModel : ObservableObject
{
    private readonly ILogger<ShellViewModel> logger;
    private readonly ISender mediator;

    [ObservableProperty]
    private string title = "Shell View";

    [ObservableProperty]
    private string keyword = string.Empty;

    public ShellViewModel(ILogger<ShellViewModel> logger, ISender mediator)
    {
        (this.logger, this.mediator) = (logger, mediator);
        this.OkCommand = new AsyncRelayCommand(this.OkCommandAsync);
    }

    [ObservableProperty]
    private ObservableCollection<Product> items = new();

    [ObservableProperty]
    private Product? selectedItem;

    public IAsyncRelayCommand OkCommand { get; }

    private async Task OkCommandAsync(CancellationToken cancellationToken = default)
    {
        this.logger.LogInformation("{CommandName}", "OkCommandExecuteAsync");

        this.Items.Add(new Product { Id = Guid.NewGuid() });

        this.Title = $"Shell View - {DateTime.Now.Ticks}";

        await Task.CompletedTask;
    }
}
