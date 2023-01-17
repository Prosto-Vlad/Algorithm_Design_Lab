using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        List<Dice> P1_deck = new List<Dice>();
        int p1_rerol = 0;
        int p1_score = 0;
        int p1_vic = 0;
        List<Dice> P2_deck = new List<Dice>();
        int p2_rerol = 0;
        int p2_score = 0;
        int p2_vic = 0;
        int max_hod = 3;
        int raund = 1;

        bool isPlayer;
        public Form1()
        {
            InitializeComponent();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                Dice temp1 = new Dice(0);
                P1_deck.Add(temp1);

                Dice temp2 = new Dice(0);
                P2_deck.Add(temp2);
            }

            isPlayer = true;
            upd_dices();
        }

        private void upd_dices()
        {
            switch (P1_deck[0].Num)
            {
                case 1:
                    P1_dice1.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P1_dice1.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P1_dice1.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P1_dice1.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P1_dice1.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P1_dice1.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P1_deck[1].Num)
            {
                case 1:
                    P1_dice2.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P1_dice2.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P1_dice2.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P1_dice2.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P1_dice2.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P1_dice2.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P1_deck[2].Num)
            {
                case 1:
                    P1_dice3.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P1_dice3.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P1_dice3.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P1_dice3.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P1_dice3.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P1_dice3.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P1_deck[3].Num)
            {
                case 1:
                    P1_dice4.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P1_dice4.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P1_dice4.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P1_dice4.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P1_dice4.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P1_dice4.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P1_deck[4].Num)
            {
                case 1:
                    P1_dice5.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P1_dice5.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P1_dice5.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P1_dice5.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P1_dice5.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P1_dice5.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }


            switch (P2_deck[0].Num)
            {
                case 1:
                    P2_dice1.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P2_dice1.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P2_dice1.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P2_dice1.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P2_dice1.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P2_dice1.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P2_deck[1].Num)
            {
                case 1:
                    P2_dice2.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P2_dice2.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P2_dice2.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P2_dice2.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P2_dice2.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P2_dice2.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P2_deck[2].Num)
            {
                case 1:
                    P2_dice3.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P2_dice3.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P2_dice3.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P2_dice3.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P2_dice3.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P2_dice3.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P2_deck[3].Num)
            {
                case 1:
                    P2_dice4.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P2_dice4.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P2_dice4.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P2_dice4.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P2_dice4.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P2_dice4.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }
            switch (P2_deck[4].Num)
            {
                case 1:
                    P2_dice5.Image = Image.FromFile(@"..\\..\\img\\D1.jpg");
                    break;
                case 2:
                    P2_dice5.Image = Image.FromFile(@"..\\..\\img\\D2.jpg");
                    break;
                case 3:
                    P2_dice5.Image = Image.FromFile(@"..\\..\\img\\D3.jpg");
                    break;
                case 4:
                    P2_dice5.Image = Image.FromFile(@"..\\..\\img\\D4.jpg");
                    break;
                case 5:
                    P2_dice5.Image = Image.FromFile(@"..\\..\\img\\D5.jpg");
                    break;
                case 6:
                    P2_dice5.Image = Image.FromFile(@"..\\..\\img\\D6.jpg");
                    break;
                default:
                    break;
            }

            p1_score = calcScore(true);
            ScorePlayerBox.Text = p1_score.ToString();
            p2_score = calcScore(false);
            ScoreAIBox.Text = p2_score.ToString();
        }

        private void Rerol()
        {
            if (p1_rerol < max_hod && isPlayer)
            {
                Random rand = new Random();
                if (dice1rel.Checked == true)
                {
                    P1_deck[0].Num = rand.Next(1,6);
                }
                if (dice2rel.Checked == true)
                {
                    P1_deck[1].Num = rand.Next(1, 6);
                }
                if (dice3rel.Checked == true)
                {
                    P1_deck[2].Num = rand.Next(1, 6);
                }
                if (dice4rel.Checked == true)
                {
                    P1_deck[3].Num = rand.Next(1, 6);
                }
                if (dice5rel.Checked == true)
                {
                    P1_deck[4].Num = rand.Next(1, 6);
                }
                p1_rerol++;
                upd_dices();
            }
            if (p2_rerol < max_hod && !isPlayer)
            {
                Random rand = new Random();
                for (int i = 0; i < 5; i++)
                {
                    P2_deck[i].Num = rand.Next(1, 6);
                }
                p2_rerol++;
                upd_dices();
            }
        }

        private void AI_hod()
        {
            p1_score = calcScore(true);
            ScorePlayerBox.Text = p1_score.ToString();
            p2_score = calcScore(false);
            ScoreAIBox.Text = p2_score.ToString();
            for (int i = 0; i < max_hod; i++)
            {
                if(p2_score < p1_score)
                    Rerol();
            }
            isPlayer = true;
            p2_rerol = 0;
            raund++;
            RaundBox.Text = raund.ToString();


            if (p1_score > p2_score)
            {
                p1_vic++;
                PlayerVic.Text = p1_vic.ToString();
            }
            if (p2_score > p1_score) 
            {
                p2_vic++;
                AIVict.Text = p2_vic.ToString();
            }
            p1_score = 0;
            p2_score = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(raund == 1)
            {
                max_hod = p1_rerol;
                RerolBox.Text = p1_rerol.ToString();
            }
            
            isPlayer= false;
            p1_rerol = 0;
            AI_hod();
        }

        private void RerolButton_Click(object sender, EventArgs e)
        {
            Rerol();
        }

        private int calcScore(bool is_play)
        {
            int[] dice = new int[6];
            int score = 0;
            if (is_play)
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (P1_deck[i].Num)
                    {
                        case 1:
                            dice[0]++;
                            break;
                        case 2:
                            dice[1]++;
                            break;
                        case 3:
                            dice[2]++;
                            break;
                        case 4:
                            dice[3]++;
                            break;
                        case 5:
                            dice[4]++;
                            break;
                        case 6:
                            dice[5]++;
                            break;
                        default:
                            break;
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    if (dice[i] == 2)
                    {
                        bool dom = false;
                        for (int j = 0; j < 6; j++)
                        {
                            if (dice[i] == 3 && j != i)
                            {
                                score += 35;
                                dom = true;
                                break;
                            }
                        }
                        if (dom == false)
                        {
                            score += 10;
                        }
                    }
                    if (dice[i] == 3)
                    {
                        bool dom = false;
                        for (int j = 0; j < 6; j++)
                        {
                            if (dice[i] == 2 && j!=i)
                            {
                                score += 35;
                                dom = true;
                                break;
                            }
                        }
                        if (dom == false)
                        {
                            score += 30;
                        }

                    }
                    if (dice[i] == 4)
                    {
                        score += 40;
                    }
                    if (dice[i] == 5)
                    {
                        score += 50;
                    }

                }
                return score;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    switch (P2_deck[i].Num)
                    {
                        case 1:
                            dice[0]++;
                            break;
                        case 2:
                            dice[1]++;
                            break;
                        case 3:
                            dice[2]++;
                            break;
                        case 4:
                            dice[3]++;
                            break;
                        case 5:
                            dice[4]++;
                            break;
                        case 6:
                            dice[5]++;
                            break;
                        default:
                            break;
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    if (dice[i] == 2)
                    {
                        bool dom = false;
                        for (int j = 0; j < 6; j++)
                        {
                            if (dice[i] == 3 && j != i)
                            {
                                score += 35;
                                dom = true;
                                break;
                            }
                        }
                        if (dom == false)
                        {
                            score += 10;
                        }
                    }
                    if (dice[i] == 3)
                    {
                        bool dom = false;
                        for (int j = 0; j < 6; j++)
                        {
                            if (dice[i] == 2 && j != i)
                            {
                                score += 35;
                                dom = true;
                                break;
                            }
                        }
                        if (dom == false)
                        {
                            score += 30;
                        }

                    }
                    if (dice[i] == 4)
                    {
                        score += 40;
                    }
                    if (dice[i] == 5)
                    {
                        score += 50;
                    }

                }
                return score;
            }
        }
    }
}
