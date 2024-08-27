using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Metro1
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
            MakeTable();
        }

        public void MakeTable()
        {
            
            StringBuilder strings = new StringBuilder();
            int operand_lines = 0;
            int operators_lines = 0;
            using (StreamReader sr = new StreamReader("operands.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    strings.AppendLine(sr.ReadLine() + '-');
                    operand_lines++;
                }
            }

            string[] operand_arr = (strings.ToString()).Split('-');
            Console.WriteLine(operand_arr.Length);
            strings.Clear();

            using (StreamReader sr = new StreamReader("operators.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    strings.AppendLine(sr.ReadLine() + ' ');
                    operators_lines++;
                }
            }

            string[] operators_arr = (strings.ToString()).Split(' ');
            Console.WriteLine(operators_arr.Length);
            strings.Clear();
            int colCount = 6;
            int rowCount = (operators_lines > operand_lines ? operators_lines : operand_lines) + 2;
                      
            for(int i = 0; i < rowCount - 1; i++)
            {
                Table1DGV.Rows.Add();
            }

            for (int i = 1; i < operators_lines; i++)
                {
                    int j = (i - 1) * 2;                    
                    Table1DGV.Rows[i - 1].Cells[0].Value = i.ToString() + '.';
                    Table1DGV.Rows[i - 1].Cells[1].Value = operators_arr[j];
                    Table1DGV.Rows[i - 1].Cells[2].Value = operators_arr[j + 1];
            }

                for (int i = 1; i < operand_lines; i++)
                {
                    int j = (i - 1) * 2;
                    Table1DGV.Rows[i - 1].Cells[3].Value = i.ToString() + '.';
                    Table1DGV.Rows[i - 1].Cells[4].Value = operand_arr[j];
                    Table1DGV.Rows[i - 1].Cells[5].Value = operand_arr[j + 1];                 
                    
                }

                int amountOfOperators = 0;
                int amountOfOperands = 0;

                for (int i = 1; i < operand_lines * 2; i += 2)
                {
                    amountOfOperands += Int32.Parse(operand_arr[i]);
                }

                for (int i = 1; i < operators_lines * 2; i += 2)
                {
                    amountOfOperators += Int32.Parse(operators_arr[i]);
                }

                Table1DGV.Rows[rowCount - 1].Cells[0].Value = "Кол-во операторов";
                Table1DGV.Rows[rowCount - 1].Cells[3].Value = "Кол-во операндов";
                Table1DGV.Rows[rowCount - 1].Cells[2].Value = amountOfOperators.ToString();
                Table1DGV.Rows[rowCount - 1].Cells[5].Value = amountOfOperands.ToString();

                int programDictionary = operators_lines + operand_lines;
                int programLength = amountOfOperands + amountOfOperators;
                int programSize = programLength * (int)Math.Log(programDictionary, 2);


                Finishlabel.Text = "Словарь программы = " + programDictionary.ToString() + "\nДлинна программы = " + programLength.ToString() + "\nОбъем программы = " + programSize;               

            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 newForm = new Form1();                       
            newForm.Show();
        }
    }
}
