
using Microsoft.AspNetCore.Components;

namespace MauiApp1.Components.Layout;

public partial class MainLayout
{
    [Inject] private NavigationManager Navigation { get; set; }
    private void NavigateToMe()
    {
        Navigation.NavigateTo("/me");
    }
    private void NavigateToHome()
    {
        Navigation.NavigateTo("/");
    }
    private void NavigateToMessages()
    {
        Navigation.NavigateTo("/messages");
    }
}
