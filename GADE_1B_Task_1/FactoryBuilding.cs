using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_1B_Task_1
{
    class FactoryBuilding : Building
    {

        //CLASS VARIABLES
        public string unitToProduce { get;  }
        public int productionSpeed { get;}
        public int spawnYPos { get; }
        public int unitsProduced;
        //CLASS CONSTRUCTORS
        public FactoryBuilding(int _xPos, int _yPos, int _HP, string _team, char _symbol, string _unitToProduce, int _productionSpeed, int _spawnYPos) : base(_xPos, _yPos, _HP, _team, _symbol)
        {
            unitToProduce = _unitToProduce;
            productionSpeed = _productionSpeed;
            spawnYPos = _spawnYPos;
            unitsProduced = 0;
        }


        public override bool Death()
        {//checks to see if this unit is dead
            bool death;
            death = false;

            if (HP<=0)
            {
                death = true;
                HP = 0;
            }

            return death;

        }
        public override string toString()
        {//Puts all the units stats into a string so it can be output to display them
            string output = "";
            output = "Factory Building (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos + "\n" + "Units Produced :" + this.unitsProduced + "\n" + "Units Being Produced :" + this.unitToProduce;
            return output;

        }

        public unit CreateUnit()
        {//creates random units if there is enough resources
            if (this.team == "Team1")
            {


                unitsProduced += 1;
                if (unitToProduce == "Ranged Unit")
                {
                    RangedUnit unit = new RangedUnit("Archer", this.xPos, spawnYPos, 80, 1, 3, 1, this.team, 'O', false);
                    return unit;
                }
                else
                {
                    MeleeUnit unit = new MeleeUnit("Knight", this.xPos, spawnYPos, 100, 1, 5, 1, this.team, 'X', false);
                    return unit;
                }
            }
            else
            {
                if (unitToProduce == "Ranged Unit")
                {
                    RangedUnit unit = new RangedUnit("Archer", this.xPos, spawnYPos, 80, 1, 3, 1, this.team, 'o', false);
                    return unit;
                }
                else
                {
                    MeleeUnit unit = new MeleeUnit("Knight", this.xPos, spawnYPos, 100, 1, 5, 1, this.team, 'x', false);
                    return unit;
                }
            }
           
        }
        

        
    }
}
