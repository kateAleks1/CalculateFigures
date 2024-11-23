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
   
    class FlatCone : Figure
    {
        private int x;
        private int y;
        private int radius;
        private int height;
protected int initialX;
protected int initialY;
        public FlatCone(int x = 0, int y = 0, int radius = 20, int height = 30,SerializationInfo info = null, StreamingContext context = default) : base(info, context)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.height = height;
                this.initialX = x;
    this.initialY = y;
        }
        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public new int X
{
    get { return x; }
    set { x = value; }
}public new int Y
{
    get { return y; }
    set { y = value; }
}



        public override void MoveTo(int rX, int rY)
        {
            X += rX;  
            Y += rY;  
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
                
                radius = (int)(radius / Math.Abs(scale));
                height = (int)(height / Math.Abs(scale));
            }
            else
            {
                
                radius = (int)(radius * scale);
                height = (int)(height * scale);
            }
        }

        public override double GetArea()
        {
            double slantHeight = Math.Sqrt(radius * radius + height * height);
            double baseArea = Math.PI * radius * radius; 
            double lateralArea = Math.PI * radius * slantHeight; 

            return baseArea + lateralArea;
        }

        public override double GetPerimetr()
        {
            double slantHeight = Math.Sqrt(radius * radius + height * height);
            double diameter = 2 * radius;

            return 2 * Math.PI * radius + Math.PI * diameter;
        }

        public override string GetInfo()
        {
            return $"Flat Cone, Perimeter: {GetPerimetr()}, Coordinates x:{x} y:{y}, Radius: {radius}, Height: {height}";
        }
      
        public override void Draw(Graphics graph, int x, int y)
        {
            throw new NotImplementedException();
        }
        public override void ScaleFromCenter(double scaleFactor, int centerX, int centerY)
        {
           
            double deltaX = X - centerX;
            double deltaY = Y - centerY;

            
            X = (int)(centerX + deltaX * scaleFactor);
            Y = (int)(centerY + deltaY * scaleFactor);

         
        
            radius = (int)(radius * scaleFactor);

           
            height = (int)(height * scaleFactor);
        }
        public override void Draw(Graphics graph)
        {
            Pen pen = new Pen(Color.Black);

            Elipse baseEllipse = new Elipse(x, y, 2 * radius, height / 2);
            baseEllipse.Draw(graph);

            int topX = x;
            int topY = y - height - baseEllipse.GetHorizontalRadius();

            graph.DrawLine(pen, x - radius, y, topX, topY);
            graph.DrawLine(pen, x + radius, y, topX, topY);
        }
        public  string ToString(string p)
        {
            return $"{p}FlatCone:\n" +
                   $"{p}{p}  Location = ({X}, {Y})\n" +
                   $"{p}{p}  Radius = {Radius}\n" +
                   $"{p}{p}  Height = {Height}\n" +
                   $"{p}{p}  Area = {GetArea()}\n" +
                   $"{p}{p}  Perimeter = {GetPerimetr()}\n";
        }
      
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Radius", radius);
            info.AddValue("Height", height);
        }

        protected FlatCone(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            X = info.GetInt32("X");
            Y = info.GetInt32("Y");
            radius = info.GetInt32("Radius"); // Access member variable directly
            height = info.GetInt32("Height");
        }

    }
}