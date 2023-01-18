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
        private bool[] reroled_dice = new bool[5] {false, false, false, false, false};
        private int score = 0;
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

        public List<Dice> Deck { get { return deck; } set { deck = value; } }
        public int Score { get { return score; } set { score = value; } }

        public bool[] Reroled_dice { get { return reroled_dice;} set { reroled_dice = value;} }

    }
}
