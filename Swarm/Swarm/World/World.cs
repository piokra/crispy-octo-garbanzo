using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Swarm.World.Entities;
namespace Swarm.World
{
    public class World
    {
        private Random mWorldSeed = new Random((int)DateTime.Now.Ticks);
        public Random WorldSeed
        {
            get { return mWorldSeed; }
        }
        private List<AbstractEntity> mEntities;
        public List<AbstractEntity> Entities
        {
            get { return mEntities; }
        }
        public World()
        { 
            mEntities = new List<AbstractEntity>();
            for (int i = 0; i < 10; i++)
            {
                mEntities.Add(new AbstractEntity.BaseEntity(this));
            }
        }
        public void process()
        {
            Thread[] threads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i] = new Thread(

                        () =>
                        {
                            for (int j = i; j < mEntities.Count; j += Environment.ProcessorCount)
                            {
                                mEntities[j].interact();
                            }
                        }

                    );
                threads[i].Start();

            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i].Join();
            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i] = new Thread(

                        () =>
                        {
                            for (int j = i; j < mEntities.Count; j += Environment.ProcessorCount)
                            {
                                mEntities[j].process();
                            }
                        }

                    );
                threads[i].Start();

            }
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads[i].Join();
            }

        }
    }
}
