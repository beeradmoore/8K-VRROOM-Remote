using System;
using System.Diagnostics;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace VRROOMRemote;

[INotifyPropertyChanged]
public partial class MainPageModel
{
    WeakReference<MainPage> page;

    public MainPageModel(MainPage mainPage)
    {
        page = new WeakReference<MainPage>(mainPage);
    }

    [ICommand]
    async Task OpenSettingsAsync()
    {
        if (page?.TryGetTarget(out MainPage mainPage) == true)
        {
            await mainPage.Navigation.PushModalAsync(new NavigationPage(new SettingsPage(this)));
        }
    }
}

