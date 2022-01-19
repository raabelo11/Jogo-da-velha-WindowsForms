using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;

        bool turno = true, jogoFinal = false;
        string[] texto = new string[9];

        private void btn_clean_Click(object sender, EventArgs e)
        {

            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";

            rodadas = 0;
            jogoFinal = false;

            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogoFinal == false)
            {

                if (turno)
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    ChecagemVitoria(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    ChecagemVitoria(2);
                }
            }
        }

        void Vencedor(int PlayerVencedor)
        {
            jogoFinal = true;

            if(PlayerVencedor == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador X ganhou !");
                turno = true;
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O ganhou !");
                turno = false;
            }
        }

        void ChecagemVitoria(int ChecagemPlayer)
        {
            string suporte = "";

            if (ChecagemPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] &&
                        texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
                }

            }//fim loop

            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] &&
                        texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(ChecagemPlayer);
                        return;
                    }
                }

            }

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {

                    Vencedor(ChecagemPlayer);
                    return;
                }

            }

            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {

                    Vencedor(ChecagemPlayer);
                    return;
                }

            }

            if(rodadas == 9 && jogoFinal == false)
            {
                empatesPontos++;
                empates.Text = Convert.ToString(empatesPontos);
                MessageBox.Show("EMPATE");
                jogoFinal = true;
                return;
            }

        }// fim método

    }
}
