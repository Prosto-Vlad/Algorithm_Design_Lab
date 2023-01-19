using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Lab6
{
    internal class State
    {
        private List<Dice> deck = new List<Dice>();
        private bool[] reroled_dice = new bool[5] { false, false, false, false, false };
        private double score = 0;
        public State(List<Dice> deck) {
            for (int i = 0; i < 5; i++)
            {
                Dice temp1 = new Dice(0);
                this.deck.Add(temp1);
            }
            for (int i = 0; i < 5; i++)
            {
                this.deck[i].Num = deck[i].Num;
            }
        }

        public State(int[] dices)
        {
            for (int i = 0; i < 5; i++)
            {
                Dice temp1 = new Dice(0);
                this.deck.Add(temp1);
            }

            if (dices[0] == 1)
            {
                reroled_dice[0] = true;
            }
            if (dices[1] == 1)
            {
                reroled_dice[1] = true;
            }
            if (dices[2] == 1)
            {
                reroled_dice[2] = true;
            }
            if (dices[3] == 1)
            {
                reroled_dice[3] = true;
            }
            if (dices[4] == 1)
            {
                reroled_dice[4] = true;
            }
        }

        public State()
        {
            for (int i = 0; i < 5; i++)
            {
                Dice temp1 = new Dice(0);
                this.deck.Add(temp1);
            }
        }

        public List<Dice> Deck { get { return deck; } set { deck = value; } }
        public double Score { get { return score; } set { score = value; } }

        public bool[] Reroled_dice { get { return reroled_dice;} set { reroled_dice = value;} }

    }
}
