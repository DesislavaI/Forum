﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
	public class Topic
	{
		public Topic()
		{
			Comments = new List<Comment>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Title { get; set; }

		[ForeignKey("Category")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }

		[Required]
		public string Description { get; set; }

		[Display(Name = "Created Day")]
		public DateTime CreatedDay { get; set; }

		[Display(Name = "Last Updated Day")]
		public DateTime LastUpdatedDay { get; set; }

		[ForeignKey("Author")]
		public string AuthorId { get; set; }
		public virtual ApplicationUser Author{ get; set; }

		public List<Comment> Comments { get; set; }

		[NotMapped]
		[Display(Name = "Number Comments")]
		public int NumberComments => Comments.Count;

		public bool IsAuthor(string id)
		{
			return this.Author.UserName.Equals(id);
		}

	}
}
