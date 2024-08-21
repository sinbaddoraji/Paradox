namespace Paradox.Entities.Shapes;

public class Circle : Mesh
{
    public Circle(int segments) : base(CreateCircleVertices(segments), CreateCircleIndices(segments))
    {
    }

    private static float[] CreateCircleVertices(int segments)
    {
        List<float> vertices = new List<float>();

        // Center vertex
        vertices.Add(0.0f);
        vertices.Add(0.0f);
        vertices.Add(0.0f);
        vertices.Add(0.5f);
        vertices.Add(0.5f);

        for (int i = 0; i <= segments; i++)
        {
            float theta = 2.0f * MathF.PI * i / segments;
            float x = 0.5f * MathF.Cos(theta);
            float y = 0.5f * MathF.Sin(theta);

            vertices.Add(x);
            vertices.Add(y);
            vertices.Add(0.0f);
            vertices.Add((x + 1.0f) / 2.0f);
            vertices.Add((y + 1.0f) / 2.0f);
        }

        return vertices.ToArray();
    }

    private static uint[] CreateCircleIndices(int segments)
    {
        List<uint> indices = new List<uint>();

        for (int i = 1; i <= segments; i++)
        {
            indices.Add(0);
            indices.Add((uint)i);
            indices.Add((uint)(i + 1));
        }

        return indices.ToArray();
    }
}