using Microsoft.Toolkit.Mvvm.Input;

namespace VRROOMRemote;

public partial class MainPage : ContentPage
{
   

    //TelnetConnection telnetConnection;

    public MainPage()
	{
		InitializeComponent();

        BindingContext = new MainPageModel(this);

        //telnetConnection = new TelnetConnection("192.168.1.3", 2222);

    }

  
}

