using BusinessLayer2.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2
{
    public class ServiceFactory
    {
        public IImageProcessor CreateImaeService()
        {
            return new ImageProcessor();
        }
    }
}
