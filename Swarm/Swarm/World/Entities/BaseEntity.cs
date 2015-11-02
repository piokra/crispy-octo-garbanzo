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


        public class BaseEntity : AbstractEntity
        {

            private Vector2D mPosition;
            private double mMass = 0;
            private double mCharge = 0;
            private double mSpeed = 0;
            private World mParent = null;
            private Vector2D mDirection;
            /// <summary>
            /// Intialize a entity with randomized parameters
            /// </summary>
            /// <param name="world">The world that this entity belongs to</param>
            public BaseEntity(World world)
            {
                mParent = world;
                mPosition = new Vector2D(mParent.WorldSeed.NextDouble() * 10.0 - 5.0, mParent.WorldSeed.NextDouble() * 10.0 - 5.0);
                mSpeed = 1;
                mMass = mParent.WorldSeed.NextDouble() * 50 + 10;
                mDirection = new Vector2D(mParent.WorldSeed.NextDouble() * 2.0 - 1.0, mParent.WorldSeed.NextDouble() * 2.0 - 1.0);


            }
            public override void interact()
            {
                //TODO do smt cool here
                for (int i = 0; i < mParent.Entities.Count; i++)
                {
                    AbstractEntity t = mParent.Entities[i];
                    t.addForce(mDirection+(-1)*t.getDirection());
                }

            }

            public override void process()
            {
                double length = mDirection.Length;
                if (length > 0)
                {
                    mDirection = (1 / length) * mDirection;
                    mSpeed *= length;
                }
                else
                {
                    mDirection.x = 0; mDirection.y = 0;
                    mSpeed = 1;
                }
                if (mSpeed > 2)
                    mSpeed = 2;
                if (mPosition.x * mPosition.x + mPosition.y * mPosition.y > 4)
                    mDirection = (-1) * mDirection;
                //TODO replace with charge setting
                mCharge += mSpeed * 0.1;
                mCharge *= 0.77;
                //TODO replace with clock setting
                mPosition += (0.01 * mSpeed) * mDirection;
                Console.WriteLine(mDirection.x + " " + mDirection.y);
            }

            protected override void addForce(Vector2D vector)
            {
                mDirection += (1 / mMass) * vector;
            }

            protected override Vector2D getPosition()
            {
                return mPosition;
            }

            protected override double getSpeed()
            {
                return mSpeed;
            }

            protected override World getWorld()
            {
                return mParent;
            }

            protected override Vector2D getDirection()
            {
                return mDirection;
            }
        }
    }
}
