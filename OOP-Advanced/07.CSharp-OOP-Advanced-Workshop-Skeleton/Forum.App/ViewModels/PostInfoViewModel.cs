﻿using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class PostInfoViewModel : IPostInfoViewModel
    {
        public PostInfoViewModel(int id, string title, int replyCount)
        {
            this.Id = id;
            this.Title = title;
            this.ReplyCount = replyCount;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public int ReplyCount { get; private set; }
    }
}
