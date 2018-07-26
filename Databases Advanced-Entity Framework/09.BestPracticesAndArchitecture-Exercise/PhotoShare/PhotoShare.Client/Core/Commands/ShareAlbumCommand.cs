using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private IAlbumService albumService;
        public ShareAlbumCommand(IAlbumService albumService)
        {
            this.albumService = albumService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            int albumId = int.Parse(data[0]);
            string userName = data[1];
            string permission = data[2];

            var album = this.albumService.ById<Album>(albumId);
            
            return $"Username {userName} added to album  {album.Name} ([{permission}])";
        }
    }
}
