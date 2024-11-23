using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace lab3
{
    [Serializable]
    class CircleFill : Figure
    {
        private int x;
        private int y;
        private int radius = 20;
        private int _scale = 1;

        public new  int X
        {
            get { return x; }
            set { x = value; }
        }
        public new  int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }
    
        public CircleFill(int radius = 20, SerializationInfo info = null, StreamingContext context = default) : base(info, context)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        private void clearFig(Graphics graph)
        {
            SolidBrush brushWhite = new SolidBrush(Color.White);
            graph.FillEllipse(brushWhite, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        }

        public override void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override void MoveTo(int r, string direction)
        {
            if (direction == "top")
            {
                Y -= r;
            }
            if (direction == "bottom")
            {
                Y += r;
            }
            if (direction == "left")
            {
                X -= r;
            }
            if (direction == "right")
            {
                X += r;
            }
        }

      
        public override void Scalable(double scale)
        {
            if (scale < 0)
            {
                Radius = (int)(Radius/ scale);
            
            }
            else
            {
                Radius = (int)(Radius  * scale);
                
            }
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimetr()
        {
            return 2 * Math.PI * Radius;
        }

        public override string GetInfo()
        {
            return $"Circle, Perimeter: {GetPerimetr()}, Area: {GetArea()}, Coordinates x:{X} y:{Y}, Scale:{_scale}";
        }

        public override void Draw(Graphics graph, int x, int y)
        {
            this.X = x;
            this.Y = y;
            Draw(graph);
        }
        public override void ScaleFromCenter(double scaleFactor, int centerX, int centerY)
        {
            
            double deltaX = X - centerX;
            double deltaY = Y - centerY;

            
            X = (int)(centerX + deltaX * scaleFactor);
            Y = (int)(centerY + deltaY * scaleFactor);

          
            Radius = (int)(Radius * scaleFactor);
        }
        public override void Draw(Graphics graph)
        {

            
            clearFig(graph);
            using (SolidBrush brush = new SolidBrush(Color.Black)) 
            {
                graph.FillEllipse(brush, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            }
        }
        public  string ToString(string p)
        {
            return $"{p}CircleFill:\n" +
                   $"{p}{p}  Location = ({X}, {Y})\n" +
                   $"{p}{p}  Radius = {Radius}\n" +
                   $"{p}{p}  Area = {GetArea()}\n" +
                   $"{p}{p}  Perimeter = {GetPerimetr()}\n" +
                   $"{p}{p}  Scale = {_scale}\n";
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Radius", Radius);
        }

        protected CircleFill(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            X = info.GetInt32("X");
            Y = info.GetInt32("Y");
            Radius = info.GetInt32("Radius");
        }
    }
}
