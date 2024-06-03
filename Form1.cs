using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practico_Matrices
{
    public partial class Form1 : Form
    {
        classMatriz objM1, objM2, objM3;

        private void Form1_Load(object sender, EventArgs e)
        {
            objM1 = new classMatriz();
            objM2 = new classMatriz();
            objM3 = new classMatriz();
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Text = objM1.getDate();
        }

        private void mtzInfeIzqXFilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.mtzExtremInferior(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox5.Text = objM1.getDate();
        }

        private void pregunta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(objM1.operaElemPrimos());
        }

        private void ordenamientoMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.ordenMatriz();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int fila, colum;
            fila = 0; colum = 0;
            objM1.frecuenMaxMatriz(ref fila, ref colum);
            textBox7.Text = string.Concat("Elem. es: " + fila + " Frecu. es: " + colum);
        }

        private void pregunta3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int number;
            number = 0;
            objM1.elemNoRepet(ref number);
            textBox7.Text = string.Concat("Elem. No Repet. = " + number);
        }

        private void pregunta4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.cargarFiboSnake(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            textBox5.Text = objM1.getDate();
        }

        private void pregunta5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(objM1.verifOrdenFilas());
        }

        private void pregunta6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.elemMayEnCol();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(objM1.verifOrdenRigor1());
        }

        private void matrizSerie1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.serieMatriz1(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            textBox5.Text = objM1.getDate();
        }

        private void pregunta8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(objM1.verifMatEnMat(objM2));
        }

        private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox6.Text = objM2.getDate();
        }

        private void descargarToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM2.setDateRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void cargarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            objM3.setDateRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void pregunta9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.segmentarParImpar();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.verifPrimFil();
            objM1.ordenFilaxFila();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM1.segmentFrecuxRang();
            textBox6.Text = objM1.getDate();
        }

        private void frecuenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Concat(objM1.frecuMatriz(int.Parse(textBox1.Text)));
        }

        private void pregunta2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM1.matrizSnakeJake();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM1.ordenTriangSuperior();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta6ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM1.ordenDiagonalSegun();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM1.mayorEnColum();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM1.interElemFibo();
            textBox6.Text = objM1.getDate();
        }

        private void pregunta5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            objM1.segmentarMatrizParImpar();
            textBox6.Text = objM1.getDate();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objM1.setDateRandom(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }
    }
}
