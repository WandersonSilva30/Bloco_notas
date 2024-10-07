using System.Windows.Forms.Design;

namespace Bloco_notas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filename;

        private void buttonAbri_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var reult = ofd.ShowDialog(this);
            filename = ofd.FileName;
            if (reult == DialogResult.OK)
            {
                string text = File.ReadAllText(filename);
                textBoxConteudo.Text = text;
                labelNomeDoArquivo.Text = filename;
            }
        }

        private void buttonSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                var result = sfd.ShowDialog(this);
                if (result == DialogResult.OK) return;

                filename = sfd.FileName;
                labelNomeDoArquivo.Text = filename;
                if (!File.Exists(filename)) File.Create(filename).Close();
            }

            File.WriteAllText(filename, textBoxConteudo.Text);
            MessageBox.Show("Arquivo salvo com sucesso.");
        }

        private void buttonEncriptar_Click(object sender, EventArgs e)
        {
            string textoEncriptado = "";
            foreach (char c in textBoxConteudo.Text)
            {
                textoEncriptado += (char)(c + 4);
            }
            textBoxConteudo.Text = textoEncriptado;
        }

        private void buttonDesencriptar_Click(object sender, EventArgs e)
        {
            string textoDesencriptado = "";
            foreach (char c in textBoxConteudo.Text) 
            {
               textoDesencriptado += (char)(c - 4);
            }
            textBoxConteudo.Text = textoDesencriptado;
        }
    }
}
