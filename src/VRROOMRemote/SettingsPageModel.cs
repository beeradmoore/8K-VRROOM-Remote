using System;
using System.Diagnostics;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace VRROOMRemote;

[INotifyPropertyChanged]
public partial class SettingsPageModel
{
    WeakReference<SettingsPage> weakPage;
    WeakReference<MainPageModel> weakMainPageModel;

    public SettingsPageModel(SettingsPage settingsPage, MainPageModel mainPageModel)
    {
        weakPage = new WeakReference<SettingsPage>(settingsPage);
        weakMainPageModel = new WeakReference<MainPageModel>(mainPageModel);
    }

    [ICommand]
    async Task SaveAsync()
    {
        if (weakPage?.TryGetTarget(out SettingsPage settingsPage) == true && weakMainPageModel?.TryGetTarget(out MainPageModel mainPageModel) == true)
        {
            // TODO: Update weakMainPageModel
            await settingsPage.Navigation.PopModalAsync();
        }
    }

    [ICommand]
    async Task CloseAsync()
    {
        if (weakPage?.TryGetTarget(out SettingsPage settingsPage) == true)
        {
            await settingsPage.Navigation.PopModalAsync();
        }
    }
}

