using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.ES20;
using System.IO;

namespace ShaderTest
{
    public class ESWindow
    {
        GameWindow mGameWindow = null;
        public ESWindow()
        {
            mGameWindow = new GameWindow(500,500);
            mGameWindow.RenderFrame += shaderExample;
            mGameWindow.Load += onLoad;
            mGameWindow.Resize += onResize;


            setUpProgram();
        }



        private int mProgram = 0;
        private int mVertexShader = 0;
        private int mFragShader = 0;

        private void setUpProgram()
        {
            mProgram = GL.CreateProgram();
            mVertexShader = GL.CreateShader(ShaderType.VertexShader);
            mFragShader = GL.CreateShader(ShaderType.FragmentShader);
            
            GL.ShaderSource(mVertexShader, File.ReadAllText("Shaders\\Vertex.vert"));
            GL.ShaderSource(mFragShader, File.ReadAllText("Shaders\\Fragment.frag"));

            GL.CompileShader(mVertexShader);
            GL.CompileShader(mFragShader);

            Console.WriteLine(GL.GetShaderInfoLog(mVertexShader));
            Console.WriteLine(GL.GetShaderInfoLog(mFragShader));

            GL.AttachShader(mProgram, mVertexShader);
            GL.AttachShader(mProgram, mFragShader);

            GL.LinkProgram(mProgram);

            Console.WriteLine(GL.GetProgramInfoLog(mProgram));

        }
        public void run()
        {
            mGameWindow.Run(10);
        }
        int mVertexLocation = 0;
        private void onLoad(object sender, EventArgs e)
        {
            GL.ClearColor(System.Drawing.Color.HotPink);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Viewport(0, 0, mGameWindow.Width, mGameWindow.Height);
        }
        private void onResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, mGameWindow.Width, mGameWindow.Height);
        }
        float[] mVertices = { -0.5f, -0.5f, 1,
                                0.5f, -0.5f, 1,
                                0.5f, 0.5f, 1,
                                -0.5f, -0.5f, 1,
                                -0.5f, 0.5f, 1,
                                0.5f, 0.5f, 1 };
        float mTime = 0;
        private void shaderExample(object sender, FrameEventArgs e)
        {
            mTime += (float)mGameWindow.RenderTime;
            unsafe
            {
                GL.UseProgram(mProgram);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                fixed (float* pt = mVertices)
                {
                    
                    mVertexLocation = GL.GetAttribLocation(mProgram, "aVertex");
                    int mTimeLocation = GL.GetUniformLocation(mProgram, "uTime");
                    GL.Uniform1(mTimeLocation, mTime);
                    GL.EnableVertexAttribArray(mVertexLocation);
                    GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), mVertices);

                    
                    GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
                    GL.Finish();
                    mGameWindow.SwapBuffers();
                   

                }
            }
        }
    }
}
