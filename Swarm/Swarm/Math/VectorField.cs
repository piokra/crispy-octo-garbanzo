using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swarm.Math
{
    public abstract class VectorField2D
    {
        public abstract Vector2D count(Vector2D v);
    }
    public class FunctionVectorField2D : VectorField2D
    {
        public delegate double RRFunction(Vector2D v);
        public RRFunction XFunction = (Vector2D v) => { return 0; };
        public RRFunction YFunction = (Vector2D v) => { return 0; };

        public override Vector2D count(Vector2D v)
        {
            return new Vector2D(XFunction(v), YFunction(v));
        }
    }
    public class VectorFieldSuperPosition : VectorField2D
    {
        List<VectorField2D> mFields = new List<VectorField2D>();
        public void addField(VectorField2D vf)
        {
            mFields.Add(vf);
        }
        public override Vector2D count(Vector2D v)
        {
            Vector2D result = new Vector2D(0, 0);
            foreach (var item in mFields)
            {
                result += item.count(v);
            }
            return result;
        }
    }
}
