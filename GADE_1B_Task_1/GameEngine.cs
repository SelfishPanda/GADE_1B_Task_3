using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_1B_Task_1
{
    class GameEngine
    {
        public int gameRounds, t1Resources,t2Resources;
        unit[] arrUnits;
        public Map map ;
        public string OutputString, buildingOutput;
        Form1 form = new Form1();
        bool buildingcloser = false;


        public GameEngine()
        {
            map = new Map(2,4,30,30);
            map.RandomBattlefield();
            this.arrUnits = map.arrUnits;
            gameRounds = 0;
            t1Resources = 0;
            t2Resources = 0;
           
        }


        //Direction in wich to move
        public string Direction(unit Main, unit Enemy)
        {
            string ReturnVal;
            ReturnVal = " ";



            int xTotal, yTotal;
            string xDirection, yDirection;
            xTotal = 0;
            yTotal = 0;
            xDirection = "";
            yDirection = "";

            xTotal = Main.xPos - Enemy.xPos;
            yTotal = Main.yPos - Enemy.yPos;

            
            
                if (xTotal > 0)
                {
                    xDirection = "left";
                }
                else if (xTotal < 0)
                {
                    xDirection = "right";
                }
            
            
            
                if (yTotal < 0)
                {
                    yDirection = "down";
                }
                else if (yTotal > 0)
                {
                    yDirection = "up";
                }
            
                    xTotal = Math.Abs(Main.xPos - Enemy.xPos);
                    yTotal = Math.Abs(Main.yPos - Enemy.yPos);
                    
            if (xTotal >= yTotal && xTotal>0)
            {
                ReturnVal = xDirection;
                return xDirection;
                
            }
            else
            {
                ReturnVal = yDirection;
                return yDirection;
                
            }              	
        }

        public string Direction(unit Main, Building Enemy)
        {
            string ReturnVal;
            ReturnVal = " ";



            int xTotal, yTotal;
            string xDirection, yDirection;
            xTotal = 0;
            yTotal = 0;
            xDirection = "";
            yDirection = "";

            xTotal = Main.xPos - Enemy.xPos;
            yTotal = Main.yPos - Enemy.yPos;



            if (xTotal > 0)
            {
                xDirection = "left";
            }
            else if (xTotal < 0)
            {
                xDirection = "right";
            }



            if (yTotal < 0)
            {
                yDirection = "down";
            }
            else if (yTotal > 0)
            {
                yDirection = "up";
            }

            xTotal = Math.Abs(Main.xPos - Enemy.xPos);
            yTotal = Math.Abs(Main.yPos - Enemy.yPos);

            if (xTotal >= yTotal && xTotal > 0)
            {
                ReturnVal = xDirection;
                return xDirection;

            }
            else
            {
                ReturnVal = yDirection;
                return yDirection;

            }
        }





        //
        public void GameLogic(unit[] arrUnits)
        {
            gameRounds++;
            Random rnd = new Random();
            bool death;
            string direction;
            direction = " ";
            
            death = false;
            
            OutputString = "";
            for (int i = 0; i < this.arrUnits.Length; i++)
            {





                death = this.arrUnits[i].Death();
                if (death == true)
                { arrUnits[i].HP = 0; }
                else
                {

                    unit closestunit = this.arrUnits[i].ClosestUnit(arrUnits);
                    Building closestBuilding = this.arrUnits[i].ClosestUnit(map.arrBuildings);



                    int xDistb = Math.Abs(this.arrUnits[i].xPos - closestBuilding.xPos);
                    int yDistb = Math.Abs(this.arrUnits[i].yPos - closestBuilding.yPos);
                    int totalDistb = xDistb + yDistb;

                    int xDistu = Math.Abs(this.arrUnits[i].xPos - closestunit.xPos);
                    int yDistu = Math.Abs(this.arrUnits[i].yPos - closestunit.yPos);
                    int totalDistu = xDistu + yDistu;






                    if (totalDistb < totalDistu && closestBuilding.hP > 0)
                    {


                        this.arrUnits[i].AttackRange(closestBuilding);
                        if (this.arrUnits[i].HP <= (this.arrUnits[i].maxHP * 0.25))
                        {
                            string randomDirection;
                            int random;

                            random = rnd.Next(1, 5);

                            if (random == 1)
                            {
                                randomDirection = "left";
                            }
                            else if (random == 2)
                            {
                                randomDirection = "right";
                            }
                            else if (random == 3)
                            {
                                randomDirection = "up";
                            }
                            else
                            {
                                randomDirection = "down";
                            }

                            this.arrUnits[i].Move(randomDirection);

                            this.arrUnits[i].HP += 2;
                        }
                        else
                        {


                            if (this.arrUnits[i].isAttacking == true)
                            {
                                this.arrUnits[i].Combat(closestBuilding);
                            }
                            else
                            {
                                int oldX, oldY;
                                oldX = this.arrUnits[i].xPos;
                                oldY = this.arrUnits[i].yPos;
                                direction = Direction(this.arrUnits[i], closestBuilding);
                                this.arrUnits[i].Move(direction);
                                map.MapUpdate(this.arrUnits[i], oldX, oldY);

                            }
                        }
                    }
                    else
                    {


                        if (this.arrUnits[i] == closestunit)
                        { }
                        else
                        {

                            this.arrUnits[i].AttackRange(closestunit);
                            if (this.arrUnits[i].HP <= (this.arrUnits[i].maxHP * 0.25))
                            {
                                string randomDirection;
                                int random;

                                random = rnd.Next(1, 5);

                                if (random == 1)
                                {
                                    randomDirection = "left";
                                }
                                else if (random == 2)
                                {
                                    randomDirection = "right";
                                }
                                else if (random == 3)
                                {
                                    randomDirection = "up";
                                }
                                else
                                {
                                    randomDirection = "down";
                                }

                                this.arrUnits[i].Move(randomDirection);

                                this.arrUnits[i].HP += 2;
                            }
                            else
                            {


                                if (this.arrUnits[i].isAttacking == true)
                                {
                                    this.arrUnits[i].Combat(closestunit);
                                }
                                else
                                {
                                    int oldX, oldY;
                                    oldX = this.arrUnits[i].xPos;
                                    oldY = this.arrUnits[i].yPos;
                                    direction = Direction(this.arrUnits[i], closestunit);
                                    this.arrUnits[i].Move(direction);
                                    map.MapUpdate(this.arrUnits[i], oldX, oldY);

                                }
                            }
                        }
                    }

                }
            
                    
                
                    OutputString += "\n" + this.arrUnits[i].ToString();
                
                

                OutputString += "\n";

            }

            buildingOutput = " ";
            
            for (int i = 0; i < map.arrBuildings.Length; i++)
            {
                string buildingType = map.arrBuildings[i].GetType().ToString();
                string[] buildingArr = buildingType.Split('.');
                buildingType = buildingArr[buildingArr.Length - 1];


                if (buildingType == "ResourceBuilding")
                {

                    ResourceBuilding building = (ResourceBuilding)map.arrBuildings[i];
                    if (building.Death() == true)
                    { }
                    else
                    {
                        building.ResourceManagement();
                        if (building.team== "Team1")
                        {
                            t1Resources += building.resourcesGeneratedPerRound;
                        }
                        else
                        {
                            t2Resources += building.resourcesGeneratedPerRound;
                        }
                    }
                   
                }
                else if (buildingType == "FactoryBuilding")
                {
                    FactoryBuilding building = (FactoryBuilding)map.arrBuildings[i];

                    if (building.Death() == true)
                    { }
                    else
                    {
                        if (building.team == "Team1")
                        {
                            if (t1Resources >= 60)
                            {

                                Array.Resize(ref this.arrUnits, this.arrUnits.Length + 1); ;
                                this.arrUnits[this.arrUnits.Length - 1] = building.CreateUnit();
                                map.arrUnits = this.arrUnits;
                                t1Resources -= 60;

                            }
                        }   
                        else
                        {
                            if (t2Resources >= 60)
                            {

                                Array.Resize(ref this.arrUnits, this.arrUnits.Length + 1); ;
                                this.arrUnits[this.arrUnits.Length - 1] = building.CreateUnit();
                                map.arrUnits = this.arrUnits;
                                t2Resources -= 60 ;

                            }
                        }
                    }
                    

                }
                buildingOutput += "\n" + map.arrBuildings[i].toString();
                buildingOutput += "\n";
            }
            map.arrUnits = this.arrUnits;


        }

    }
}
