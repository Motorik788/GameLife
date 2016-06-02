using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Herbivorous_1 : ContentBase, IBehavior, Core.IAnimal
    {

        public Herbivorous_1(int x, int y, int energy_, int speed_, int deathVis, char ico = '@') : base(x, y, ico)
        {
            energy = energy_;
            speed = speed_;
            DieIteration = deathVis;
        }
        public Herbivorous_1() { }

        int DieIteration = 1;
        int energy = 10;
        int speed = 2;

        public int Energy
        {
            get
            {
                return energy;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public override IBehavior Behavior
        {
            get
            {
                return this as IBehavior;
            }
        }


        
        public void Eat(Game Game)
        {

        }

        void EAT(Game game, int x,int y)
        {
            game.CurrentField.GameObjects.Find(c => c.PosX == x && c.PosY == y).Behavior.Die(game);
            energy += 3;
        }

        public void Reproduce(Game game)
        {
            for (int i = PosY - 1; i <= PosY + 1; i++)
            {
                for (int j = PosX - 1; j <= PosX + 1; j++)
                {
                    if (j > -1 && i > -1)
                    {
                        if ((j < game.CurrentField.XLenght && i < game.CurrentField.YLenght) &&
                             !(game.CurrentField.Cells[i][j] is Herbivorous_1))
                        {
                            if (game.CurrentField.Cells[i][j])
                                game.CurrentField.DeleteCell(j, i);
                            game.CurrentField.AddCell(new Herbivorous_1(j, i, Energy - 10, Speed, DieIteration));
                            energy -= Energy - 10;
                            return;
                        }
                    }
                }
            }
        }


        // кажется тут я жуткую дичь написал)
        int destX = 9;
        int destY = 3;
        public void Walk(Game Game)
        {
         
            double len = 1000000;
            var go = Game.CurrentField.GameObjects.Find(x => x == this);
            foreach (var item in Game.CurrentField.GameObjects)
            {
                if (item is Grass || item is Grass_2)
                {
                    double l = Math.Sqrt((item.PosX - go.PosX) * (item.PosX - go.PosX) + (item.PosY - go.PosY) * (item.PosY - go.PosY));
                    
                    if(len > l)
                    {
                        len = l;
                        destX = item.PosX;
                        destY = item.PosY;
                    }
                }
            }
            
            if (go.PosX < destX && go.PosX + speed < Game.CurrentField.XLenght && !(Game.CurrentField.Cells[go.PosY][go.PosX + speed] is Herbivorous_1))
            {
                Game.CurrentField.Cells[go.PosY][go.PosX] = null;
                if((Game.CurrentField.Cells[go.PosY][go.PosX + speed] is Grass) || (Game.CurrentField.Cells[go.PosY][go.PosX + speed] is Grass_2))
                {
                    EAT(Game,go.PosX + speed, go.PosY);
                }
                Game.CurrentField.Cells[go.PosY][go.PosX + speed] = go;
                go.PosX = go.PosX + speed;
                return;
            }
            if (go.PosX > destX && go.PosX - speed >= 0 && !(Game.CurrentField.Cells[go.PosY][go.PosX - speed] is Herbivorous_1))
            {
                Game.CurrentField.Cells[go.PosY][go.PosX] = null;
                if ((Game.CurrentField.Cells[go.PosY][go.PosX - speed] is Grass) || (Game.CurrentField.Cells[go.PosY][go.PosX - speed] is Grass_2))
                {
                    EAT(Game,go.PosX - speed, go.PosY);
                }
                Game.CurrentField.Cells[go.PosY][go.PosX - speed] = go;
                go.PosX = go.PosX - speed;
                return;
            }
            if (go.PosY > destY && go.PosY - speed >= 0 && !(Game.CurrentField.Cells[go.PosY - speed][go.PosX ] is Herbivorous_1))
            {
                Game.CurrentField.Cells[go.PosY][go.PosX] = null;
                if ((Game.CurrentField.Cells[go.PosY - speed][go.PosX ] is Grass) || (Game.CurrentField.Cells[go.PosY - speed][go.PosX ] is Grass_2))
                {
                    EAT(Game,go.PosX, go.PosY - speed);
                }
                Game.CurrentField.Cells[go.PosY - speed][go.PosX] = go;
                go.PosY = go.PosY - speed;
                return;
            }
            if (go.PosY < destY && go.PosY + speed >= 0 && !(Game.CurrentField.Cells[go.PosY + speed][go.PosX ] is Herbivorous_1))
            {
                Game.CurrentField.Cells[go.PosY][go.PosX] = null;
                if ((Game.CurrentField.Cells[go.PosY + speed][go.PosX ] is Grass) || (Game.CurrentField.Cells[go.PosY + speed][go.PosX ] is Grass_2))
                {
                    EAT(Game,go.PosX, go.PosY + speed);
                }
                Game.CurrentField.Cells[go.PosY + speed][go.PosX] = go;
                go.PosY = go.PosY + speed;
                return;
            }
        }

        public bool Do(Game Game_field)
        {
            if (energy > 0)
            {
                Walk(Game_field);
            }
            energy -= 1;
            if (energy > Game_field.Settings.AnimalBaseEnergy + 2)
            {
                Reproduce(Game_field);
            }
            if (energy <= 0)
                Die(Game_field);

            return false;
        }

        public void Die(Game game)
        {

            if (DieIteration >= 0)
            {
                DieIteration -= 1;
                Icon = 'X';
            }
            else
            {
                game.CurrentField.DeleteCell(PosX, PosY);

                for (int i = PosY - 1; i <= PosY + 1; i++)
                {
                    for (int j = PosX - 1; j <= PosX + 1; j++)
                    {
                        if (j > -1 && i > -1)
                        {
                            if (j < game.CurrentField.XLenght && i < game.CurrentField.YLenght)
                            {
                                if (!(game.CurrentField.Cells[i][j] is Grass) || !(game.CurrentField.Cells[i][j] is Grass_2))
                                    game.CurrentField.AddCell(new Grass_2(j, i));
                            }
                        }
                    }
                }
            }
        }
    }
}
