using System;

public abstract class Building
{
    public int xPos;
    public int yPos;
    public int HP;
    public int maxHP;
    public string team;
    public char symbol;

    public int XPos { get { return xPos; } set { xPos = value; } }
    public int YPos { get { return yPos; } set { yPos = value; } }
    public int hP { get { return HP; } set { HP = value; } }
    public int MaxHP { get { return maxHP; } }
    public string Team { get { return team; } }
    public char Symbol { get { return symbol; } }

    public  Building(int _xPos, int _yPos, int _HP, string _team, char _symbol)
	{
        xPos = _xPos;
        yPos = _yPos;
        HP = _HP;
        maxHP = _HP;
       
        team = _team;
        symbol = _symbol;
    }

    public abstract bool Death();
    public abstract string toString();
}
