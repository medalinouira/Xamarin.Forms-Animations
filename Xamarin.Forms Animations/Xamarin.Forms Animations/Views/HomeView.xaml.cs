///
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_Animations.Models;

namespace Xamarin.Forms_Animations.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		public HomeView ()
		{
			InitializeComponent ();
            btnEasingFunctions.Clicked += new EventHandler((sender, args) => this.Navigation.PushAsync(new AnimationsView(AnimationType.Easing)));
            btnSimpleAnimations.Clicked += new EventHandler((sender, args) => this.Navigation.PushAsync(new AnimationsView(AnimationType.Simple)));
            btnCustomAnimations.Clicked += new EventHandler((sender, args) => this.Navigation.PushAsync(new AnimationsView(AnimationType.Custom)));
        }
	}
}