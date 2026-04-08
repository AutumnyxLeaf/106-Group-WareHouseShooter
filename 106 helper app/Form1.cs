using System.IO;

namespace _106_helper_app
{
    public partial class Form1 : Form
    {
        //set up file stream FileStream
        FileStream partFile = new FileStream("GunEditorFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);


        // Stats are created here for ease
        
        public Form1()
        {
            InitializeComponent();
        }

        //Save button Important!!!
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //When clicked it will pull up a new open file dialog and import a sprite to replace the old one
        private void GunSpriteStock_Click(object sender, EventArgs e)
        {

            // modified from example code of windows forms

            string filePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    GunPartSprite.Image = Image.FromFile(filePath);
                }

            }
        }

        //Import button PLEASE REMEMBER
        private void button1_Click_1(object sender, EventArgs e)
        {
            string filePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    string[] fileContent = File.ReadAllLines(filePath);
                }



            }
        }
        //ignore
        private void ExitButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
