namespace _106_helper_app
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SaveButton = new Button();
            GunPartSprite = new PictureBox();
            TypeDisplay = new TextBox();
            PictureFileSelect = new FolderBrowserDialog();
            ImportButton = new Button();
            StatsText = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)GunPartSprite).BeginInit();
            SuspendLayout();
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(0, 12);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(136, 84);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += button1_Click;
            // 
            // GunPartSprite
            // 
            GunPartSprite.Image = (Image)resources.GetObject("GunPartSprite.Image");
            GunPartSprite.Location = new Point(245, 41);
            GunPartSprite.Name = "GunPartSprite";
            GunPartSprite.Size = new Size(320, 240);
            GunPartSprite.TabIndex = 1;
            GunPartSprite.TabStop = false;
            GunPartSprite.Click += GunSpriteStock_Click;
            // 
            // TypeDisplay
            // 
            TypeDisplay.Location = new Point(283, 317);
            TypeDisplay.Name = "TypeDisplay";
            TypeDisplay.Size = new Size(227, 27);
            TypeDisplay.TabIndex = 2;
            TypeDisplay.Text = "Type";
            // 
            // ImportButton
            // 
            ImportButton.Location = new Point(0, 102);
            ImportButton.Name = "ImportButton";
            ImportButton.Size = new Size(136, 84);
            ImportButton.TabIndex = 3;
            ImportButton.Text = "Import";
            ImportButton.UseVisualStyleBackColor = true;
            ImportButton.Click += button1_Click_1;
            // 
            // StatsText
            // 
            StatsText.Location = new Point(688, 11);
            StatsText.Multiline = true;
            StatsText.Name = "StatsText";
            StatsText.Size = new Size(116, 317);
            StatsText.TabIndex = 5;
            StatsText.Text = "Sample stats:\r\nfire rate:\r\n\r\nbullet velocity:\r\n\r\nrandom nonsense\r\n";
            StatsText.TextChanged += textBox1_TextChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StatsText);
            Controls.Add(ImportButton);
            Controls.Add(TypeDisplay);
            Controls.Add(GunPartSprite);
            Controls.Add(SaveButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)GunPartSprite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveButton;
        private PictureBox GunPartSprite;
        private TextBox TypeDisplay;
        private FolderBrowserDialog PictureFileSelect;
        private Button ImportButton;
        private TextBox StatsText;
        private OpenFileDialog openFileDialog1;
    }
}
