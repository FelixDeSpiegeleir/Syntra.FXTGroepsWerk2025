using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWN.GroupProject2.Objects
{
    public class Author
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
