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
        int smth=14400;
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("DNA");
            comboBox1.Items.Add("Function1");
            comboBox1.Items.Add("Function2");
            comboBox1.Items.Add("Function3");
            comboBox1.Items.Add("Function4");
            comboBox1.Items.Add("Function5");
            comboBox1.Items.Add("Function6");
            a0 = new Vector3d[smth*3];
            timer1.Interval = 1;
            timer1.Enabled = true;
            GL.ClearColor(Color.FromArgb(0, 0, 0));
            GL.Clear(ClearBufferMask.ColorBufferBit);
            xyz = new Vector3d[6];
            coord_os();
        }
        Vector3d[] xyz;//координатные оси
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.Text=="DNA")
            {
                draw_DNA();
            }
            //if(comboBox1.Text=="Spiral")
            //{//трехмерная спираль

            //}
            else if(comboBox1.SelectedIndex==6)
            {
                draw_Sphere();
            }
            else
            {
                draw_F1();
            }
        }

        void draw_DNA()
        {
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Begin(PrimitiveType.Lines);
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
            A = trackBar4.Value * 0.01;//Амплитуда
            r = trackBar5.Value;//Частота
            GL.Begin(PrimitiveType.Points);
            int koef = 0, num = trackBar6.Value;
            for (int j = 0; j < num; j++)
            {
                for (int i = 0; i < smth; i++)
                {
                    a0[i].X = (i-3600) * 0.001;
                    a0[i].Y = A * Math.Cos(a0[i].X * r + (koef * Math.PI) / 180);
                    a0[i].Z = A * Math.Sin(a0[i].X * r + (koef * Math.PI) / 180);
                    GL.Color3(Color.White);
                    GL.Vertex3(a0[i]);
                }
                koef += 360 / num;
            }
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.DarkOrange);
            int w = 0;
            /*
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
            }*/
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

        void draw_F1()
        {
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //GL.Begin(PrimitiveType.Lines);
            //GL.Color3(Color.Red);//ox
            //GL.Vertex3(xyz[0]);
            //GL.Vertex3(xyz[1]);
            //GL.Color3(Color.Blue);//oy
            //GL.Vertex3(xyz[2]);
            //GL.Vertex3(xyz[3]);
            //GL.Color3(Color.Green);//oz
            //GL.Vertex3(xyz[4]);
            //GL.Vertex3(xyz[5]);
            //GL.End();
            double r = 0.4, A = 5;
            A = trackBar4.Value * 0.00001;//Амплитуда
            r = trackBar5.Value * 0.001;//Частота
            //GL.Begin(PrimitiveType.Lines);
            GL.Begin(PrimitiveType.Points);
            //int koef = 0, num = trackBar6.Value;
            //for (int j = 0; j < num; j++)
            //{
            a0[0].X = 0;
            a0[0].Y = 0;
            a0[0].Z = 0;
            if (comboBox1.SelectedIndex == 1)
                for (int i = 1; i < smth; i++)
                {
                    GL.Vertex3(a0[i - 1]);
                    //v1:
                    a0[i].X = A * i * Math.Sin(r * i * Math.PI / 180);
                    a0[i].Y = A * i * Math.Cos(Math.Sin(r * i * Math.PI / 180) * i * Math.PI / 180);
                    a0[i].Z = A * i * Math.Sin(r * Math.Sqrt(i) * Math.PI / 180);
                    GL.Color3(Color.White);
                    //GL.Vertex3(a0[i]);
                }
            else if (comboBox1.SelectedIndex == 2)
                for (int i = 1; i < smth; i++)
                {
                    GL.Vertex3(a0[i - 1]);
                    //v2:
                    a0[i].X = A * i * Math.Cos(r * i * Math.PI / 180);
                    a0[i].Y = A * i * Math.Atan(r * i * Math.PI / 180 + (Math.PI / 2));
                    a0[i].Z = A * i * Math.Sin(r * i * Math.PI / 180 + (i * Math.PI / 360));
                    GL.Color3(Color.White);
                    //GL.Vertex3(a0[i]);
                }
            else if (comboBox1.SelectedIndex == 3)
                for (int i = 1; i < smth; i++)
                {
                    GL.Vertex3(a0[i - 1]);
                    //v3:
                    a0[i].X = A * i * Math.Sin(r * i * Math.PI / 180);
                    a0[i].Y = A * i * Math.Atan(r * i * Math.PI / 180) * Math.Sin(r * i * Math.PI / 180 + (i * Math.PI / 360));
                    a0[i].Z = A * i * Math.Cos(r * i * Math.PI / 180);
                    GL.Color3(Color.White);
                    //GL.Vertex3(a0[i]);
                }
            else if (comboBox1.SelectedIndex == 4)
                for (int i = 1; i < smth; i++)
                {
                    GL.Vertex3(a0[i - 1]);
                    //v4:
                    a0[i].X = A * i * Math.Cos(i * r * Math.PI / 180) / Math.Log(i, smth);
                    a0[i].Y = A * i * Math.Sin(i * r * Math.PI / 180);
                    a0[i].Z = A * i * Math.Sin(i * Math.PI / 180);
                    GL.Color3(Color.White);
                    //GL.Vertex3(a0[i]);
                }
            else if (comboBox1.SelectedIndex == 5)
                for (int i = 1; i < smth; i++)
                {
                    GL.Vertex3(a0[i - 1]);
                    //v5:
                    a0[i].X = A * i *Math.Sin(r * i * Math.PI / 180);
                    a0[i].Y = A * i * Math.Cos(Math.Log(i, 2)*r * Math.PI / 180) ;
                    a0[i].Z = A * i *Math.Log(Math.Cos(r * i * Math.PI / 180), Math.Sqrt(i));
                    GL.Color3(Color.White);
                    //GL.Vertex3(a0[i]);
                }
            
            //koef += 360 / num;
            //}
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.DarkOrange);
            int w = 0;
            GL.End();
            GL.Begin(PrimitiveType.Patches);
            GL.Color3(Color.White);
            if (trackBar1.Value != 0 || trackBar2.Value != 0 || trackBar3.Value != 0)
            {
                GL.Rotate(0.4, trackBar1.Value, trackBar2.Value, trackBar3.Value);
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

        void draw_Sphere()
        {
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            double r = 0.4, A = 5;
            A = trackBar4.Value * 0.00001;//Амплитуда
            r = trackBar5.Value * 0.001;//Частота
            //GL.Begin(PrimitiveType.Lines);
            GL.Begin(PrimitiveType.Points);
            //int koef = 0, num = trackBar6.Value;
            //for (int j = 0; j < num; j++)
            //{
            a0[0].X = 0;
            a0[0].Y = 0;
            a0[0].Z = 0;
            for (int i = 0; i <= smth / 2; i++)
            {
                for (int j = 0; j < smth; j++)
                {
                    GL.Vertex3(a0[i + j]);
                    //v5:
                    a0[i + j].X = A * 2000 * Math.Sin(i * Math.PI / 180) * Math.Cos(j * Math.PI / 180);
                    a0[i + j].Y = A * 2000 * Math.Sin(i * Math.PI / 180) * Math.Sin(j * Math.PI / 180);
                    a0[i + j].Z = A * 2000 * Math.Cos(i * Math.PI / 180);
                    GL.Color3(Color.White);
                    //GL.Vertex3(a0[i]);
                }
            }
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.DarkOrange);
            int w = 0;
            GL.End();
            GL.Begin(PrimitiveType.Patches);
            GL.Color3(Color.White);
            if (trackBar1.Value != 0 || trackBar2.Value != 0 || trackBar3.Value != 0)
            {
                GL.Rotate(0.4, trackBar1.Value, trackBar2.Value, trackBar3.Value);
            }
            GL.End();
            GL.Flush();
            glControl1.SwapBuffers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            smth = 28800;
            a0 = new Vector3d[smth];
            if (comboBox1.SelectedIndex == 0)
            {

                label1.Visible = true;
                trackBar6.Visible = true;
                trackBar6.Enabled = true;
            }
            else
            {
                label1.Visible = false;
                trackBar6.Visible = false;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                smth = 360;
                a0 = new Vector3d[smth * 2];
            }
        }

        private void TrackBar6_Scroll(object sender, EventArgs e)
        {
            label1.Text=trackBar6.Value.ToString();
        }

        private void TrackBar5_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar5.Value.ToString();
        }

        private void TrackBar4_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar4.Value.ToString();
        }
    }
}
