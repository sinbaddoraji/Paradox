namespace Paradox.Entities.Shapes;

public class Quad : Mesh
{
    public Quad() : base(
        new float[]
        {
            // Positions        // Texture Coords
            -0.5f,  0.5f, 0.0f,  0.0f, 1.0f,   // Top Left
            0.5f,  0.5f, 0.0f,  1.0f, 1.0f,   // Top Right
            -0.5f, -0.5f, 0.0f,  0.0f, 0.0f,   // Bottom Left
            0.5f, -0.5f, 0.0f,  1.0f, 0.0f    // Bottom Right
        },
        new uint[]
        {
            0, 1, 2,   // First Triangle
            1, 2, 3    // Second Triangle
        })
    {
    }
}