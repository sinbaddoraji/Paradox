using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradox.Entities;
using static OpenTK.Graphics.OpenGL.GL;

namespace Paradox;

public class RenderableObject
{
    public Mesh Mesh { get; set; }
    public Material Material { get; set; }
    public Transform Transform { get; set; }

    public RenderableObject(Mesh mesh, Material material)
    {
        Mesh = mesh;
        Material = material;
        Transform = new Transform();
    }

    public void Render()
    {
        // Bind the shader program
        Material.Shader.Use();

        // Set uniforms (like transformation matrices)
        Material.Shader.SetMatrix4("model", Transform.GetModelMatrix());

        // Bind textures
        Material.BindTextures();

        // Draw the mesh
        Mesh.Render();
    }
}