using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_velha
{
    public partial class Form1 : Form
    {
        bool xis = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            botao11.Click += new EventHandler(botaoClick);
            botao12.Click += new EventHandler(botaoClick);
            botao13.Click += new EventHandler(botaoClick);
            botao21.Click += new EventHandler(botaoClick);
            botao22.Click += new EventHandler(botaoClick);
            botao23.Click += new EventHandler(botaoClick);
            botao31.Click += new EventHandler(botaoClick);
            botao32.Click += new EventHandler(botaoClick);
            botao33.Click += new EventHandler(botaoClick);

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.TabStop = false;
                }

            }

        }
        private void botaoClick(object sende, EventArgs e)
        {
            ((Button)sende).Text = this.xis ? "X" : "O";
            ((Button)sende).Enabled = false;

            VerificarGanhador();
            xis = !xis;

            label1.Text = string.Format("{0}, é a sua vez", this.xis ? "X" : "O");

        }
        private void VerificarGanhador()
        {
            if (
                botao11.Text != String.Empty && botao11.Text == botao12.Text && botao12.Text == botao13.Text ||
                botao21.Text != String.Empty && botao21.Text == botao22.Text && botao22.Text == botao23.Text ||
                botao31.Text != String.Empty && botao31.Text == botao32.Text && botao32.Text == botao33.Text ||

                botao11.Text != String.Empty && botao11.Text == botao21.Text && botao21.Text == botao31.Text ||
                botao12.Text != String.Empty && botao12.Text == botao22.Text && botao22.Text == botao32.Text ||
                botao13.Text != String.Empty && botao13.Text == botao23.Text && botao23.Text == botao33.Text ||

                botao11.Text != String.Empty && botao11.Text == botao22.Text && botao22.Text == botao33.Text ||
                botao13.Text != String.Empty && botao13.Text == botao22.Text && botao22.Text == botao31.Text 
               )
                
            {
                MessageBox.Show(String.Format("O ganhador é o {0}", this.xis ? "X" : "O"), "Temos um Ganhador", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Reiniciar();
            }
            else
            {
                VerificarEmpate();
            }
            }
            private void VerificarEmpate()
             {
            bool todosDesabilitados = true;
            foreach (Control item in this.Controls)
            {
                if (item is Button && item. Enabled)
                {
                    todosDesabilitados = false;
                    break;
                }
            }
               if (todosDesabilitados)
            {
                MessageBox.Show(String.Format("Empatou"), "Opps!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reiniciar();
            }
            }
                private void Reiniciar()
                {
                    foreach (Control item in this.Controls)
                 {
                     if (item is Button)
                {
                    item.Enabled = true;
                    item.Text = String.Empty;
                }
                  }

                  }
              
           

        }
    }
    

  
   

