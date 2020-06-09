using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.AppClass
{
  public  class CategoryResult
    {

        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(200)]
        public string Explation { get; set; }

        public DateTime CreateDate { get; set; }

        public bool? Status { get; set; }
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }
    }
}
