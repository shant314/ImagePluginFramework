using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Models
{
    public class ImageEffect
    {
        public Constants.ImageEffectType EffectType { get; set; }
        public int GradiusLevel { get; set; }

        public ImageEffect()
        {
            GradiusLevel = 1;
        }
    }
}
