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
    class Elipse : Figure
    {
        private int x;
        private int y;
        private int width = 30;  
        private int height = 10; 
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




        public Elipse(int x = 0, int y = 0, int width = 30, int height = 10,SerializationInfo info = null, StreamingContext context = default):base(info, context)
        {
            X = x;
            Y = y;
            this.width = width;  
            this.height = height;
        }

        private void clearFig(Graphics graph)
        {
            SolidBrush brushWhite = new SolidBrush(Color.White);
            graph.FillEllipse(brushWhite, X - Width / 2, Y - Height / 2, Width, Height);
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
            _scale = (int)scale;
            Width =(int)(Width* scale);
            Height = (int)(Height * scale);
        }
        public override void ScaleFromCenter(double scaleFactor, int centerX, int centerY)
        {
            
            double deltaX = X - centerX;
            double deltaY = Y - centerY;


            X = (int)(centerX + deltaX * scaleFactor);
            Y = (int)(centerY + deltaY * scaleFactor);

       
            Width = (int)(Width * scaleFactor);
            Height = (int)(Height * scaleFactor);
            _scale = (int)scaleFactor;
        }
        public override double GetArea()
        {
            return Math.PI * Width * Height / 4;
        }
        
        public override double GetPerimetr()
        {
            return Math.PI * (3 * (Width + Height) - Math.Sqrt((3 * Width + Height) * (Width + 3 * Height)));
        }

        public override string GetInfo()
        {
            return $"Ellipse, Perimeter: {GetPerimetr()}, Area: {GetArea()}, Coordinates x:{X} y:{Y}, Scale:{_scale}";
        }
        public int GetHorizontalRadius()
        {
            return width / 2;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Width", Width);
            info.AddValue("Height", Height);
        }

        protected Elipse(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            X = info.GetInt32("X");
            Y = info.GetInt32("Y");
            Width = info.GetInt32("Width");
            Height = info.GetInt32("Height");
        }
        public override void Draw(Graphics graph)
{
    Pen pen = new Pen(Color.Black);
    graph.DrawEllipse(pen, X - this.width / 2, Y - this.height / 2, this.width, this.height);
}

public override void Draw(Graphics graph, int offsetX, int offsetY)
{
    Pen pen = new Pen(Color.Black);
    graph.DrawEllipse(pen, X - this.width / 2 + offsetX, Y - this.height / 2 + offsetY, this.width, this.height);
}
    }
}