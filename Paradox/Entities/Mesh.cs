using OpenTK.Graphics.OpenGL4;

namespace Paradox.Entities;

public class Mesh
{
    private int _vao;
    private int _vbo;
    private int _ebo;
    private int _vertexCount;

    public Mesh(float[] vertices, uint[] indices)
    {
        _vertexCount = indices.Length;

        // Generate and bind VAO
        _vao = GL.GenVertexArray();
        GL.BindVertexArray(_vao);

        // Generate and bind VBO
        _vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        // Generate and bind EBO
        _ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

        // Setup vertex attributes (position, normals, etc.)
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        // Unbind VAO
        GL.BindVertexArray(0);
    }

    public void Render()
    {
        GL.BindVertexArray(_vao);
        GL.DrawElements(PrimitiveType.Triangles, _vertexCount, DrawElementsType.UnsignedInt, 0);
    }
}