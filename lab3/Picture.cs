    using System.Collections.Generic;
    using System.Drawing;
    using System;
    using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;
    namespace lab3
    {
    [Serializable]
    class Picture
        {
            private int width;
            private int height;
        private int initialWidth;
     
        private int initialHeight;
        private List<Figure> figures;
        private Dictionary<Figure, Point> initialPositions;
        public int Width
            {
                get { return width; }
                set { width = value; }
            }
        
        public int InitialWidth
        {
            get { return initialWidth; }
            set { initialWidth = value; }
        }
        public int InitialHeight
        {
            get { return initialHeight; }
            set { initialHeight = value; }
        }
        public void SaveInitialCanvasSize(int width, int height)
        {
            InitialWidth = width;
            InitialHeight = height;
        }


        public void SaveInitialPositions()
        {
            initialPositions = new Dictionary<Figure, Point>();
            foreach (var fig in Figures)
            {
                initialPositions[fig] = new Point(fig.X, fig.Y);
            }
        }

        public void RestoreInitialPositions()
        {
            foreach (var pair in initialPositions)
            {
                Figure fig = pair.Key;
                Point initialPosition = pair.Value;
                fig.MoveTo(initialPosition.X, initialPosition.Y);
            }
        }

        public int Height
            {
                get { return height; }
                set { height = value; }
            }

            public List<Figure> Figures
            {
                get { return figures; }
                set { figures = value; }
            }


        public void Merge(Picture other)
        {
            foreach (Figure figure in other.Figures)
            {
                Add(figure);
            }
        }
        public Picture(List<Figure> figs)
            {
              
                Figures = figs;
            initialPositions = new Dictionary<Figure, Point>();
        }

            public Picture()
            {
                Figures = new List<Figure>();
                this.Height = 420;
                this.Width = 700;
           
            initialPositions = new Dictionary<Figure, Point>();
            }

            public void Add(Figure fig)
            {
                figures.Add(fig);
            initialPositions[fig] = new Point(fig.X, fig.Y);
         
            fig.InitialX = fig.X;
            fig.InitialY = fig.Y;
        }
    

        public void Remove(Figure fig)
            {
                figures.Remove(fig);
            }

            public double summaryArea()
            {
                double sum = 0;
                foreach (Figure fig in figures)
                {
                    sum += fig.GetArea();
                }
                return sum;
            }

            public double summaryPerimetr()
            {
                double sum = 0;
                foreach (Figure fig in figures)
                {
                    sum += fig.GetPerimetr();
                }
                return sum;
            }

            public void allMoveTo(int r, string direction)
            {
                foreach (Figure fig in figures)
                {
                    fig.MoveTo(r, direction);
                }
            }
        //public void Close(double scaleFactor)
        //{

        //    foreach (Figure fig in Figures)
        //    {
        //        fig.Scalable(scaleFactor);
        //    }
        //    Width = (int)(Width * scaleFactor);
        //    Height = (int)(Height * scaleFactor);
        //}
        public void Close(double scaleFactor)
        {
         
            int centerX = Width / 2;
            int centerY = Height / 2;

           
            foreach (Figure fig in Figures)
            {
                fig.ScaleFromCenter(scaleFactor, centerX, centerY);
            }
  
        
            Width = (int)(Width * scaleFactor);
            Height = (int)(Height * scaleFactor);

        }
        public void SaveToFile(string path)
        {
           

            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static Picture LoadFromFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            Picture picture = (Picture)formatter.Deserialize(stream);

            stream.Close();
            return picture;
        }
        public void Scale(double scaleFactor)
        {
           
            int centerX = Width / 2;
            int centerY = Height / 2;

          
            foreach (Figure fig in Figures)
            {
                fig.ScaleFromCenter(scaleFactor, centerX, centerY);
            }

       
            Width = (int)(Width * scaleFactor);
            Height = (int)(Height * scaleFactor);
        }
        public List<Figure> GetFigures()
        {
            return figures; 
        }
      
        public void allDraw(Graphics grah)
            {
          

            foreach (Figure fig in Figures)
                {
                    fig.Draw(grah);
                }

           
            }

            //public void Scale(double scaleFactor)
            //{
            //    Width = (int)(Width * scaleFactor);
            //    Height = (int)(Height * scaleFactor);
            //}
       
        }
    }
