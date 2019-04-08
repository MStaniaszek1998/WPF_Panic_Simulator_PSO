using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ZORD_3_PSO
{
    //done

    abstract class Particle
    {
        protected double timeAnimation;
        
        Pooint current;
        Pooint historyBest;
        Pooint velocity;
        double fitness;
        List<Pooint> historyPositons;

        protected Image ZdjecieParticle;
        protected int startX = 0;
        protected int startY = 0;

        public List<Pooint> HistoryPositons
        {
            get { return historyPositons; }
            set { historyPositons = value; }
        }
        public Pooint HistoryBest
        {
            get { return historyBest; }
            set { historyBest = value; }
        }
        public Pooint Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public Pooint Current
        {
            get { return current; }
            set { current = value; }
        }
        public virtual double TimeAnimation
        {
            get { return timeAnimation; }
            
        }
        public double Fitness { get { return fitness; } set { fitness = value; } }
        public Particle(Pooint position)
        {
            fitness = 0;
            Current = position;
            HistoryPositons = new List<Pooint>();
            HistoryBest = position;
            Velocity = new Pooint(GetRandomNum.GetIntNumber(0,50), GetRandomNum.GetIntNumber(0,50));
        }

        protected virtual Image SetImage(Photos foto)
        {

            BitmapImage picParticle = new BitmapImage(new Uri(@"pack://application:,,,/Obrazki/" + foto.ToString() + ".png"));

            Image imgParticle = new Image
            {
                Source = picParticle,
                Name = "picParticle"
            };
            Canvas.SetTop(imgParticle, startX);
            Canvas.SetLeft(imgParticle, startY);
            return imgParticle;
        }
        protected abstract void GetImage();
        public abstract Image ReturnImage();

        
    }
}
