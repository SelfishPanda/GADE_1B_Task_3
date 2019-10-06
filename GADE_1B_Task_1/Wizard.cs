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



        public override string ToString()
        {
            string output = "";
            output = "Melee Unit (" + team + ")" + "\n" + "Health Points : " + this.HP + "\n" + "X-Position : " + this.xPos + "\n" + "Y-Position :" + this.yPos;
            return output;
        }

        public void WizardAOE(unit[] units)
        {
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
    }
}
