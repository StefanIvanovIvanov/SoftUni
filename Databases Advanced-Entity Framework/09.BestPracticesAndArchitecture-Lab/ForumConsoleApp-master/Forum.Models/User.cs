﻿using System.Collections.Generic;

namespace Forum.Models
{
	public class User
    {
	    public User()
	    {
	    }

	    public User(string username, string password)
	    {
		    this.Username = username;
		    this.Password = password;
	    }

	    public int Id { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

	    public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
