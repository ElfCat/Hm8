using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SApp03
{
    public partial class BNB : Form
    {
        private TrueFalse database;
        public int count = 0;
        public int countA = 0;

        public static Question LoadQuestion(string fileName)
        {
            XmlSerializer xm = new XmlSerializer(typeof(Question));
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return (xm.Deserialize(stream) as Question);
            }
        }
        public BNB()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnYes.Enabled = true;
            btnNo.Enabled = true;

                database = new TrueFalse(AppDomain.CurrentDomain.BaseDirectory + "hm8.txt");
                database.Load();

                if (database.Count != 0)
                {
                    tbQuestion.Text = database[count].Text;
                }

            quest.Text = "Вопрос #" + (count + 1);
            correctA.Text = "Правильных ответов: " + countA;
            btnPlay.Enabled = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (database[count].TrueFalse)
            {
                correctA.Text = "Правильных ответов: " + (++countA) + " из " + database.Count;
            }
            count++;
            if (count >= database.Count)
            {
                tbQuestion.Text = "Игра завершена";
                quest.Text = " ";
                btnNo.Enabled = false;
                btnYes.Enabled = false;
            }
            else
            {
                tbQuestion.Text = database[count].Text;
                quest.Text = "Вопрос #" + (count + 1);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (!database[count].TrueFalse)
            {
                correctA.Text = "Правильных ответов: " + (++countA) + " из " + database.Count;
            }
            count++;
            if (count >= database.Count)
            {
                tbQuestion.Text = "Игра завершена";
                quest.Text = " ";
                btnNo.Enabled = false;
                btnYes.Enabled = false;
            }
            else
            {
                tbQuestion.Text = database[count].Text;
                quest.Text = "Вопрос #" + (count + 1);
            }
        }
    }
}
