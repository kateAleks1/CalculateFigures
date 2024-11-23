using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;

using System.Runtime.Serialization.Formatters.Binary;
namespace lab3
{
    [Serializable]
    abstract class Figure : ISerializable
    {
        public abstract void MoveTo(int x, int y);
        public abstract void MoveTo(int r, string direction);
        
        public abstract double GetArea();
        public abstract double GetPerimetr();
        public abstract string GetInfo();
             public int X { get; set; }
        public int Y { get; set; }
        public int InitialX { get; set; }
        public int InitialY { get; set; }
        public abstract void Draw(Graphics graph, int x, int y);
        public abstract void Draw(Graphics graph);
        public abstract void Scalable(double scale);
        public int Width { get; set; }
        public int Height { get; set; }
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
        protected Figure(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            InitialX = x;
            InitialY = y;
        }
        protected Figure(SerializationInfo info, StreamingContext context)
        {
        }
    
        public virtual void ScaleFromCenter(double scaleFactor, int centerX, int centerY)
        {
            
            double deltaX = X - centerX;
            double deltaY = Y - centerY;

            
            X = (int)(centerX + deltaX * scaleFactor);
            Y = (int)(centerY + deltaY * scaleFactor);
        }

    }
}
