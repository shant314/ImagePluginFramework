using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] FileData { get; set; }
    }
}
