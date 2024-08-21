using OpenTK.Mathematics;

namespace Paradox;

public class Transform
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; } = Vector3.One;

    public Transform()
    {
        Position = Vector3.Zero;
        Rotation = Vector3.Zero;
        Scale = Vector3.One;
    }

    public Matrix4 GetModelMatrix()
    {
        Matrix4 translationMatrix = Matrix4.CreateTranslation(Position);
        Matrix4 rotationXMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(Rotation.X));
        Matrix4 rotationYMatrix = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(Rotation.Y));
        Matrix4 rotationZMatrix = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(Rotation.Z));
        Matrix4 scaleMatrix = Matrix4.CreateScale(Scale);

        return scaleMatrix * rotationXMatrix * rotationYMatrix * rotationZMatrix * translationMatrix;
    }
}