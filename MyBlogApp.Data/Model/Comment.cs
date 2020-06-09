namespace MyBlogApp.Data.Model
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


        public int? ConnectedCommendId { get; set; }

        [Column("CommentContent")]
        [Required]
        [StringLength(1500)]
        public string CommentContent { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(100)]
        public string NameSurname { get; set; }

        [Required]
        [StringLength(500)]
        public string Email { get; set; }


        public int? LikedCount { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
