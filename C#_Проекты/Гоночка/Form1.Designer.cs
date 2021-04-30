namespace WindowsFormsApp22
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.NewGame = new System.Windows.Forms.PictureBox();
            this.StartGame = new System.Windows.Forms.PictureBox();
            this.PauseGame = new System.Windows.Forms.PictureBox();
            this.GameOption = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameOption)).BeginInit();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NewGame.BackgroundImage")));
            this.NewGame.Location = new System.Drawing.Point(681, 22);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(202, 86);
            this.NewGame.TabIndex = 4;
            this.NewGame.TabStop = false;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // StartGame
            // 
            this.StartGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartGame.BackgroundImage")));
            this.StartGame.Location = new System.Drawing.Point(681, 114);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(202, 86);
            this.StartGame.TabIndex = 5;
            this.StartGame.TabStop = false;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // PauseGame
            // 
            this.PauseGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PauseGame.BackgroundImage")));
            this.PauseGame.Location = new System.Drawing.Point(681, 206);
            this.PauseGame.Name = "PauseGame";
            this.PauseGame.Size = new System.Drawing.Size(202, 86);
            this.PauseGame.TabIndex = 6;
            this.PauseGame.TabStop = false;
            this.PauseGame.Click += new System.EventHandler(this.PauseGame_Click);
            // 
            // GameOption
            // 
            this.GameOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GameOption.BackgroundImage")));
            this.GameOption.Location = new System.Drawing.Point(681, 298);
            this.GameOption.Name = "GameOption";
            this.GameOption.Size = new System.Drawing.Size(202, 86);
            this.GameOption.TabIndex = 7;
            this.GameOption.TabStop = false;
            this.GameOption.Click += new System.EventHandler(this.GameOption_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.GameOption);
            this.Controls.Add(this.PauseGame);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.NewGame);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PauseGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox NewGame;
        private System.Windows.Forms.PictureBox StartGame;
        private System.Windows.Forms.PictureBox PauseGame;
        private System.Windows.Forms.PictureBox GameOption;
    }
}

