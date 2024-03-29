﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dotskin_Triangle
{
    public partial class Triangle : Form
    {
        private TextBox textBoxA; //обьявояем элементы
        private TextBox textBoxB;
        private TextBox textBoxC;
        private Button btnDraw;
        private Button btnDrawDef;
        private Label infoA;
        private Label infoB;
        private Label infoC;
        private Label infoTupp;
        private ListBox kolmnurkInf;
        private Button btnClear;
        private Button btnShow;



        PictureBox pb;
        public Triangle()//конструктор
        {
            this.Text = "Kolmnurk";

            InitializeComponent();
            createAll();
        }

        private void createAll() //
        {



            this.BackColor = Color.White;

            textBoxA = new TextBox();       //поле ввода размера 
            textBoxA.Location = new Point(220, 310-50);
            textBoxA.Size = new Size(150, 25);
            textBoxA.BackColor = Color.LightGray; this.ForeColor = Color.DarkGray;
            textBoxA.ForeColor = Color.Black;

            infoA=new Label(); //подпист
            infoA.Location = new Point(220,310-63);
            infoA.ForeColor = Color.Black;
            infoA.Text = "A pool";


            textBoxB = new TextBox();
           
            textBoxB.Location = new Point(220, 340-50);
            textBoxB.Size = new Size(150, 25);
            textBoxB.BackColor = Color.LightGray; this.ForeColor = Color.DarkGray;
            textBoxB.ForeColor = Color.Black;

            infoB = new Label();
            infoB.Location = new Point(220, 340 - 63);
            infoB.ForeColor = Color.Black;
            infoB.Text = "B pool";


            textBoxC = new TextBox();
          
            textBoxC.Location = new Point(220, 370 - 50);
            textBoxC.Size = new Size(150, 25);
            textBoxC.BackColor = Color.LightGray; this.ForeColor = Color.DarkGray;
            textBoxC.ForeColor = Color.Black;

            infoC = new Label();
            infoC.Location = new Point(220, 370 - 63);
            infoC.ForeColor = Color.Black;
            infoC.Text = "C pool";



            btnDraw = new Button(); //ЗАПУСК
            btnDraw.Text = "Käivitada";
            btnDraw.Width = 100;
            btnDraw.Height = 100;
            btnDraw.Location = new Point(610,40);
            btnDraw.Click += btnDraw_Click;
            btnDraw.MouseDoubleClick += btnDraw_DoubleClick;
            btnDraw.BackColor = Color.Green;
            btnDraw.ForeColor = Color.Black;

            btnShow = new Button(); //ЗАПУСК 2
            btnShow.Text = "Kolmnurk 2";
            btnShow.Width = 100;
       
            btnShow.Location = new Point(610, 200);
            btnShow.Click += btnDraw_DoubleClick;
          
            btnShow.BackColor = Color.Yellow;
            btnShow.ForeColor = Color.Black;

            //btnDrawDef = new Button();
            //btnDrawDef.Text = "Määrata vaikesuurus";
            //btnDrawDef.Width = 100;
            //btnDrawDef.Location = new Point(610, 10);
            //btnDrawDef.Click += btnDrawDef_Click;
            //btnDrawDef.BackColor = Color.Green;
            //btnDrawDef.ForeColor = Color.Yellow;


            btnClear = new Button(); //пнопка очистки
            btnClear.Text = "Emalda";
            btnClear.Width = 100;
            btnClear.Location = new Point(610,150);
            btnClear.Click += btnClear_Click;
            btnClear.BackColor = Color.Red;
            btnClear.ForeColor = Color.Black;

            kolmnurkInf = new ListBox(); //листбокс для всей информации 
            kolmnurkInf.Location = new Point(10, 10);
            kolmnurkInf.Size = new Size(300, 200);
            kolmnurkInf.BackColor = Color.LightGray; this.ForeColor = Color.DarkGray;
            kolmnurkInf.ForeColor = Color.Black;

            infoTupp = new Label(); //просто подпись что это
            infoTupp.Location = new Point(10, kolmnurkInf.Bottom + 25);
            infoTupp.ForeColor = Color.Black;
            infoTupp.Text = "Kolmnurke tüpp";

            pb = new PictureBox(); //пб для картинки типа треугольника
            pb.Location = new Point(10, kolmnurkInf.Bottom + 40); 
            pb.Size = new Size(200, 140);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;

            Controls.Add(btnClear);//добавляем все элементы
            Controls.Add(pb);
            Controls.Add(kolmnurkInf);
            Controls.Add(textBoxA);
            Controls.Add(textBoxB);
            Controls.Add(textBoxC);
            Controls.Add(btnDraw);
            Controls.Add(infoA);
            Controls.Add(infoB);
            Controls.Add(infoC  );
            Controls.Add(infoTupp);
            Controls.Add(btnShow);
            //Controls.Add(btnDrawDef);
        }

        private void btnClear_Click(object sender, EventArgs e)//очистка
        {
            Invalidate();
            kolmnurkInf.Items.Clear();
            pb.Image = null; 
            textBoxA.Text= null;
            textBoxB.Text= null;
            textBoxC.Text= null;
        }
        //private void btnDrawDef_Click(object sender, EventArgs e)
        //{
        //    isDefault = true;

        //}
        private void btnDraw_DoubleClick(object sender, EventArgs e)
        {
            Triangle2 triangle2 = new Triangle2();
            triangle2.Show();
        }
            private void btnDraw_Click(object sender, EventArgs e)
        {

            // Получаем значения из полей
            double pointA, pointB, pointC;
            if (double.TryParse(textBoxA.Text, out pointA) && double.TryParse(textBoxB.Text, out pointB) && double.TryParse(textBoxC.Text, out pointC))
            //если поля заполнены
            {
                // Проверка возможен ли треугольник по его сторонам
                if (pointA + pointB > pointC && pointA + pointC > pointB && pointB + pointC > pointA)
                {
                    //очищаем информацию
                    kolmnurkInf.Items.Clear();

                    


                    showFullInfo(pointA, pointB, pointC); //вызываем функцию отображдения инфы передавая аргументы точек
                }
                else
                {MessageBox.Show("Võimatu kolmnurk!");} //если треугольник невозможен
            }
            else
            {
                MessageBox.Show("Tühjed väljad!");//если пустые поля
            }
        }
        private void showFullInfo(double pointA, double pointB, double pointC)
        {
            //создаем обьект тругольник для вычислений
            Triangle_ triangle = new Triangle_(pointA, pointB, pointC, true);

            //добавляем картинку в пиктчур бокс в зависимости от типа
            if (triangle.IsEquilateral())
            { pb.Image = new Bitmap("../../../Dotskin_Triangle/fullequal.png"); }

            else if (triangle.IsIsosceles())
            { pb.Image = new Bitmap("../../../Dotskin_Triangle/equal.png"); }

            else if (triangle.IsScalene())
            { pb.Image = new Bitmap("../../../Dotskin_Triangle/noeq.jpg"); }


            //стороны
            kolmnurkInf.Items.Add($"A= {pointA}");
            kolmnurkInf.Items.Add($"B= {pointB}");
            kolmnurkInf.Items.Add($"C= {pointC}");
            //существует ли 
            kolmnurkInf.Items.Add($"Kas on? {triangle.ExistTriangle}");
            //периметр
            kolmnurkInf.Items.Add($"Perimeter {triangle.Perimeter()}");
            //площадь
            kolmnurkInf.Items.Add($"Pindala {triangle.Surface()}");
            //высота
            kolmnurkInf.Items.Add($"Kõrgus {triangle.OutputH()}");
            //равносторонний ли
            kolmnurkInf.Items.Add($"Võrdkülne? {triangle.IsEquilateral()}");
            //равнобедренный ли
            kolmnurkInf.Items.Add($"Võrdhaarne? {triangle.IsIsosceles()}");
            //разносторонний
            kolmnurkInf.Items.Add($"Erikülne? {triangle.IsScalene()}");
        }


    }
}
