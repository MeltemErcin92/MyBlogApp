namespace MyBlog.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [StringLength(1500)]
        public string CommentContext { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(100)]
        public string NameSurname { get; set; }

        public int LikeCount { get; set; }

        public int ArticleId { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int? ConnectedCommentId { get; set; }

        public bool? isActive { get; set; }

        public virtual Article Article { get; set; }
    }
}
