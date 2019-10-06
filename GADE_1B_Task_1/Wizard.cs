using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_1B_Task_1
{
    class Wizard : unit
    {


        //CLASS CONSTRUCTORS
        public Wizard(string _unitName, int _xPos, int _yPos, int _HP, int _speed, int _attack, int _attackRange, string _team, char _symbol, bool _isAttacking) : base(_unitName, _xPos, _yPos, _HP, _speed, _attack, _attackRange, _team, _symbol, _isAttacking)
        {

        }


        //Puts all the units stats into a string so it can be output to display them
        public override string ToString()
        {
            string output = "";
            output = "Wizard (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos;
            return output;
        }

        public void WizardAOE(unit[] units)
        {//checks around the unit to make the AOE effect of the wizard work and damages units within range
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i].xPos == this.xPos+1 && units[i].yPos == this.yPos+1|| units[i].xPos == this.xPos - 1 && units[i].yPos == this.yPos - 1|| units[i].xPos == this.xPos - 1 && units[i].yPos == this.yPos + 1|| units[i].xPos == this.xPos + 1 && units[i].yPos == this.yPos - 1|| units[i].xPos == this.xPos  && units[i].yPos == this.yPos + 1|| units[i].xPos == this.xPos  && units[i].yPos == this.yPos - 1|| units[i].xPos == this.xPos + 1 && units[i].yPos == this.yPos || units[i].xPos == this.xPos - 1 && units[i].yPos == this.yPos )
                {
                    if (units[i].unitName != "Wizard")
                    {
                        Combat(units[i]);
                    }
                    
                }
            }
        }

        public virtual unit ClosestUnit(unit[] units)
        {//overloads closestunit method so wizards cant attack eachother and hence wont move to other wizards
            int xDist, yDist, totalDist, closestDist, checkValue;
            unit closestUnit, thisUnit;
            closestDist = 999;
            closestUnit = units[1];
            checkValue = 69;
            thisUnit = units[1];

            for (int i = 0; i < units.Length; i++)
            {

                if (!units[i].Death() && units[i].unitName != "Wizard")
                {
                    if (this.team == units[i].team)
                    {


                    }
                    else if (this.xPos == units[i].xPos && this.yPos == units[i].yPos)
                    {

                        thisUnit = units[i];

                    }
                    else
                    {
                        xDist = Math.Abs(this.xPos - units[i].xPos);
                        yDist = Math.Abs(this.yPos - units[i].yPos);
                        totalDist = xDist + yDist;

                        if (totalDist <= closestDist)
                        {
                            closestDist = totalDist;
                            closestUnit = units[i];
                            checkValue = 42;
                        }
                    }
                }

            }

            if (checkValue == 69)
            {
                return thisUnit;
            }
            else
            {
                return closestUnit;
            }



        }
    }
}
