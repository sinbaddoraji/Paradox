using OpenTK.Graphics.OpenGL4;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;

public class Texture
{
    public int Handle { get; private set; }

    public Texture(string path)
    {
        // Load the image
        using (Image<Rgba32> image = Image.Load<Rgba32>(path))
        {
            // Flip the image vertically since OpenGL expects the image origin to be at the bottom left
            image.Mutate(x => x.Flip(FlipMode.Vertical));

            // Create a new OpenGL texture
            Handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, Handle);

            // Set texture parameters
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            // Upload the image to the GPU
            var pixels = new byte[4 * image.Width * image.Height];
            image.CopyPixelDataTo(pixels);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixels);

            // Generate mipmaps for the texture
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }
    }

    public void Use(TextureUnit unit)
    {
        // Activate the texture unit and bind the texture
        GL.ActiveTexture(unit);
        GL.BindTexture(TextureTarget.Texture2D, Handle);
    }

    public void Dispose()
    {
        // Delete the OpenGL texture when it's no longer needed
        GL.DeleteTexture(Handle);
    }
}
