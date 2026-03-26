using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveApp
{
    public partial class Form1 : Form
    {
        private int animationStep = 0;
        private Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple,
                                Color.HotPink, Color.Teal, Color.Brown, Color.Magenta, Color.Cyan };

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Добро пожаловать в интерактивное приложение!",
                "Приветствие",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            label2.Text = "Готов к работе";
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.LightYellow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show(
                    "Пожалуйста, введите имя!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                textBox1.BackColor = Color.LightCoral;
            }
            else
            {
                label2.Text = $"Привет, {textBox1.Text}!";
                textBox1.BackColor = Color.LightGreen;

                MessageBox.Show(
                    $"Рады видеть вас, {textBox1.Text}!",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите очистить поле?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                textBox1.Clear();
                label2.Text = "Очищено";
                textBox1.BackColor = Color.White;
                button2.BackColor = Color.LightGray;
            }
            else
            {
                label2.Text = "Очистка отменена";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button3.Text = "Запустить анимацию";
                button3.BackColor = SystemColors.Control;
                label2.Text = "Анимация остановлена";
            }
            else
            {
                timer1.Start();
                button3.Text = "Остановить анимацию";
                button3.BackColor = Color.LightBlue;
                label2.Text = "Анимация запущена";
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Анимация 1: Меняем цвет label2
            label2.ForeColor = colors[animationStep % colors.Length];

            // Анимация 2: Меняем цвет кнопок
            button1.BackColor = colors[(animationStep + 1) % colors.Length];
            button2.BackColor = colors[(animationStep + 2) % colors.Length];
            button3.BackColor = colors[(animationStep + 3) % colors.Length];

            // Анимация 3: Мерцание фона формы
            if (animationStep % 10 < 5)
                this.BackColor = Color.LightYellow;
            else
                this.BackColor = Color.White;

            // Анимация 4: "Дыхание" текстового поля (меняется ширина)
            if (animationStep % 20 < 10)
                textBox1.Width = 150 + animationStep % 20;

            // Анимация 5: Меняем прозрачность (если хотите поэкспериментировать)
            // this.Opacity = 0.8 + 0.2 * Math.Sin(animationStep * 0.1);

            // Увеличиваем счетчик для следующего шага анимации
            animationStep++;

            // Сбрасываем счетчик, чтобы не было переполнения
            if (animationStep > 1000) animationStep = 0;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Здесь будет код анимации
            // Пока оставьте пустым или добавьте простой код для проверки
            label2.Text = "Тик таймера: " + DateTime.Now.Second;
        }

    }
}
