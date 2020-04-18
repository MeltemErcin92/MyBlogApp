namespace MyBlog.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int MessageId { get; set; }

        [StringLength(100)]
        public string MessageSubject { get; set; }

        [Required]
        public string MessageContext { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}
