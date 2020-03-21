using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidacaoCPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text;

            if(cpf.Trim().Length != 11)
            {
                MessageBox.Show("Insira um valor com 11 dígitos sem espaços", "Problema!",
                    MessageBoxButtons.OK);
                txtCpf.Focus();
                return;
            }

            if (cpf.Equals("11111111111") || cpf.Equals("22222222222") ||
                cpf.Equals("33333333333") || cpf.Equals("44444444444") ||
                cpf.Equals("55555555555") || cpf.Equals("66666666666") ||
                cpf.Equals("77777777777") || cpf.Equals("88888888888") ||
                cpf.Equals("99999999999"))
            {
                resultadoValidacao.Text = "CPF Inválido";
                return;
            }

            bool isNumeric = true;
            char[] charsCpf = cpf.ToCharArray();

            foreach(var datachar in charsCpf)
            {
                isNumeric = isNumeric ? char.IsDigit(datachar) : false;
            }

            if (!isNumeric)
            {
                MessageBox.Show("Insira um valor numérico sem espaço em branco", "Problema!",
                    MessageBoxButtons.OK);
                txtCpf.Focus();
                return;
            }

            short digito1 = short.Parse(charsCpf[0].ToString());
            short digito2 = short.Parse(charsCpf[1].ToString());
            short digito3 = short.Parse(charsCpf[2].ToString());
            short digito4 = short.Parse(charsCpf[3].ToString());
            short digito5 = short.Parse(charsCpf[4].ToString());
            short digito6 = short.Parse(charsCpf[5].ToString());
            short digito7 = short.Parse(charsCpf[6].ToString());
            short digito8 = short.Parse(charsCpf[7].ToString());
            short digito9 = short.Parse(charsCpf[8].ToString());
            short digito10 = short.Parse(charsCpf[9].ToString());
            short digito11 = short.Parse(charsCpf[10].ToString());

            int soma9Digitos = (digito1 * 10) + (digito2 * 9) + (digito3 * 8) +
                (digito4 * 7) + (digito5 * 6) + (digito6 * 5) + (digito7 * 4) +
                (digito8 * 3) + (digito9 * 2);

            int resultado1 = (soma9Digitos * 10) % 11;

            resultado1 = resultado1 != 10 ? resultado1 : resultado1 = 0;

            if(resultado1 != digito10)
            {
                resultadoValidacao.Text = "CPF Inválido";
            }
            else
            {
                int soma10Digitos = (digito1 * 11) + (digito2 * 10) + (digito3 * 9) +
                    (digito4 * 8) + (digito5 * 7) + (digito6 * 6) + (digito7 * 5) +
                    (digito8 * 4) + (digito9 * 3) + (digito10 * 2);

                int resultado2 = (soma10Digitos * 10) % 11;

                resultado2 = resultado2 != 10 ? resultado2 : resultado2 = 0;

                if(resultado2 != digito11)
                {
                    resultadoValidacao.Text = "CPF Inválido";
                }
                else
                {
                    resultadoValidacao.Text = "CPF Válido";
                }
            }

        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {
            resultadoValidacao.Text = "Resultado";
        }
    }
}
