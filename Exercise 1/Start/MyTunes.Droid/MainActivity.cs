using System.Linq;
using Android.App;
using Android.OS;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            var data = await SongLoader.Load();

            ListAdapter<Song> listAdapter = new ListAdapter<Song>
            {
                DataSource = data.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album
            };

            ListAdapter = listAdapter;
			//ListAdapter = new ListAdapter<string>() {
			//	DataSource = new[] { "One", "Two", "Three" }
			//};
		}
	}
}


