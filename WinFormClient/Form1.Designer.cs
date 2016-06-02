namespace WinFormClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.GenerationLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixedToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.withAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesOnServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.textGrass_2Time_out = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textDeathAnimal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textEnergy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textCloseCells = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textSizeY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textSizeX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GameObjectsLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabSetting);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(991, 514);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.GameObjectsLabel);
            this.tabMain.Controls.Add(this.GenerationLabel);
            this.tabMain.Controls.Add(this.panel1);
            this.tabMain.Controls.Add(this.menuStrip1);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(983, 488);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // GenerationLabel
            // 
            this.GenerationLabel.AutoSize = true;
            this.GenerationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerationLabel.Location = new System.Drawing.Point(628, 59);
            this.GenerationLabel.Name = "GenerationLabel";
            this.GenerationLabel.Size = new System.Drawing.Size(103, 24);
            this.GenerationLabel.TabIndex = 2;
            this.GenerationLabel.Text = "Generation";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(19, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 435);
            this.panel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.gamesOnServerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.newGameToolStripMenuItem.Text = " Game";
            // 
            // startNewToolStripMenuItem
            // 
            this.startNewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standartToolStripMenuItem,
            this.mixedToolStripMenuItem,
            this.mixedToolStripMenuItem1,
            this.withAnimalToolStripMenuItem});
            this.startNewToolStripMenuItem.Name = "startNewToolStripMenuItem";
            this.startNewToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.startNewToolStripMenuItem.Text = "StartNew";
            // 
            // standartToolStripMenuItem
            // 
            this.standartToolStripMenuItem.Name = "standartToolStripMenuItem";
            this.standartToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.standartToolStripMenuItem.Text = "Standart 4.1";
            this.standartToolStripMenuItem.Click += new System.EventHandler(this.standartToolStripMenuItem_Click);
            // 
            // mixedToolStripMenuItem
            // 
            this.mixedToolStripMenuItem.Name = "mixedToolStripMenuItem";
            this.mixedToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.mixedToolStripMenuItem.Text = "Standart 4.2";
            this.mixedToolStripMenuItem.Click += new System.EventHandler(this.mixedToolStripMenuItem_Click);
            // 
            // mixedToolStripMenuItem1
            // 
            this.mixedToolStripMenuItem1.Name = "mixedToolStripMenuItem1";
            this.mixedToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.mixedToolStripMenuItem1.Text = "Mixed";
            this.mixedToolStripMenuItem1.Click += new System.EventHandler(this.mixedToolStripMenuItem1_Click);
            // 
            // withAnimalToolStripMenuItem
            // 
            this.withAnimalToolStripMenuItem.Name = "withAnimalToolStripMenuItem";
            this.withAnimalToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.withAnimalToolStripMenuItem.Text = "WithAnimal";
            this.withAnimalToolStripMenuItem.Click += new System.EventHandler(this.withAnimalToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gamesOnServerToolStripMenuItem
            // 
            this.gamesOnServerToolStripMenuItem.Name = "gamesOnServerToolStripMenuItem";
            this.gamesOnServerToolStripMenuItem.Size = new System.Drawing.Size(120, 21);
            this.gamesOnServerToolStripMenuItem.Text = "Games on Server";
            this.gamesOnServerToolStripMenuItem.Click += new System.EventHandler(this.gamesOnServerToolStripMenuItem_Click);
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.button2);
            this.tabSetting.Controls.Add(this.textGrass_2Time_out);
            this.tabSetting.Controls.Add(this.label7);
            this.tabSetting.Controls.Add(this.textDeathAnimal);
            this.tabSetting.Controls.Add(this.label6);
            this.tabSetting.Controls.Add(this.textSpeed);
            this.tabSetting.Controls.Add(this.label5);
            this.tabSetting.Controls.Add(this.textEnergy);
            this.tabSetting.Controls.Add(this.label4);
            this.tabSetting.Controls.Add(this.button1);
            this.tabSetting.Controls.Add(this.textCloseCells);
            this.tabSetting.Controls.Add(this.label3);
            this.tabSetting.Controls.Add(this.textSizeY);
            this.tabSetting.Controls.Add(this.label2);
            this.tabSetting.Controls.Add(this.textSizeX);
            this.tabSetting.Controls.Add(this.label1);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetting.Size = new System.Drawing.Size(983, 488);
            this.tabSetting.TabIndex = 1;
            this.tabSetting.Text = "Settings";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(26, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 32);
            this.button2.TabIndex = 15;
            this.button2.Text = "RandomStartPreset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textGrass_2Time_out
            // 
            this.textGrass_2Time_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textGrass_2Time_out.Location = new System.Drawing.Point(182, 288);
            this.textGrass_2Time_out.Name = "textGrass_2Time_out";
            this.textGrass_2Time_out.Size = new System.Drawing.Size(42, 22);
            this.textGrass_2Time_out.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(23, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Grass_2TimeOut:";
            // 
            // textDeathAnimal
            // 
            this.textDeathAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textDeathAnimal.Location = new System.Drawing.Point(182, 237);
            this.textDeathAnimal.Name = "textDeathAnimal";
            this.textDeathAnimal.Size = new System.Drawing.Size(42, 22);
            this.textDeathAnimal.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(23, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "AnimalDeathVisible:";
            // 
            // textSpeed
            // 
            this.textSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textSpeed.Location = new System.Drawing.Point(182, 186);
            this.textSpeed.Name = "textSpeed";
            this.textSpeed.Size = new System.Drawing.Size(42, 22);
            this.textSpeed.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "AnimalBaseSpeed:";
            // 
            // textEnergy
            // 
            this.textEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textEnergy.Location = new System.Drawing.Point(182, 136);
            this.textEnergy.Name = "textEnergy";
            this.textEnergy.Size = new System.Drawing.Size(42, 22);
            this.textEnergy.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "AnimalBaseEnergy:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(898, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textCloseCells
            // 
            this.textCloseCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textCloseCells.Location = new System.Drawing.Point(182, 89);
            this.textCloseCells.Name = "textCloseCells";
            this.textCloseCells.Size = new System.Drawing.Size(42, 22);
            this.textCloseCells.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "MaxCloseCellsGrass:";
            // 
            // textSizeY
            // 
            this.textSizeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textSizeY.Location = new System.Drawing.Point(163, 39);
            this.textSizeY.Name = "textSizeY";
            this.textSizeY.Size = new System.Drawing.Size(42, 22);
            this.textSizeY.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(147, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // textSizeX
            // 
            this.textSizeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textSizeX.Location = new System.Drawing.Point(105, 39);
            this.textSizeX.Name = "textSizeX";
            this.textSizeX.Size = new System.Drawing.Size(42, 22);
            this.textSizeX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size Field:";
            // 
            // GameObjectsLabel
            // 
            this.GameObjectsLabel.AutoSize = true;
            this.GameObjectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameObjectsLabel.Location = new System.Drawing.Point(628, 107);
            this.GameObjectsLabel.Name = "GameObjectsLabel";
            this.GameObjectsLabel.Size = new System.Drawing.Size(125, 24);
            this.GameObjectsLabel.TabIndex = 3;
            this.GameObjectsLabel.Text = "GameObjects";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 519);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabSetting.ResumeLayout(false);
            this.tabSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mixedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mixedToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem withAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamesOnServerToolStripMenuItem;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textSizeX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSizeY;
        private System.Windows.Forms.TextBox textCloseCells;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textEnergy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textGrass_2Time_out;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textDeathAnimal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label GenerationLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label GameObjectsLabel;
    }
}

