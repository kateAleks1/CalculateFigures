using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
namespace lab3
{
    [Serializable]
    public partial class Form1 : Form
    {
       
        private Picture picture;
        public Graphics canvasGraphics;
        private int initialPictureBoxWidth;
        private int initialPictureBoxHeight;
        public Form1()
        {
            InitializeComponent();
            picture = new Picture();
            Init();
        }

        public void Init()
        {
            initialPictureBoxWidth = pictureBox.Width;
            initialPictureBoxHeight = pictureBox.Height;
            Bitmap bmp = new Bitmap(initialPictureBoxWidth, initialPictureBoxHeight);
            Graphics graph = Graphics.FromImage(bmp);
            pictureBox.Image = bmp;

            /*Point*/
            Point point = new Point();

            textBox.Text = point.GetInfo() + Environment.NewLine;
            point.MoveTo(90, 350);
            point.Draw(graph);
            textBox.Text += point.GetInfo() + "draw" + Environment.NewLine;

            Circle circle = new Circle();

            circle.MoveTo(0, 280);
            circle.Draw(graph);
            textBox.Text += circle.GetInfo() + "draw" + Environment.NewLine;


            CircleFill circleFill = new CircleFill(15);

            circleFill.MoveTo(80, 320);
            circleFill.Draw(graph);
            textBox.Text += circleFill.GetInfo() + "draw" + Environment.NewLine;


            /*  int xCoord = conus.X;
               int yCoord = conus.Y;
               textBox.Text += xCoord+ "COORDINATES" + yCoord+ "COORDINATESy";*/
            FlatCone conus = new FlatCone();
            conus.MoveTo(110, 320);
            conus.GetArea();
            conus.Scalable(2);
            textBox.Text += conus.GetInfo() + "draw" + Environment.NewLine;

            graph.Clear(Color.White);
            TruncatedCone truncatedCone = new TruncatedCone();

            truncatedCone.MoveTo(80, 70);
 
            textBox.Text += truncatedCone.GetInfo() + "draw" + Environment.NewLine;
            Elipse elipse = new Elipse();
            elipse.MoveTo(100, 80);



            graph.Clear(Color.White);
 Picture picture2=new Picture();
            picture = new Picture();
      
           

        }



        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            SaveFileDialog saveFileDialog = new SaveFileDialog();

           
            saveFileDialog.Filter = "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Save Image File";

          
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
             
                string filePath = saveFileDialog.FileName;

               
                picture.SaveToFile(filePath); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Open Image File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

               
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        picture = (Picture)formatter.Deserialize(fs);
                   
                    }

                    picture.Figures[2].MoveTo(120,0);
                    DrawPicture();
                }
                catch (Exception ex)
                {
                  
                    MessageBox.Show("Error loading file: " + ex.Message);
                }
            }
        }

        private void DrawPicture()
        {

            initialPictureBoxWidth = pictureBox.Width;
            initialPictureBoxHeight = pictureBox.Height;
            Bitmap bmp = new Bitmap(initialPictureBoxWidth, initialPictureBoxHeight);
            Graphics graph = Graphics.FromImage(bmp);
            pictureBox.Image = bmp;
            picture.allDraw(graph);

            textBox.Text = "";
        }


        private void ScaleSmaller_Click(object sender, EventArgs e)
        {
         
        }
        private void DrawFigures()
        {
            initialPictureBoxWidth = pictureBox.Width;
            initialPictureBoxHeight = pictureBox.Height;
            Bitmap bmp = new Bitmap(initialPictureBoxWidth, initialPictureBoxHeight);
            Graphics graph = Graphics.FromImage(bmp);
            pictureBox.Image = bmp;

          
            graph.Clear(Color.White);

          
            picture.allDraw(graph);

        }
    }


}



        
    

