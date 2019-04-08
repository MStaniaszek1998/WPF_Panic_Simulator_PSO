using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZORD_3_PSO
{
    //done

    class Scout :Particle
    {
        
       
        public Scout(Pooint position) : base(position)
        {
            base.ZdjecieParticle = new Image();
            base.startX = position.X;
            base.startY = position.Y;
            base.timeAnimation = 0.8;
            GetImage();

        }
        
       

        public override Image ReturnImage()
        {
            return ZdjecieParticle;
        }

        protected override void GetImage()
        {
            Image solGreen = base.SetImage(Photos.sol_green);
            ZdjecieParticle = solGreen;
        }
    }
}
