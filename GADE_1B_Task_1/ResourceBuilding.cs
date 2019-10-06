using System;

class ResourceBuilding : Building
{

    //CLASS VARIABLES
    public string resourceType { get; }
    public int resourcesGenerated { get; set; }
    public int resourcesGeneratedPerRound { get;}
    public int resourcePool { get; set; }

    //CLASS CONSTRUCTORS
    public ResourceBuilding(int _xPos, int _yPos, int _HP, string _team, char _symbol, string _resourceType, int _resourcesGenerated, int _resourcesGeneratedPerRound, int _resourcePool): base(_xPos,_yPos,_HP,_team,_symbol)
    {
        resourceType = _resourceType;
        resourcesGenerated = _resourcesGenerated;
        resourcesGeneratedPerRound = _resourcesGeneratedPerRound;
        resourcePool = _resourcePool;
    }

    public override bool Death()
    {//checks to see if this unit is dead
        bool death;
        death = false;

        if (HP <= 0)
        {
            death = true;
            HP = 0;
        }

        return death;
        
    }
    public override string toString()
    {//Puts all the units stats into a string so it can be output to display them
        string output = "";
        output = "Resource Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos + "\n"+ "Resources Generated :"+this.resourcesGenerated + "\n"+"Resources Left in Pool :"+ this.resourcePool;
        return output;
    }

    public void ResourceManagement()
    {//manages the resources by adding to total generated but taking from the pool
        resourcePool -= resourcesGeneratedPerRound;
        resourcesGenerated += resourcesGeneratedPerRound;
        
    }
}
