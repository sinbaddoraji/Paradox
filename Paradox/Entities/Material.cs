using OpenTK.Graphics.OpenGL4;
using Paradox.Scene;

namespace Paradox.Entities;

public class Material
{
    public Shader Shader { get; set; }
    private Texture _texture;

    public Material(Shader shader, Texture texture)
    {
        Shader = shader;
        _texture = texture;
    }

    public void BindTextures()
    {
        if (_texture != null)
        {
            _texture.Use(TextureUnit.Texture0);
        }
    }
}