using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swarm.World
{
    class WorldSettings
    {
        static private List<WorldSettings> mWorlds = new List<WorldSettings>();

        public WorldSettings this[int i]
        {
            get
            {
                return mWorlds[i];
            }
            private set
            {
                mWorlds[i] = value;
            }
        }

        public WorldSettings()
        {
            mWorlds.Add(this);
        }

    }
}
