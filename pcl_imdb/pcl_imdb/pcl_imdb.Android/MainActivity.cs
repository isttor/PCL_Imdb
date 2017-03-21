using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using pcl_imdb.Services;

namespace pcl_imdb.Droid
{
	[Activity (Label = "pcl_imdb.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        MovieService service = new MovieService();

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.searchButton);
            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            Button searchButton = (Button)sender;
            searchButton.Enabled = false;
            TextView textViewResult = FindViewById<TextView>(Resource.Id.txtResult);
            textViewResult.Text = string.Empty;
            textViewResult.Text = await service.SearchMoviesAsync("Limitless");
            searchButton.Enabled = true;
        }
    }
}


