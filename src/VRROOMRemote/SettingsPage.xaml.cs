namespace VRROOMRemote;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(MainPageModel mainPageModel)
	{
		InitializeComponent();

		BindingContext = new SettingsPageModel(this, mainPageModel);
	}
}
