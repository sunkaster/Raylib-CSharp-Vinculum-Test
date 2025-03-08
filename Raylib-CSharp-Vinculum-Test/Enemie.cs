using System.Numerics;
using Microsoft.VisualBasic;
using ZeroElectric.Vinculum;
using Raylib_CSharp_Vinculum_Test;

namespace Raylib_CSharp_Vinculum_Test;

public class Enemie
{
    private int framesCounter = 0;

    Random random = new Random();
 
    // Initializing enemie variables
	public bool existance;
    private int enemieHealth;
    private int enemieMaxHealth;
    public Rectangle enemieRectangle;
    private float enemieSpeed;
    private float enemieRotation;
    private float enemieDefaultRotation;
    public Vector2 enemiePosition;
    public Vector2 enemiePositionParameterX;
    public Vector2 enemiePositionParameterY;  
    public bool enemieHasBeenReset;
    public bool isLoaded;
    
    // Enemie constructor
    public Enemie (Rectangle enemieRectangle, float enemieRotation, Vector2 enemiePosition, Vector2 EnemiePositionParameterX, Vector2 EnemiePositionParameterY, int enemieHealth, float enemieSpeed) 
    {
        this.enemieHealth = enemieHealth;
        this.enemieMaxHealth = enemieHealth;
        this.enemieRectangle = enemieRectangle;
        this.enemieSpeed = enemieSpeed;
        this.enemieRotation = enemieRotation;
        this.enemieDefaultRotation = enemieRotation;
        this.enemiePosition = enemiePosition;
        this.enemiePositionParameterX = EnemiePositionParameterX;
        this.enemiePositionParameterY = EnemiePositionParameterY;
    }

    public int HealthUpdate() 
    {
        if (framesCounter > 60 && enemieHealth > 0 && existance == true) {enemieHealth--; framesCounter = 0;}
        if (enemieHealth == 0) {existance = false; enemieHealth = 5;}

        framesCounter++;

        return 0;
    }
    public int HealthUpdate2()
    {
        if (enemieHealth > 0) {existance = true;}
        if (framesCounter > 60 && enemieHealth > 0) {enemieHealth--; framesCounter = 0;}
        if (enemieHealth == 0) {existance = false;}

        framesCounter++;

        return 0;
    }
    public int Spawner() 
    {
        existance = true;

        return 0;
    }
    public bool EnemieReset()
    {
        enemieHealth = enemieMaxHealth;
        enemiePosition.X = random.Next((int)enemiePositionParameterX.X, (int)enemiePositionParameterX.Y);
        enemiePosition.Y = random.Next((int)enemiePositionParameterY.X, (int)enemiePositionParameterY.Y);
        enemieRotation = enemieDefaultRotation;
        enemieHasBeenReset = true;

        return enemieHasBeenReset;
    }
}