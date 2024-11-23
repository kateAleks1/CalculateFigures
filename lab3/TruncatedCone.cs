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
    class TruncatedCone : Figure
    {
        private int topRadius;
        private int coneRadius;
        private int coneHeight;
        private int x;
        private int y;
        public TruncatedCone(int x = 0, int y = 0, int radius = 20, int height = 30, int topRadius = 10)
            : base(x, y, radius, height)  
        {
            this.topRadius = topRadius;
            this.coneRadius = radius;  
            this.coneHeight = height; 
        }

        public int TopRadius
        {
            get { return topRadius; }
            set { topRadius = value; }
        }
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

     
        public int ConeRadius
        {
            get { return coneRadius; }
            set { coneRadius = value; }
        }
        public override void Scalable(double scale)
        {
            if (scale > 0)
            {
                
                coneRadius = (int)(coneRadius * scale);
                coneHeight = (int)(coneHeight * scale);

               
                topRadius = (int)Math.Round((double)topRadius * scale / Math.Abs(scale));
            }
            else if (scale < 0)
            {
              
                coneRadius = (int)(coneRadius / Math.Abs(scale));
                coneHeight = (int)(coneHeight / Math.Abs(scale));
            
                topRadius = (int)Math.Round((double)topRadius / Math.Abs(scale));
            }
      
        }
        public int ConeHeight
        {
            get { return coneHeight; }
            set { coneHeight = value; }
        }

        public override double GetPerimetr()
        {
            double slantHeight = Math.Sqrt(Math.Pow((coneRadius - topRadius), 2) + Math.Pow(coneHeight, 2));
            return Math.PI * (coneRadius + topRadius) + slantHeight;
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
    else if (direction == "bottom")
    {
        Y += r; 
    }
    else if (direction == "left")
    {
        X -= r;  
    }
    else if (direction == "right")
    {
        X += r;  
    }
}
        public override string GetInfo()
        {
            return $"Truncated Cone, Perimeter: {GetPerimetr()}, Coordinates x:{X} y:{Y}, Bottom Radius: {coneRadius}, Top Radius: {topRadius}, Height: {coneHeight}";
        }
        public override void ScaleFromCenter(double scaleFactor, int centerX, int centerY)
        {
            
            double deltaX = X - centerX;
            double deltaY = Y - centerY;

            
            X = (int)(centerX + deltaX * scaleFactor);
            Y = (int)(centerY + deltaY * scaleFactor);

           
            
         
            coneRadius = (int)(coneRadius * scaleFactor);
            topRadius = (int)Math.Round((double)topRadius * scaleFactor / Math.Abs(scaleFactor));
            coneHeight = (int)(coneHeight * scaleFactor);
        
           
        }
        public override double GetArea()
        {
 
            double slantHeight = Math.Sqrt(Math.Pow((coneRadius - topRadius), 2) + Math.Pow(coneHeight, 2));
            return Math.PI * (coneRadius + topRadius) * slantHeight + Math.PI * (coneRadius * coneRadius + topRadius * topRadius);
        }
        
        public override void Draw(Graphics graph, int x, int y)
        {
            
            Draw(graph);
        }
        public override void Draw(Graphics graph)
        {
            Pen pen = new Pen(Color.Black);

            Elipse baseEllipse = new Elipse(X, Y, 2 * coneRadius, coneHeight / 2);
Elipse topEllipse = new Elipse(X, Y - coneHeight, 2 * topRadius, coneHeight/4);

            baseEllipse.Draw(graph);
               topEllipse.Draw(graph);

            int baseTopX = X;
            int baseTopY = Y - coneHeight;
            int topTopX = X;
            int topTopY = Y - 2 * coneHeight;
         
            graph.DrawLine(pen, X - coneRadius, Y, baseTopX - topRadius, baseTopY);  
            graph.DrawLine(pen, X + coneRadius, Y, baseTopX+ topRadius, baseTopY);  


        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {



            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("TopRadius", topRadius);
            info.AddValue("ConeRadius", coneRadius);
            info.AddValue("ConeHeight", coneHeight);
        }

     
        protected TruncatedCone(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            X = info.GetInt32("X");
            Y = info.GetInt32("Y");
            topRadius = info.GetInt32("TopRadius");
            coneRadius = info.GetInt32("ConeRadius");
            coneHeight = info.GetInt32("ConeHeight");
        }

    }
}
