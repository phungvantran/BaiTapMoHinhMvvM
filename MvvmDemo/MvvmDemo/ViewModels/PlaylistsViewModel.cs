using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmDemo.ViewModels
{
    class PlaylistsViewModel:BaseViewModel
    {
        private PlaylistViewModel _selectedPlaylist;
        private readonly IPageService _pageServicel;
        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();
       
        public PlaylistViewModel SelectedPlaylist
        {
            get{return _selectedPlaylist;}
            set{SetValue(ref _selectedPlaylist, value);}
        }

        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }
       
        public PlaylistsViewModel(IPageService pageService)
        {
            _pageServicel = pageService;
            AddPlaylistCommand = new Command(AddPlaylist);
            SelectPlaylistCommand = new Command<PlaylistViewModel>(vm => SelectPlaylist(vm));
        }

        private void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }
        private async void SelectPlaylist(PlaylistViewModel playlist)
        {
            if (playlist == null)
                return;
            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlaylist = null;

            await _pageServicel.PushAsync(new PlaylistDetailPage(playlist));
        }
    }
}
