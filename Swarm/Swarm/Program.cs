using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swarm.World;
namespace Swarm
{
    class Program
    {
        static void Main(string[] args)
        {
            World.World world = new World.World();
            for (int i = 0; i < 10e2; i++)
            {
                var before = System.DateTime.Now;
                world.process();
                var after = System.DateTime.Now;
                Console.WriteLine(after - before);
            }
            Console.ReadKey();
        }
    }
}
