namespace AgendaContatosC
{
    public partial class Form1 : Form
    {

        private List<Contatos> contatos = new List<Contatos>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            string nome = txtNome.Text;
            string telefone = txtTelefone.Text;
            string email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
            {
                MessageBox.Show("Nome e telefone são obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Contatos novoContato = new Contatos(nome, telefone, email);
            contatos.Add(novoContato);
            AtualizarListaContatos();
            LimparCampos();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (listBoxContatos.SelectedIndex >= 0)
            {
                Contatos contatoSelecionado = contatos[listBoxContatos.SelectedIndex];
                contatoSelecionado.Nome = txtNome.Text;
                contatoSelecionado.Telefone = txtTelefone.Text;
                contatoSelecionado.Email = txtEmail.Text;
                AtualizarListaContatos();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Selecione um contato para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

            if (listBoxContatos.SelectedIndex >= 0)
            {
                contatos.RemoveAt(listBoxContatos.SelectedIndex);
                AtualizarListaContatos();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Selecione um contato para remover.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxContatos.SelectedIndex >= 0)
            {
                Contatos contatoSelecionado = contatos[listBoxContatos.SelectedIndex];
                txtNome.Text = contatoSelecionado.Nome;
                txtTelefone.Text = contatoSelecionado.Telefone;
                txtEmail.Text = contatoSelecionado.Email;
            }

        }

        private void AtualizarListaContatos()
        {
            listBoxContatos.Items.Clear();
            foreach (var contato in contatos)
            {
                listBoxContatos.Items.Add(contato.ToString());
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
        }
    }
}


