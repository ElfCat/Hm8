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

namespace SApp03
{
    public partial class MainForm : Form
    {

        private TrueFalse database;


        public MainForm()
        {
            InitializeComponent();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Новый файл
        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(saveFileDialog.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }

        //Открыть
        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFileDialog.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;

                if(database.Count != 0)
                {
                    tbQuestion.Text = database[0].Text;
                    cbTrue.Checked = database[0].TrueFalse;
                }
            }
        }

        //Сохранить меню
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.Save();
                MessageBox.Show("База данных сохранена", "Сообщение");
            }
            else
            {
                MessageBox.Show("Создайте новую базу данных", "Предупреждение");
            }
        }
        //Сохранить как
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            if (database != null)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    database.FileName = saveFileDialog.FileName;
                    database.Save();
                    MessageBox.Show("База данных сохранена", "Сообщение");
                }
            }
            else
            {
                MessageBox.Show("Откройте базу данных для сохранения как", "Предупреждение");
            }
        }

        //Изменеие значения numeric up down
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"{ex.Message}", "Предупреждение");
            }
        }

        //Довавить
        private void addButton_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Предупреждение");
                return;
            }

            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        //Удалить
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (database == null || nudNumber.Maximum == 1)
            {
                MessageBox.Show("No database to remove", "Предупреждение");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                database.Remove((int)nudNumber.Value - 1);
                nudNumber.Maximum--;
                if (nudNumber.Value > 1)
                {
                    nudNumber.Value = nudNumber.Value;
                }
            }

        }

        //Сохраненить кнопка
        private void saveButton_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
            database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Верю — не верю\nвер. 1\n03.01.2021\nАвтор: Петяева София", "О программе");
        }

        private void cbTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Ошибка");
            }
        }
    }
}
