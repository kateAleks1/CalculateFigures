using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab3
{

    [Serializable]
    class Point : Figure
    {
        private int x;
        private int y;
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
        public Point(int x = 0, int y = 0, SerializationInfo info = null, StreamingContext context = default) : base(info, context)
        {
            X = x;
            Y = y;
        }
        private void clearFig(Graphics graph)
        {
            SolidBrush brushWhite = new SolidBrush(Color.White);
            graph.FillEllipse(brushWhite, X, Y, 10 * _scale, 10 * _scale);
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
        }
        public override double GetArea()
        {
            return 1;
        }
        public override double GetPerimetr()
        {
            return 1;
        }
        public override string GetInfo()
        {
            return $"Клас {GetType().Name}, Периметр: 1, Площа: 1, Координати x:{X} y:{Y}, Збільшення:{_scale} ; \n";
        }
        public override void ScaleFromCenter(double scaleFactor, int centerX, int centerY)
        {
           
            double deltaX = X - centerX;
            double deltaY = Y - centerY;

           
            X = (int)(centerX + deltaX * scaleFactor);
            Y = (int)(centerY + deltaY * scaleFactor);

           
        }
        public override void Draw(Graphics graph, int x, int y)
        {
            clearFig(graph);
            X = x;
            Y = y;
            SolidBrush brush = new SolidBrush(Color.Black);
            graph.FillEllipse(brush, x, y, 10 * _scale, 10 * _scale);
        }
        public override void Draw(Graphics graph)
        {
            clearFig(graph);
            SolidBrush brush = new SolidBrush(Color.Black);
            graph.FillEllipse(brush, x, y, 10 * _scale, 10 * _scale);
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
           
            info.AddValue("X", X);
            info.AddValue("Y", Y);
        }

       
        protected Point(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            
            X = info.GetInt32("X");
            Y = info.GetInt32("Y");
        }
    }
}
