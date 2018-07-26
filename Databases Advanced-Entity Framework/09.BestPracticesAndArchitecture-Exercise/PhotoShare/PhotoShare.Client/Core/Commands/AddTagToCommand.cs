using PhotoShare.Models;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;

    public class AddTagToCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IAlbumService albumService;
        private readonly IAlbumTagService albumTagService;

        public AddTagToCommand(ITagService tagService,IAlbumService albumService, IAlbumTagService albumTagService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] args)
        {
            string albumTitle = args[0];
            string tagName = args[1];

            var tagExists = this.tagService.Exists(tagName);

            var albumExists = this.albumService.Exists(albumTitle);

            if (!tagExists || !albumExists)
            {
                throw new ArgumentException($"Either tag or album do not exist!");
            }

            var tag = this.tagService.ByName<Tag>(tagName);
            var album = this.albumService.ByName<Album>(albumTitle);

            this.albumTagService.AddTagTo(album.Id, tag.Id);

            return $"Tag {tag.Name} added to {album.Name}";
        }
    }
}
