using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoIntegradorBiblioteca
{
    public partial class CadastroAutor : Form
    {
        public CadastroAutor()
        {
            InitializeComponent();
        }

        private void autorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.autorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bibliotecaDataSet);

        }

        private void CadastroAutor_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bibliotecaDataSet.autor'. Você pode movê-la ou removê-la conforme necessário.
            this.autorTableAdapter.Fill(this.bibliotecaDataSet.autor);

        }

        private void autorDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
