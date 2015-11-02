using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swarm.Math;

namespace Swarm.World.Entities
{
    public abstract partial class AbstractEntity
    {
        public abstract void interact();
        public abstract void process();

        protected abstract Vector2D getPosition();
        protected abstract World getWorld();
        protected abstract double getSpeed();
        protected abstract Vector2D getDirection();
        protected abstract void addForce(Vector2D vector);
    }
}
