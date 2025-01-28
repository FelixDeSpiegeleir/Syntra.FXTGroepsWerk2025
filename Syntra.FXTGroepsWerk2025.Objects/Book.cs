using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN.GroupProject2.Objects
{
    public class Book
    {
        [Key]
        public int Id { get; private set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public virtual Author Author { get; set; } // virtual for lazy loading
        public bool IsRead { get; set; }
    }
}
