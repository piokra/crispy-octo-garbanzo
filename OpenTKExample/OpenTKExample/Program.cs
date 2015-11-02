using OpenTK;
using OpenTK.Graphics.OpenGL;
//using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTKExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {
                    // setup settings, load textures, sounds
                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };

                game.UpdateFrame += (sender, e) =>
                {
                    // add game logic, input handling
                    if (game.Keyboard[Key.Escape])
                    {
                        game.Exit();
                    }
                };
                double rotation = 0;
                game.RenderFrame += (sender, e) =>
                {
                    rotation += 1;
                    rotation %= 360;
                    // render graphics
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
                    GL.Rotate(rotation, 0, 0, 1);
                    GL.Begin(PrimitiveType.Triangles);
                    
                    GL.Color3(Color.MidnightBlue);
                    GL.Vertex3(-1.0f, 1.0f,-1.0f);
                    GL.Color3(Color.SpringGreen);
                    GL.Vertex3(0.0f, -1.0f,-1.0f);
                    GL.Color3(Color.Ivory);
                    GL.Vertex3(1.0f, 1.0f,-1.0f);

                    GL.End();

                    game.SwapBuffers();
                };

                // Run the game at 60 updates per second
                game.Run(60.0);
            }
        }

    }
}
