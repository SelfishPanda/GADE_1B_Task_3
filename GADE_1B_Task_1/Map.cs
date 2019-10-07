using System;

namespace GADE_1B_Task_1
{
    class Map
    {
        //CLASS VARIABLES
        
        public unit[] arrUnits;
        public Building[] arrBuildings;
        public char[,] arrMap ;

        int sumUnits;
        int sumBuildings;
        public readonly int MAPX;
        public readonly int MAPY;

        //CLASS CONSTRUCTORS
        public Map(int _sumUnits, int _sumBuildings, int _mapX,int _mapY)
        {
            sumUnits = _sumUnits;
            sumBuildings = _sumBuildings;          
            char[,] ArrMap = new char[_mapX, _mapY];
            MAPX = _mapX;
            MAPY = _mapY;
            arrMap = ArrMap;
        }
       



        //CLASS METHODS
        public void RandomBattlefield()
        {
           // method creates a random battlefield and initializes all of the buildings and units on the map 

            int randomX, randomY;
            int random;
            randomX = 1;
            randomY = 1;

            arrUnits = new unit[sumUnits];
            arrBuildings = new Building[sumBuildings];
            Random rnd = new Random();
            //populate map
            for (int i = 0; i < arrMap.GetLength(0); i++)
            {
                for (int k = 0; k < arrMap.GetLength(1); k++)
                {
                    arrMap[i, k] = ',';

                }

            }
            //makes units
            for (int i = 0; i < sumUnits; i++)
            {


                randomX = rnd.Next(0, arrMap.GetLength(0));
                randomY = rnd.Next(0, arrMap.GetLength(1));

                
                random = rnd.Next(1, 8);

                while (arrMap[randomX, randomY] == 'x' || arrMap[randomX, randomY] == 'X' || arrMap[randomX, randomY] == 'o' || arrMap[randomX, randomY] == 'O')
                {//checks that they dont spawn ontop of eachother

                    randomX = rnd.Next(0, arrMap.GetLength(0));
                    randomY = rnd.Next(0, arrMap.GetLength(1));

                }
                //randomises the unit that will spawn
                if (random == 1)
                {


                    MeleeUnit unit = new MeleeUnit("Knight", randomX, randomY, 100, 1, 5, 1, "Team1", 'X', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;

                }
                else if (random == 2)
                {
                    MeleeUnit unit = new MeleeUnit("Knight", randomX, randomY, 100, 1, 5, 1, "Team2", 'x', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else if (random == 3)
                {
                    RangedUnit unit = new RangedUnit("Archer", randomX, randomY, 80, 1, 3, 3, "Team1", 'O', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else if (random == 4)                               
                {
                    RangedUnit unit = new RangedUnit("Archer", randomX, randomY, 80, 1, 3, 3, "Team2", 'o', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else if (random == 5)
                {
                    Wizard unit = new Wizard("Wizard", randomX, randomY, 100, 1, 5, 2, "Team1", 'W', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else if (random == 6)
                {
                    Wizard unit = new Wizard("Wizard", randomX, randomY, 100, 1, 5, 2, "Team2", 'w', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
                else
                {
                    Wizard unit = new Wizard("Wizard", randomX, randomY, 150, 1, 7, 2, "neutral", 'M', false);
                    arrMap[unit.xPos, unit.yPos] = unit.symbol;
                    arrUnits[i] = unit;
                }
	
                        
                       
            }
            //spawns all the buildings
            for (int k = 0; k < sumBuildings; k++)
            {

                randomX = rnd.Next(0, arrMap.GetLength(0));
                randomY = rnd.Next(0, arrMap.GetLength(1));

                while (arrMap[randomX, randomY] == 'x' || arrMap[randomX, randomY] == 'X' || arrMap[randomX, randomY] == 'o' || arrMap[randomX, randomY] == 'O')
                {//checks that they dont spawn ontop of eachother


                    randomX = rnd.Next(0, arrMap.GetLength(0));
                    randomY = rnd.Next(0, arrMap.GetLength(1));

                }
                //randomises building that will spawn
                random = rnd.Next(1, 7);

                int spawnYPos;
                spawnYPos = 0;

                if (randomY == 19)
                {
                    spawnYPos = 18;
                }
                else if (randomY == 0)
                {
                    spawnYPos = 1;
                }
                else
                {
                    spawnYPos = randomY - 1;
                }

                if (random == 1)
                {


                    ResourceBuilding building = new ResourceBuilding(randomX, randomY, 200, "Team1", 'R', "Tiberuim", 0, 5, 2000);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;

                }
                else if (random == 2)
                {
                    ResourceBuilding building = new ResourceBuilding(randomX, randomY, 200, "Team2", 'r', "Tiberuim", 0, 5, 2000);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else if (random == 3)
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team1", 'F', "Melee Unit", 20, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else if (random == 4)
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team1", 'F', "Ranged Unit", 20, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else if (random == 5)
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team2", 'f', "Melee Unit", 20, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
                else
                {
                    FactoryBuilding building = new FactoryBuilding(randomX, randomY, 200, "Team2", 'f', "Ranged  Unit", 20, spawnYPos);
                    arrMap[building.xPos, building.yPos] = building.symbol;
                    arrBuildings[k] = building;
                }
               
            }
        }

        public string MapDisplay()
        {//Displays map in a string that the label can use
            string mapString;
            mapString = " ";

            for (int i = 0; i < arrMap.GetLength(0); i++)
            {
                for (int k = 0; k < arrMap.GetLength(1); k++)
                {
                    mapString = mapString + arrMap[i, k];
                }
                mapString += "\n";

            }



            return mapString;

        }
        //updates the map array when a unit has moved
        public void MapUpdate(unit unitMove, int xOld, int yOld)
        {

            arrMap[xOld, yOld] = ',';

            arrMap[unitMove.xPos, unitMove.yPos] = unitMove.symbol;


        }





    }
}
