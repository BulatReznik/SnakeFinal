using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph;

namespace SnakeFinal
{
    public partial class Form1 : Form
    {
        SharpGL.OpenGL GL;
        public Form1()
        {
            InitializeComponent();
            GL = openglControl1.OpenGL;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            openglControl1.Width = this.Width - 30;
            openglControl1.Height = this.Height - 100;
            //задаем матрицу
            GL.MatrixMode(OpenGL.GL_PROJECTION);
            //загружаем матрицу в стек
            GL.LoadIdentity();
            //Устанавливаем матрицы в стек
            GL.LoadIdentity();
            //Устанавливаем параметры матрицы
            GL.Perspective(80, 4 / 3, 0.1, 200);
            GL.LookAt(15, 5, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(OpenGL.GL_MODELVIEW);
            GL.LoadIdentity();
            //устанавливаем цвет фона
            GL.Clear(OpenGL.GL_COLOR_BUFFER_BIT |
                OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        private int x = -50; // начальная позиция змеи
        private int y = 0;
        private int a = -50;
        
        private void openglControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            GL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

           
            
            DrawText("GAME OVER!", 600, 500, Color.Red);
            // установка цвета змеи
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.SteelBlue);
            }
            DrawSnakeBlock(x - 1, y, 10);
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.Gray);
            }
            DrawSnakeBlock(x - 2, y, 10);
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.SteelBlue);
            }
            DrawSnakeBlock(x - 3, y, 10);
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.Gray);
            }
            DrawSnakeBlock(x - 4, y, 10);
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.SteelBlue);
            }
            DrawSnakeBlock(x - 5, y, 10);
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.Gray);
            }
            DrawSnakeBlock(x - 6, y, 10);
            if (a >=10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.SteelBlue);
            }
            DrawSnakeBlock(x - 7, y, 10);
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.Gray);
            }
            DrawSnakeBlock(x - 8, y, 10);
            if (a >= 10)
            {
                GL.Color(Color.Red);
            }
            else
            {
                GL.Color(Color.SteelBlue);
            }
            DrawSnakeBlock(x - 9, y, 10);


            GL.Color(Color.Gold);
            DrawSnakeBlock(5, y, a);
            // обновляем позицию змеи
            x++;
            a++;
            if (x > 25)
            {
                x = -50;
                a = -50;
            }
            
            GL.End();

           

        }
        int z = 15;

        private void DrawSnakeBlock(float x, float y, float z)
        {
            // размеры блока
            float size = 0.9f;

            // координаты блока
            float left = x - size / 2f;
            float right = x + size / 2f;
            float bottom = y - size / 2f;
            float top = y + size / 2f;
            float front = z - size / 2f;
            float back = z + size / 2f;

            // рисуем квадрат блока
            GL.Begin(OpenGL.GL_QUADS);
            GL.Vertex(left, bottom, front);
            GL.Vertex(right, bottom, front);
            GL.Vertex(right, top, front);
            GL.Vertex(left, top, front);
            GL.End();

            GL.Begin(OpenGL.GL_QUADS);
            GL.Vertex(left, bottom, back);
            GL.Vertex(right, bottom, back);
            GL.Vertex(right, top, back);
            GL.Vertex(left, top, back);
            GL.End();

            GL.Begin(OpenGL.GL_QUADS);
            GL.Vertex(left, bottom, front);
            GL.Vertex(left, top, front);
            GL.Vertex(left, top, back);
            GL.Vertex(left, bottom, back);
            GL.End();

            GL.Begin(OpenGL.GL_QUADS);
            GL.Vertex(right, bottom, front);
            GL.Vertex(right, top, front);
            GL.Vertex(right, top, back);
            GL.Vertex(right, bottom, back);
            GL.End();

            GL.Begin(OpenGL.GL_QUADS);
            GL.Vertex(left, bottom, front);
            GL.Vertex(right, bottom, front);
            GL.Vertex(right, bottom, back);
            GL.Vertex(left, bottom, back);
            GL.End();

            GL.Begin(OpenGL.GL_QUADS);
            GL.Vertex(left, top, front);
            GL.Vertex(right, top, front);
            GL.Vertex(right, top, back);
            GL.Vertex(left, top, back);
            GL.End();
        }

        private void DrawText(string text, int x, int y, Color color)
        {
            // Устанавливаем цвет текста
            GL.Color(color);

            // Рисуем текст
            GL.DrawText(x, y, 1, 1, 1, "Arial", 100f, text);

            // Возвращаемся к предыдущей позиции
            GL.PopMatrix();
        }


    }
}
