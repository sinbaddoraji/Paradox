using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Scene
    {
        public List<RenderableObject> RenderableObjects { get; private set; }

        public Scene()
        {
            RenderableObjects = new List<RenderableObject>();
        }

        public void AddObject(RenderableObject obj)
        {
            RenderableObjects.Add(obj);
        }
    }

}
