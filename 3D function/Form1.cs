using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform.Windows;

namespace _3D_function
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Vector3d[] a0;
        Vector3d[] a1;
        Vector3d[] a2;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("DNA");
            comboBox1.Items.Add("");
            a0 = new Vector3d[7200];
            a1 = new Vector3d[7200];
            a2 = new Vector3d[7200];
            timer1.Interval = 1;
            timer1.Enabled = true;
            GL.ClearColor(Color.FromArgb(0, 0, 0));
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }
        Vector3d[] xyz;//координатные оси
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.Text=="DNA")
            {
                xyz = new Vector3d[6];
                GL.ClearColor(Color.Black);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.Begin(PrimitiveType.Lines);
                coord_os();
                GL.Color3(Color.Red);//ox
                GL.Vertex3(xyz[0]);
                GL.Vertex3(xyz[1]);
                GL.Color3(Color.Blue);//oy
                GL.Vertex3(xyz[2]);
                GL.Vertex3(xyz[3]);
                GL.Color3(Color.Green);//oz
                GL.Vertex3(xyz[4]);
                GL.Vertex3(xyz[5]);
                GL.End();
                double r = 0.4, A = 5;
                r = trackBar4.Value * 0.05;//Амплитуда
                A = trackBar5.Value;//Частота
                GL.Begin(PrimitiveType.Points);
                for (int i = -3600; i < 3600; i++)
                {
                    a0[i + 3600].X = i * 0.001;
                    a0[i + 3600].Y = r * Math.Cos(a0[i + 3600].X * A);
                    a0[i + 3600].Z = r * Math.Sin(a0[i + 3600].X * A);
                }
                //r = 0.4;
                //A=5;
                for (int i = -3600; i < 3600; i++)
                {
                    a1[i + 3600].X = i * 0.001;
                    a1[i + 3600].Y = r * Math.Cos(a1[i + 3600].X * A + 90);
                    a1[i + 3600].Z = r * Math.Sin(a1[i + 3600].X * A + 90);//... + 90) - здвиг на фазу
                }
                //r = 0.4;
                //A = 5;
                for (int i = -3600; i < 3600; i++)
                {
                    a2[i + 3600].X = i * 0.001;
                    a2[i + 3600].Y = r * Math.Cos(a2[i + 3600].X * A + 180);
                    a2[i + 3600].Z = r * Math.Sin(a2[i + 3600].X * A + 180);
                }
                GL.Color3(Color.White);
                for (int i = 0; i < 7200; i++)
                {
                    GL.Color3(Color.White);
                    GL.Vertex3(a0[i]);
                    GL.Color3(Color.White);
                    GL.Vertex3(a1[i]);
                    GL.Color3(Color.White);
                    GL.Vertex3(a2[i]);
                }
                GL.End();
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.DarkOrange);
                int w = 0;
                for (int i = 0; i < 7200; i += 100)
                {
                    w++;
                    if (w == 10)
                    {
                        GL.Color3(Color.Yellow);
                        w = 0;
                    }
                    else
                        GL.Color3(Color.DodgerBlue);
                    GL.Vertex3(a0[i]);
                    GL.Vertex3(a1[i]);
                    GL.Vertex3(a0[i]);
                    GL.Vertex3(a2[i]);
                    GL.Vertex3(a1[i]);
                    GL.Vertex3(a2[i]);
                    GL.Vertex3(a0[i]);
                }
                GL.End();
                GL.Begin(PrimitiveType.Patches);
                GL.Color3(Color.White);
                if (!(trackBar1.Value == 0 && trackBar2.Value == 0 && trackBar3.Value == 0))
                {
                    GL.Rotate(1, trackBar1.Value, trackBar2.Value, trackBar3.Value);
                }
                //GL.Rotate(1, R.NextDouble(), R.NextDouble(), R.NextDouble());
                GL.End();
                GL.Flush();
                glControl1.SwapBuffers();

                //speed--;
                //GL.ClearColor(Color.FromArgb(0, 0, 0));
                //GL.Clear(ClearBufferMask.ColorBufferBit);
                //GL.Begin(PrimitiveType.Lines);
                ////fractal4
                //GL.End();
                //GL.Begin(PrimitiveType.Patches);
                //GL.Rotate(speed/100,(y_down - y_up), (x_down - x_up),0 );
                //GL.End();
                //glControl1.SwapBuffers();
                //if (speed <= 0)
                //{
                //    timer1.Enabled = false;
                //}
            }
            if(comboBox1.Text=="")
            {

            }
        }

        void coord_os()
        {
            xyz[0].X = 1;
            xyz[0].Y = 0;
            xyz[0].Z = 0;
            xyz[1].X = -1;
            xyz[1].Y = 0;
            xyz[1].Z = 0;
            xyz[2].X = 0;
            xyz[2].Y = 1;
            xyz[2].Z = 0;
            xyz[3].X = 0;
            xyz[3].Y = -1;
            xyz[3].Z = 0;
            xyz[4].X = 0;
            xyz[4].Y = 0;
            xyz[4].Z = 1;
            xyz[5].X = 0;
            xyz[5].Y = 0;
            xyz[5].Z = -1;
        }
    }
}
