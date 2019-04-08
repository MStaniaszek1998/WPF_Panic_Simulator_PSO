using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZORD_3_PSO
{
    //done

    class Car : Particle
    {
        


        public Car(Pooint position) : base(position)
        {
            base.ZdjecieParticle = new Image();
            base.startX = position.X;
            base.startY = position.Y;
            base.timeAnimation = 0.07;
            GetImage();
        }

        public override Image ReturnImage()
        {
            return base.ZdjecieParticle;
        }

       

        protected override void GetImage()
        {
            Image samochod = base.SetImage(Photos.auto);
            base.ZdjecieParticle = samochod;
        }
    }
}
