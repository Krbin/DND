using System.Security.Cryptography.X509Certificates;

namespace _10_9_24;

class Program
{
    static void Main(string[] args)
    {

    }
}

public abstract class Object3D
{
    public abstract double Surface();
    public abstract double Volume();
    public double SurfaceToVolumeRatio()
    {
        return Surface() / Volume();
    }
}

public class Cylinder : Object3D
{
    private double height;
    public double Height
    {
        get { return height; }
        set
        {
            if (value > 0)
            {
                height = value;
            }
        }
    }
    private double radius;
    public double Radius
    {
        get { return this.radius; }
        set
        {
            if (value > 0)
            {
                this.radius = value;
            }
        }
    }
    public Cylinder(double height, double radius)
    {
        Height = height;
        Radius = radius;
    }
    public double Diameter
    {
        get { return radius * 2; }
        set { this.Radius = value * 2; }
    }
    public override double Surface()
    {
        return 2 * Math.PI * Radius * (Radius + Height);
    }
    public override double Volume()
    {
        return Math.PI * Math.Pow(Radius, 2) * Height;
    }
}

public class Sphere : Object3D
{
    public Sphere(double radius)
    {
        Radius = radius;
    }
    private double radius;
    public double Radius
    {
        get { return this.radius; }
        set
        {
            if (value > 0)
            {
                this.radius = value;
            }
        }
    }
    public double Diameter
    {
        get { return radius * 2; }
        set { this.Radius = value * 2; }
    }
    public override double Surface()
    {
        return 4 * Math.PI * Math.Pow(Radius, 2);
    }
    public override double Volume()
    {
        return 4.0 / 3.0 * Math.PI * Math.Pow(Radius, 3);
    }
}
public class Cube : Object3D
{
    public Cube()
    {

    }
    private double side;
    public double Side
    {
        get { return this.side; }
        set
        {
            if (value > 0)
            {
                this.side = value;
            }
        }
    }
    public override double Surface()
    {
        return 6 * Math.Pow(Side, 2);
    }
    public override double Volume()
    {
        return Math.Pow(Side, 3);
    }
}
public class Cone : Object3D
{
    public Cone()
    {
    }
    private double height;
    public double Height;
    private double radius;
    public double Radius
    {
        get { return this.radius; }
        set
        {
            if (value > 0)
            {
                this.radius = value;
            }
        }
    }
    public double Diameter
    {
        get { return radius * 2; }
        set { this.Radius = value * 2; }
    }
    public override double Surface()
    {
        return Math.PI * Radius * (Radius + height);
    }
    public override double Volume()
    {
        return 1.0 / 3.0 / Math.Pow(Radius, 2) * Radius;
    }
}
