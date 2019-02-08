using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{                                               
    // Sterowanie -  W A S D, Strzał - Spacja, Start i Restart - Enter                                          
    public partial class Form1 : Form             
    {
        bool goLeft, goRight, goUp, goDown;
        bool isPressed;
        bool isPressedEn;
        int playerSpeed = 10;
        int wave = 1;
        int yBullet1 = 0;
        int yBullet2 = 95;
        int yBullet3x = 158;
        int yBullet3y = 32;
        int xBulletBoss = 126;
        int bosx;
        int bosy;
        public Form1()
        {
            InitializeComponent();
        }
        // Sterowanie statkiem gracza
        private void Key_Down(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.A)
            {
                if (Player.Location.X < 0)
                {
                    goLeft = false;
                    Player.Image = Properties.Resources.PlayerLeft;
                    
                }
                else
                    goLeft = true;
                Player.Image = Properties.Resources.PlayerLeft;
            }
            if (e.KeyCode == Keys.D)
            {
                if (Player.Location.X > 837)
                {
                    goRight = false;
                    Player.Image = Properties.Resources.PlayerRight;
                }
                else
                    goRight = true;
                Player.Image = Properties.Resources.PlayerRight;
            }
            if (e.KeyCode == Keys.W)
                if (Player.Location.Y < 0)
                    goUp = false;
                else
                    goUp = true;
            if (e.KeyCode == Keys.S)
                if (Player.Location.Y > 483)
                    goDown = false;
                else
                    goDown = true;
            // Strzał na spacji
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;               
                makeBullet(2);
            }
            // Restart programu
            if(e.KeyCode == Keys.Enter && !isPressed)
            {
                isPressedEn = true;
                timer1.Enabled = true;
                timer1.Start();
                wave1timer.Enabled = true;
                wave1timer.Start();
                label2.Visible = false;                
                if (label2.Text == "Game Over" || label2.Text == "You Won")
                    Application.Restart();
            }
        }
        // Przerwanie sterowania statkiem gracza
        private void Key_Up(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
                Player.Image = Properties.Resources.Player;


            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
                Player.Image = Properties.Resources.Player;

            }
            if (e.KeyCode == Keys.W)
                goUp = false;
            if (e.KeyCode == Keys.S)
                goDown = false;
            // Strzał na spacji
            if (isPressed)
                isPressed = false;
            if (isPressedEn)
                isPressedEn = false;
        }
        // Główny Timer do kierowania graczem, definiuje szybkość statku gracza
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goLeft)
                Player.Left -= playerSpeed;
            if (goRight)
                Player.Left += playerSpeed;
            if (goUp)
                Player.Top -= playerSpeed;
            if (goDown)
                Player.Top += playerSpeed;

            // Sprawdzenie kolizji statku gracza ze statkiem przeciwnika
            foreach (Control x in this.Controls)
                if (x is PictureBox && x.Tag == "enemy" || x.Tag == "enemy5" || x.Tag == "enemy-5" || x.Tag == "boss")
                    if (((PictureBox)x).Bounds.IntersectsWith(Player.Bounds))
                        gameOver();
            // Sprawdzenie kolizji pocisku gracza ze statkiem przeciwnika
            foreach (Control i in this.Controls)
                foreach (Control j in this.Controls)
                    if (i is PictureBox && i.Tag == "enemy")
                        if (j is PictureBox && j.Tag == "bullet")
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                this.Controls.Remove(i);
                                // Pociski znikają wraz z przeciwnikiem
                                this.Controls.Remove(j);
                                
                                switch (i.Name) 
                                {
                                    case "60":
                                        enemyAlive = false;
                                        break;
                                    case "190":
                                        enemyAlive1 = false;
                                        break;
                                    case "125":
                                        enemyAlive2 = false;
                                        break;
                                    case "760":
                                        enemyAlive3 = false;
                                        break;
                                    case "630":
                                        enemyAlive4 = false;
                                        break;
                                    case "695":
                                        enemyAlive5 = false;
                                        break;
                                    case "350":
                                        enemyAlive6 = false;
                                        break;
                                    case "470":
                                        enemyAlive7 = false;
                                        break;
                                    case "300":
                                        enemyAlive8 = false;
                                        break;
                                    case "520":
                                        enemyAlive9 = false;
                                        break;
                                    case "10":
                                        enemyAlive10 = false;
                                        break;
                                    case "800":
                                        enemyAlive11 = false;
                                        break;
                                    case "410":
                                        enemyAlive12 = false;
                                        break;
                                    case "433":
                                        enemy1Alive = false;
                                        break;
                                    case "573":
                                        enemy1Alive1 = false;
                                        break;
                                    case "293":
                                        enemy1Alive2 = false;
                                        break;
                                    case "223":
                                        enemy1Alive4 = false;
                                        break;
                                    case "793":
                                        enemy1Alive5 = false;
                                        break;
                                    case "73":
                                        enemy1Alive6 = false;
                                        break;
                                    case "490":
                                        enemy1Alive7 = false;
                                        break;
                                    case "351":
                                        enemy1Alive8 = false;
                                        break;
                                    case "140":
                                        enemy1Alive9 = false;
                                        break;
                                    case "700":
                                        enemy1Alive10 = false;
                                        break;
                                }
                            }
            // Sprawdzenie kolizji pocisku gracza ze statkiem przeciwnika
            foreach (Control i in this.Controls)
                foreach (Control j in this.Controls)
                    if (i is PictureBox && i.Tag == "enemy5" || i.Tag == "enemy-5" || i.Tag == "boss")
                        if (j is PictureBox && j.Tag == "bullet")
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                this.Controls.Remove(j);
                                // Usuwanie po jednym punkcie życia przy trafieniu przeciwnika przez gracza
                                switch(i.Name)
                                {
                                    case "52": enemy5Alive -= 1;
                                        break;
                                    case "192":
                                        enemy5Alive1 -= 1;
                                        break;
                                    case "122":
                                        enemy5Alive2 -= 1;
                                        break;
                                    case "262":
                                        enemy5Alive3 -= 1;
                                        break;
                                    case "353":                                                                      
                                        bossAlive -= 1;
                                        break;
                                }
                                // Sprawdzenie który przeciwnik został trafiony
                                if (enemy5Alive == 0 && i.Name == "52")
                                    this.Controls.Remove(i);
                                if (enemy5Alive1 == 0 && i.Name == "192")
                                    this.Controls.Remove(i);
                                if (enemy5Alive2 == 0 && i.Name == "122")
                                    this.Controls.Remove(i);
                                if (enemy5Alive3 == 0 && i.Name == "262")
                                    this.Controls.Remove(i);
                                if (bossAlive == 0 && i.Name == "353")
                                {
                                    this.Controls.Remove(i);
                                    Win();
                                }
                            }
             // Trafienie pocisku przeciwnika w statek gracza                 
             foreach (Control i in this.Controls)
                foreach (Control j in this.Controls)
                    if (i is PictureBox && i.Tag == "main")
                        if (j is PictureBox && j.Tag == "bulletEnemy")
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                this.Controls.Remove(j);
                                gameOver();
                            }
            // Animacja pocisku gracza
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 20;
                    if (((PictureBox)y).Top < -20)
                        this.Controls.Remove(y);
                }
            }
            // Animacja pocisku przeciwnika
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "bulletEnemy")
                {
                    y.Top += 10; // Szybkość pocisków przeciwnika
                    if (((PictureBox)y).Top > 570 || ((PictureBox)y).Top < -50)
                        this.Controls.Remove(y);
                }
            }
            // Ruch przeciwnika
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "enemy")
                {
                    ((PictureBox)x).Top += 3;
                    if (((PictureBox)x).Top > 600)
                        this.Controls.Remove(x);
                }
            }
            // Ruch przeciwnika
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "enemy5")
                {
                    ((PictureBox)x).Left += 5;
                    ((PictureBox)x).Top += 1;
                    if (((PictureBox)x).Left > 1200)
                        this.Controls.Remove(x);
                }
            }
            // Ruch przeciwnika
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "enemy-5")
                {
                    ((PictureBox)x).Left -= 5;
                    ((PictureBox)x).Top += 1;
                    if (((PictureBox)x).Left < 0)
                        this.Controls.Remove(x);
                }
            }
            // Ruch Bossa
            foreach (Control x in this.Controls)                                
            {
                if (x is PictureBox && x.Tag == "boss")
                {
                    if (((PictureBox)x).Top < 15)
                        ((PictureBox)x).Top += 1;
                    if (((PictureBox)x).Left == 2)
                        ((PictureBox)x).Top += 1;
                    if (((PictureBox)x).Left == 418)
                        ((PictureBox)x).Top -= 1;
                    if (((PictureBox)x).Top == 15)
                        ((PictureBox)x).Left -= 2;                    
                    if (((PictureBox)x).Top == 16)
                        ((PictureBox)x).Left += 2;                   
                }
            }
            // Granice ruchu statku gracza
            if (Player.Location.X < 0)
                goLeft = false;
            if (Player.Location.X > 837)
                goRight = false;
            if (Player.Location.Y < 0)
                goUp = false;
            if (Player.Location.Y > 480)
                goDown = false;
        }
        // Reset pozycji pocisku przeciwnika
        public void BulletMoveWave1(object sender, EventArgs e)
        {
            if (yBullet1 < 600)
                yBullet1 += 95;
        }
        // Reset pozycji pocisku przeciwnika
        public void BulletMoveWave2(object sender, EventArgs e)
        {
            if (yBullet2 < 600)
                yBullet2 += 95;
        }
        // Reset pozycji pocisku przeciwnika
        public void BulletMoveWave3(object sender, EventArgs e)
        {
            if (yBullet3x < 1300)
                yBullet3x += 158;
            if (yBullet3y < 600)
                yBullet3y += 32;
        }
        // Reset pozycji pocisku Bossa
        public void BulletMoveWaveBoss(object sender, EventArgs e)                                        
        {
            foreach (Control x in this.Controls)
            {
               if (x is PictureBox && x.Tag == "boss")
                {
                        bosx = ((PictureBox)x).Location.X;
                        bosy = ((PictureBox)x).Location.Y;                    
                }
            }
        }
        // Przeciwnicy w pierwszej fali
        private void Wave1_Timer(object sender, EventArgs e)
        {
            if (wave == 1)
            {
                enemy(60, -20);
                enemy(190, -20);
                enemy(125, -90);
                enemy(760, -20);
                enemy(630, -20);
                enemy(695, -90);
                enemy(350, -20);
                enemy(470, -20);
                enemy(300, -130);
                enemy(520, -130);
                enemy(10, -100);
                enemy(800, -100);
                enemy(410, -100);
            }
            wave = 2;
            wave1timer.Stop();
            wave2timer.Enabled = true;
            enemyBulletTimer.Tick += new EventHandler(BulletMoveWave1);
        }
        // Przeciwnicy w drugiej fali
        private void Wave2_Timer(object sender, EventArgs e)
        {
            if (wave == 2)
            {
                enemy3(430, -100);
                enemy3(570, -100);
                enemy3(290, -100);
                enemy3(220, -120);
                enemy3(790, -100);
                enemy3(70, -100);
                enemy(490, -100);
                enemy(351, -100);
                enemy(140, -70);
                enemy(700, -70);
            }
            wave = 3;
            wave2timer.Stop();
            wave3timer.Enabled = true;
            enemyBulletTimer.Tick += new EventHandler(BulletMoveWave2);
        }
        // Przeciwnicy w trzeciej fali
        private void Wave3_Timer(object sender, EventArgs e)
        {
            if (wave == 3)
            {
                enemy5(-100, 50);
                enemy5(-100, 190);
                enemy5minus(1000, 120);
                enemy5minus(1000, 260);
            }
            wave = 4;
            wave3timer.Stop();
            waveBoss.Enabled = true;
            enemyBulletTimer.Tick += new EventHandler(BulletMoveWave3);
        }
        // Boss w ostatniej fali
        private void waveBoss_Tick(object sender, EventArgs e)                        
        {
            if(wave == 4)
            {
                boss(350, -300);
            }
            wave = 5;
            waveBoss.Stop();
            enemyBulletTimer.Tick += new EventHandler(BulletMoveWaveBoss);
        }
        // Pozycje z których wylatuje pocisk przeciwnika
        private void enemy_bullet_timer(object sender, EventArgs e)
        {
            // Wave 1
            if (wave == 2 && enemyAlive)
                bulletEnemyGreenBig(60, -10 + yBullet1);
            if (wave == 2 && enemyAlive1)
                bulletEnemyGreenBig(190, -10 + yBullet1);
            if (wave == 2 && enemyAlive2)
                bulletEnemyGreenBig(125, -80 + yBullet1);
            if (wave == 2 && enemyAlive3)
                bulletEnemyGreenBig(760, -10 + yBullet1);
            if (wave == 2 && enemyAlive4)
                bulletEnemyGreenBig(630, -10 + yBullet1);
            if (wave == 2 && enemyAlive5)
                bulletEnemyGreenBig(695, -80 + yBullet1);
            if (wave == 2 && enemyAlive6)
                bulletEnemyGreenBig(350, -10 + yBullet1);
            if (wave == 2 && enemyAlive7)
                bulletEnemyGreenBig(470, -10 + yBullet1);
            if (wave == 2 && enemyAlive8)
                bulletEnemyGreenBig(300, -120 + yBullet1);
            if (wave == 2 && enemyAlive9)
                bulletEnemyGreenBig(520, -120 + yBullet1);
            if (wave == 2 && enemyAlive10)
                bulletEnemyGreenBig(10, -90 + yBullet1);
            if (wave == 2 && enemyAlive11)
                bulletEnemyGreenBig(800, -90 + yBullet1);
            if (wave == 2 && enemyAlive12)
                bulletEnemyGreenBig(410, -90 + yBullet1);
            // Wave 2
            if (wave == 3 && enemy1Alive)
                bulletEnemyGreenTall(430, -130 + yBullet2);
            if (wave == 3 && enemy1Alive1)
                bulletEnemyGreenTall(570, -130 + yBullet2);
            if (wave == 3 && enemy1Alive2)
                bulletEnemyGreenTall(290, -130 + yBullet2);
            if (wave == 3 && enemy1Alive4)
                bulletEnemyGreenTall(220, -150 + yBullet2);
            if (wave == 3 && enemy1Alive5)
                bulletEnemyGreenTall(790, -130 + yBullet2);
            if (wave == 3 && enemy1Alive6)
                bulletEnemyGreenTall(70, -130 + yBullet2);
            if (wave == 3 && enemy1Alive7)
                bulletEnemyGreenBig(490, -130 + yBullet2);
            if (wave == 3 && enemy1Alive8)
                bulletEnemyGreenBig(351, -130 + yBullet2);
            if (wave == 3 && enemy1Alive9)
                bulletEnemyGreenBig(140, -100 + yBullet2);
            if (wave == 3 && enemy1Alive10)
                bulletEnemyGreenBig(700, -100 + yBullet2);
            // Wave 3
            if (wave == 4 && enemy5Alive > 0)
                bulletEnemyLazer2(-100+25+yBullet3x, 30+yBullet3y);
            if (wave == 4 && enemy5Alive > 0)
                bulletEnemyLazer2(-100+50+yBullet3x, 30+yBullet3y);
            if (wave == 4 && enemy5Alive > 0)
                bulletEnemyLazer2(-100+yBullet3x, 30+yBullet3y);
            if (wave == 4 && enemy5Alive1 > 0)
                bulletEnemyLazer2(-100+yBullet3x, 170+yBullet3y);
            if (wave == 4 && enemy5Alive1 > 0)
                bulletEnemyLazer2(-100+25+yBullet3x, 170+yBullet3y);
            if (wave == 4 && enemy5Alive1 > 0)
                bulletEnemyLazer2(-100+50+yBullet3x, 170+yBullet3y);
            if (wave == 4 && enemy5Alive2 > 0)
                bulletEnemyLazer2(1000 - yBullet3x, 100 + yBullet3y);
            if (wave == 4 && enemy5Alive2 > 0)
                bulletEnemyLazer2(1000 + 25 - yBullet3x, 100 + yBullet3y);
            if (wave == 4 && enemy5Alive2 > 0)
                bulletEnemyLazer2(1000 + 50 - yBullet3x, 100 + yBullet3y);
            if (wave == 4 && enemy5Alive3 > 0)
                bulletEnemyLazer2(1000 - yBullet3x, 240 + yBullet3y);
            if (wave == 4 && enemy5Alive3 > 0)
                bulletEnemyLazer2(1000 + 25 - yBullet3x, 240 + yBullet3y);
            if (wave == 4 && enemy5Alive3 > 0)
                bulletEnemyLazer2(1000 + 50 - yBullet3x, 240 + yBullet3y);
            // Pociski Bossa
            if (wave == 5 && bossAlive > 0)                                                        
            {
                if (bosy == 0)
                {

                }
                else
                {
                    bulletEnemyGreenBig(bosx + 205, bosy + 270);
                    bulletEnemyGreenBig(bosx + 215, bosy + 270);
                    bulletEnemyGreenTall(bosx + 45, bosy + 170);
                    bulletEnemyGreenTall(bosx + 435, bosy + 170);
                    bulletEnemyLazer2(bosx + 5, bosy + 170);
                    bulletEnemyLazer2(bosx + 475, bosy + 170);
                }
            }
        }
        // Zdefiniowanie hitboxa pocisku gracza
        private void makeBullet(int n)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet_main;
            bullet.Size = new Size(6, 20);
            bullet.SizeMode = PictureBoxSizeMode.Zoom;
            bullet.Tag = "bullet";
            bullet.Left = Player.Left - 3 + Player.Width * n / 4;
            bullet.Top = Player.Top - 20;
            bullet.BackColor = Color.Transparent;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
        // Zdefiniowanie hitboxa pocisku przeciwnika
        private void bulletEnemyGreenBig(int x, int y)
        {
            PictureBox bulletEnGrBig = new PictureBox();
            bulletEnGrBig.Image = Properties.Resources.lazer3;
            bulletEnGrBig.Size = new Size(10, 20);
            bulletEnGrBig.SizeMode = PictureBoxSizeMode.Zoom;
            bulletEnGrBig.Tag = "bulletEnemy";
            bulletEnGrBig.Location = new Point(x + 30, y + 60);
            bulletEnGrBig.BackColor = Color.Transparent;
            this.Controls.Add(bulletEnGrBig);
            bulletEnGrBig.BringToFront();
        }
        // Zdefiniowanie hitboxa pocisku przeciwnika
        private void bulletEnemyGreenTall(int x, int y)
        {
            PictureBox bulletEnGrTall = new PictureBox();
            bulletEnGrTall.Image = Properties.Resources.lazer1;
            bulletEnGrTall.Size = new Size(26, 50);
            bulletEnGrTall.SizeMode = PictureBoxSizeMode.StretchImage;
            bulletEnGrTall.Tag = "bulletEnemy";
            bulletEnGrTall.Location = new Point(x + 13, y + 100);
            bulletEnGrTall.BackColor = Color.Transparent;
            this.Controls.Add(bulletEnGrTall);
            bulletEnGrTall.BringToFront();
        }
        // Zdefiniowanie hitboxa pocisku przeciwnika
        private void bulletEnemyLazer2(int x, int y)
        {
            PictureBox bulletEnL2 = new PictureBox();
            bulletEnL2.Image = Properties.Resources.lazer2;
            bulletEnL2.Size = new Size(10, 55);
            bulletEnL2.SizeMode = PictureBoxSizeMode.StretchImage;
            bulletEnL2.Tag = "bulletEnemy";
            bulletEnL2.Location = new Point(x, y+71);
            bulletEnL2.BackColor = Color.Transparent;
            this.Controls.Add(bulletEnL2);
            bulletEnL2.BringToFront();
        }
        // Zdefiniowanie hitboxa statku przeciwnika
        public void enemy(int x, int y)
        {
            PictureBox enemy = new PictureBox();
            enemy.Image = Properties.Resources.enemy;
            enemy.Size = new Size(70, 60);
            enemy.SizeMode = PictureBoxSizeMode.Zoom;
            enemy.Tag = "enemy";
            enemy.Location = new Point(x, y);
            this.Controls.Add(enemy);
            enemy.BringToFront();
            enemy.BackColor = Color.Transparent;
            enemy.Name = Convert.ToString(x);
        }
        // Zdefiniowanie hitboxa statku przeciwnika
        public void enemy3(int x, int y)
        {
            PictureBox enemy3 = new PictureBox();
            enemy3.Image = Properties.Resources.enemy3;
            enemy3.Size = new Size(50, 100);
            enemy3.SizeMode = PictureBoxSizeMode.Zoom;
            enemy3.Tag = "enemy";
            enemy3.Location = new Point(x, y);
            this.Controls.Add(enemy3);
            enemy3.BringToFront();
            enemy3.BackColor = Color.Transparent;
            enemy3.Name = Convert.ToString(x + 3);
        }
        // Zdefiniowanie hitboxa statku przeciwnika
        public void enemy5(int x, int y)
        {
            PictureBox enemy5 = new PictureBox();
            enemy5.Image = Properties.Resources.enemy5;
            enemy5.Size = new Size(100, 70);
            enemy5.SizeMode = PictureBoxSizeMode.Zoom; 
            enemy5.Tag = "enemy5";
            enemy5.Location = new Point(x, y);
            enemy5.BackColor = Color.Transparent;
            this.Controls.Add(enemy5);
            enemy5.BringToFront();
            enemy5.Name = Convert.ToString(y + 2);
        }
        // Zdefiniowanie hitboxa statku przeciwnika
        public void enemy5minus(int x, int y)
        {
            PictureBox enemy5min = new PictureBox();
            enemy5min.Image = Properties.Resources.enemy5;
            enemy5min.Size = new Size(100, 70);
            enemy5min.SizeMode = PictureBoxSizeMode.Zoom;
            enemy5min.Tag = "enemy-5";
            enemy5min.Location = new Point(x, y);
            enemy5min.BackColor = Color.Transparent;
            this.Controls.Add(enemy5min);
            enemy5min.BringToFront();
            enemy5min.Name = Convert.ToString(y + 2);
        }
        // Zdefiniowanie hitboxa statku Bossa
        public void boss(int x, int y)                                       
        {
            PictureBox boss = new PictureBox();
            boss.Image = Properties.Resources.Boss;
            boss.Size = new Size(490, 306);
            boss.SizeMode = PictureBoxSizeMode.CenterImage;
            boss.Tag = "boss";
            boss.Location = new Point(x, y);          
            boss.BackColor = Color.Transparent;
            this.Controls.Add(boss);
            boss.BringToFront();
            boss.Name = Convert.ToString(x + 3);
        }

        // Ilość puntków życia przecinwików
        public bool enemyAlive = true;
        public bool enemyAlive1 = true;
        public bool enemyAlive2 = true;
        public bool enemyAlive3 = true;
        public bool enemyAlive4 = true;
        public bool enemyAlive5 = true;
        public bool enemyAlive6 = true;
        public bool enemyAlive7 = true;
        public bool enemyAlive8 = true;
        public bool enemyAlive9 = true;
        public bool enemyAlive10 = true;
        public bool enemyAlive11 = true;
        public bool enemyAlive12 = true;

        public bool enemy1Alive = true;
        public bool enemy1Alive1 = true;
        public bool enemy1Alive2 = true;
        public bool enemy1Alive3 = true;
        public bool enemy1Alive4 = true;
        public bool enemy1Alive5 = true;
        public bool enemy1Alive6 = true;
        public bool enemy1Alive7 = true;
        public bool enemy1Alive8 = true;
        public bool enemy1Alive9 = true;
        public bool enemy1Alive10 = true;

        public int enemy5Alive =  2;
        public int enemy5Alive1 = 2;
        public int enemy5Alive2 = 2;
        public int enemy5Alive3 = 2;
        // Ilość punktów życia Bossa
        public int bossAlive = 10;                                            

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        // Funkcja GameOver
        private void gameOver()
        {
            timer1.Stop();
            wave1timer.Stop();
            enemyBulletTimer.Stop();
            wave2timer.Stop();
            wave3timer.Stop();
            label2.Visible = true;
            label2.BringToFront();
            label2.Left = 375;
            label2.Text = "Game Over";
        }
        //Funkcja Win
        private void Win()
        {
            timer1.Stop();
            wave1timer.Stop();
            enemyBulletTimer.Stop();
            wave2timer.Stop();
            wave3timer.Stop();
            waveBoss.Stop();
            label2.Visible = true;
            label2.BringToFront();
            label2.Left = 375;
            label2.Text = "You Won";
        }        
    }
}
