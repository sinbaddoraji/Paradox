using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Paradox.Entities.Shapes
{
    public class Triangle : Mesh
    {
        public Triangle() : base(
            new float[]
            {
                // Positions       // Texture Coords
                0.0f,  0.5f, 0.0f,  0.5f, 1.0f,   // Top
                -0.5f, -0.5f, 0.0f,  0.0f, 0.0f,   // Bottom Left
                0.5f, -0.5f, 0.0f,  1.0f, 0.0f    // Bottom Right
            },
            new uint[]
            {
                0, 1, 2 // Single triangle
            })
        {
        }
    }

    public class Line : Mesh
    {
        public Line(Vector3 start, Vector3 end) : base(
            new float[]
            {
                // Positions         // Texture Coords (optional, not used for lines)
                start.X, start.Y, start.Z, 0.0f, 0.0f,
                end.X, end.Y, end.Z, 1.0f, 1.0f
            },
            new uint[]
            {
                0, 1  // Line consists of 2 vertices
            })
        {
        }

        public override void Render()
        {
            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.Lines, 0, 2);
        }
    }

    public class Rectangle : Mesh
    {
        public Rectangle(Vector2 position, Vector2 size, bool isFilled = true) : base(
            new float[]
            {
                // Positions          // Texture Coords
                position.X, position.Y + size.Y, 0.0f,  0.0f, 1.0f, // Top Left
                position.X + size.X, position.Y + size.Y, 0.0f,  1.0f, 1.0f, // Top Right
                position.X + size.X, position.Y, 0.0f,  1.0f, 0.0f, // Bottom Right
                position.X, position.Y, 0.0f,  0.0f, 0.0f  // Bottom Left
            },
            new uint[]
            {
                0, 1, 2,  // First Triangle
                2, 3, 0   // Second Triangle
            })
        {
            this.isFilled = isFilled;
        }

        public bool isFilled { get; }

        public override void Render()
        {
            GL.BindVertexArray(VAO);
            if (isFilled)
            {
                GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                GL.DrawElements(PrimitiveType.LineLoop, Indices.Length, DrawElementsType.UnsignedInt, 0);
            }
        }
    }


}
