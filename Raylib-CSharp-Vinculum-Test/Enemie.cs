using System.Numerics;
using ZeroElectric.Vinculum;

namespace Raylib_CSharp_Vinculum_Test;

public class Enemie
{
    private int framesCounter = 0;

    // Initializing enemie variables
	public bool Existance = false;
    private int enemieHealth;
    public Rectangle enemieRectangle;
    private float enemieSpeed;
    private float enemieRotation;
    public Vector2 enemiePosition;
    
    // Enemie constructor
    public Enemie (Rectangle enemieRectangle, float enemieRotation, Vector2 enemiePosition, int enemieHealth, float enemieSpeed) 
    {
        this.enemieHealth = enemieHealth;
        this.enemieRectangle = enemieRectangle;
        this.enemieSpeed = enemieSpeed;
        this.enemieRotation = enemieRotation;
        this.enemiePosition = enemiePosition;
    }

    public int HealthUpdate() 
    {
        if (framesCounter > 60 && enemieHealth > 0 && Existance == true) {enemieHealth--; framesCounter = 0;}
        if (enemieHealth == 0) {Existance = false; enemieHealth = 5;}

        framesCounter++;

        return 0;
    }
    public int Spawner() 
    {
        Existance = true;

        return 0;
    }
}