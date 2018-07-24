using UIKit;
using System.Linq;
using System.Collections.Generic;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            IEnumerable<Song> data = await SongLoader.Load();

            ViewControllerSource<Song> viewControllerSource = new ViewControllerSource<Song>(TableView)
            {
                DataSource = data.ToList<Song>(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album
            };

            TableView.Source = viewControllerSource;
			//TableView.Source = new ViewControllerSource<string>(TableView) {
			//	DataSource = new string[] { "One", "Two", "Three" },
			//};
		}
	}

}

