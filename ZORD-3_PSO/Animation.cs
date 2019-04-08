using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZORD_3_PSO
{
    //done

    class AnimationPSO
    {
        Map mapa;
        Storyboard pathAnimationStoryboard = new Storyboard();

        public AnimationPSO(Map m)
        {
            mapa = m;


        }

      
        int X0(Image sender)
        {
            return (int)Canvas.GetLeft(sender);
        }

        int Y0(Image sender)
        {
            return (int)Canvas.GetTop(sender);
        }



        
         public  void Lataj(Particle Czastka, List<List<int>> animKoordynaty)
        {
            
            
            NameScope.SetNameScope(mapa.Mw, new NameScope());

           
            TranslateTransform animatedTranslateTransform =
                new TranslateTransform();

            
            mapa.Mw.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform);

            Czastka.ReturnImage().RenderTransform = animatedTranslateTransform;

           
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();


            pFigure.StartPoint = new Point(animKoordynaty[0][0] - X0(Czastka.ReturnImage()), animKoordynaty[0][1] - Y0(Czastka.ReturnImage()));
            List<LineSegment> odcinki = new List<LineSegment>();

            for (int i = 0; i < animKoordynaty.Count - 1; i++)
            {
                odcinki.Add(new LineSegment());
                odcinki[i].Point = new Point(animKoordynaty[i + 1][0] - X0(Czastka.ReturnImage()), animKoordynaty[i + 1][1] - Y0(Czastka.ReturnImage()));
                pFigure.Segments.Add(odcinki[i]);
            }
            


            animationPath.Figures.Add(pFigure);

           
            animationPath.Freeze();

           
            DoubleAnimationUsingPath translateXAnimation =
                new DoubleAnimationUsingPath();
            translateXAnimation.PathGeometry = animationPath;
            translateXAnimation.Duration = TimeSpan.FromSeconds(5);
            translateXAnimation.AccelerationRatio = Czastka.TimeAnimation;
           
            translateXAnimation.Source = PathAnimationSource.X;

            
            Storyboard.SetTargetName(translateXAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateXAnimation,
                new PropertyPath(TranslateTransform.XProperty));

           
            DoubleAnimationUsingPath translateYAnimation =
                new DoubleAnimationUsingPath();
            translateYAnimation.PathGeometry = animationPath;
            translateYAnimation.Duration = TimeSpan.FromSeconds(5);
            translateYAnimation.AccelerationRatio = Czastka.TimeAnimation;
            
            translateYAnimation.Source = PathAnimationSource.Y;

            
            Storyboard.SetTargetName(translateYAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateYAnimation,
                new PropertyPath(TranslateTransform.YProperty));

            
            
         

            pathAnimationStoryboard.Children.Add(translateXAnimation);
            pathAnimationStoryboard.Children.Add(translateYAnimation);

           
           
            {
               
                pathAnimationStoryboard.Begin(mapa.Mw);

            };

            
            
        }
    }
}
