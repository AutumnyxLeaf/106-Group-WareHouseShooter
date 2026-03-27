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
            SaveButton = new Button();
            GunPartSprite = new PictureBox();
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
            GunPartSprite.Location = new Point(282, 150);
            GunPartSprite.Name = "GunPartSprite";
            GunPartSprite.Size = new Size(228, 140);
            GunPartSprite.TabIndex = 1;
            GunPartSprite.TabStop = false;
            GunPartSprite.Click += GunSpriteStock_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GunPartSprite);
            Controls.Add(SaveButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)GunPartSprite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button SaveButton;
        private PictureBox GunPartSprite;
    }
}
