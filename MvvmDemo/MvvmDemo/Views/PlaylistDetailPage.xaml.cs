using MvvmDemo.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MvvmDemo
{
    public partial class PlaylistDetailPage : ContentPage
    {
        private PlaylistViewModel _playlist;

        public PlaylistDetailPage(PlaylistViewModel playlist)
        {
            _playlist = playlist;
            BindingContext = _playlist;
            
            InitializeComponent();

            //title.Text = _playlist.Title;
        }
    }
}
