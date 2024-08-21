namespace Paradox.Scene
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
