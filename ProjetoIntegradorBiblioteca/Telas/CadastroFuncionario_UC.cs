using ProjetoIntegrador_BibliotecasdeClasse;
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
    public partial class CadastroFuncionario_UC : UserControl
    {
        private string CodigoFunc { get; set; }
        public CadastroFuncionario_UC(string func)
        {
            CodigoFunc = func;
            InitializeComponent();
            EscreveTabela();
        }

        private void Lbl_CpfLeitor_Click(object sender, EventArgs e)
        {

        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario l = new Funcionario();
                l = LerFormulario();
                txt_Senha.Enabled = false;
                l.Validacao();
                l.Cadastrar();
                MessageBox.Show("CADASTRO FEITO COM SUCESSO!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO NO CADASTRO:" + ex.Message);
            }
        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {

        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario l = new Funcionario();
                l = LerFormulario();
                l.Codigo = Txt_CodigoFunc.Text;              
                l.Validacao();
                if (l.Codigo != CodigoFunc)
                {
                    txt_Senha.Enabled = true;
                }
                var SQL = l.Update();
                var bd = new MySQLServerClass();
                bd.SQLCommand(SQL);
                MessageBox.Show("Atualização feita com sucesso!");
                EscreveTabela();

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERRO na Atualização!" + ex.Message);
            }
              

        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            
        }


        Funcionario LerFormulario()
        {
            string dn, dia, mes, ano;
            Funcionario l = new Funcionario();

            l.Nome = Txt_NomeFunc.Text;
            l.Cpf = Txt_CpfFunc.Text;
            dia = dtp_NascFunc.Value.Date.Day.ToString();
            mes = dtp_NascFunc.Value.Month.ToString();
            ano = dtp_NascFunc.Value.Year.ToString();
            dn = $"{ano}-{mes}-{dia}";
            l.DataNasc = dn;
            l.Email = Txt_Email.Text;
            l.Telefone = Txt_Telefone.Text;
            l.Cep = Txt_Cep.Text;
            l.Estado = Txt_Estado.Text;
            l.Cidade = Txt_CidadeLeitor.Text;
            l.Bairro = Txt_Bairro.Text;
            l.Rua = Txt_Rua.Text;
            l.Numero = Txt_Numero.Text;
            l.Senha = txt_Senha.Text;

            return l;

        }


        void EscreveFormulario(Funcionario l)
        {
            try
            {
                Txt_CodigoFunc.Text = l.Codigo;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: PRENCHIMENTO FORMÚLARIO" + ex.Message);
            }

            Txt_NomeFunc.Text = l.Nome;
            Txt_CpfFunc.Text = l.Cpf;
            dtp_NascFunc.Text = l.DataNasc;
            Txt_Email.Text = l.Email;
            Txt_Telefone.Text = l.Telefone;
            Txt_Cep.Text = l.Cep;
            Txt_Estado.Text = l.Estado;
            Txt_CidadeLeitor.Text = l.Cidade;
            Txt_Bairro.Text = l.Bairro;
            Txt_Rua.Text = l.Rua;
            Txt_Numero.Text = l.Numero;
            txt_Senha.Text = l.Senha;

        }

        void EscreveTabela()
        {
            string SQL = "select codfunc, nomefunc from cadfunc";
            var bd = new MySQLServerClass();
            var dt = bd.SQLQuery(SQL);
            dtv_fucionarios.Rows.Clear();
            

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtv_fucionarios);
                row.Cells[0].Value = dt.Rows[i]["codfunc"].ToString();
                row.Cells[1].Value = dt.Rows[i]["nomefunc"].ToString();
                dtv_fucionarios.Rows.Add(row);
            }
            
            
        }

        private void Selecionar_Click(object sender, EventArgs e)
        {
            Funcionario l = new Funcionario();
            DataGridViewRow row = dtv_fucionarios.SelectedRows[0];
            var codigo = row.Cells[0].Value.ToString();
            string SQL = $"select * from cadfunc where codfunc = {codigo}";
            
            var bd = new MySQLServerClass();
            var dt = bd.SQLQuery(SQL);
            l = l.DataRowFuncionario(dt);
            EscreveFormulario(l);
            //if (codigo != CodigoFunc)
            //{
            //    txt_Senha.Enabled = false;
            //}
        }
    }
}
