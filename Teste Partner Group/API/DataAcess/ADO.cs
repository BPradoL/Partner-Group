using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using API.Models;


namespace API.DataAcess
{
    public class ADO
    {
        string _stringConexao = @"Data Source=.;Initial Catalog=DbControlePatrimonio;Integrated Security=True";

        public List<Patrimonio>ListarPatrimonios() //lista todos os patrimonios
        {
            var tabela = new DataTable(); //datatable para jogar o resultado do comando
            var patrimonios = new List<Patrimonio>(); //lista para jogar os patrimonios
            using (var conexao = new SqlConnection(_stringConexao)) //declaro a variavel para a conexao
            {
                conexao.Open(); //abro a conexao
                using (var cmd = new SqlCommand()) //declado a variavel para o comando
                {
                    cmd.CommandType = CommandType.Text; //tipo do comando texto
                    cmd.CommandText = "select * from tbPatrimonio"; //comando no sql
                    cmd.Connection = conexao; //qual a conexao
                    using (var da = new SqlDataAdapter()) //dataadapter para jogar o resultado no datatable
                    {
                        da.SelectCommand = cmd;
                        da.Fill(tabela); //joga o resultado no datatable
                    }
                }
                foreach(DataRow linha in tabela.Rows) //para cada linha encontrada no datatable...
                {
                    patrimonios.Add(new Patrimonio
                    {
                        MarcaId = Convert.ToInt32(linha["MarcaId"].ToString()),
                        Nome = linha["Nome"].ToString(),
                        Descricao = linha["Descricao"].ToString(),
                        NTombo = Convert.ToInt32(linha["NTombo"].ToString())
                    }); //jogo na lista do patrimonio
                }
            }
            return patrimonios; //retorna  a lista dos patrimonios
        }
        public Patrimonio PatrimonioSelecionado(int numero) //lista um patrimonio selecionado
        {
            var tabela = new DataTable();
            var patrimonio = new Patrimonio();
            using(var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                using(var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from tbPatrimonio where MarcaId = "+ numero;
                    cmd.Connection = conexao;
                    using(var da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(tabela);
                    }
                }
                foreach(DataRow linha in tabela.Rows)
                {
                    patrimonio.MarcaId = Convert.ToInt32(linha["MarcaId"]);
                    patrimonio.Nome = linha["Nome"].ToString();
                    patrimonio.Descricao = linha["Descricao"].ToString();
                    patrimonio.NTombo = Convert.ToInt32(linha["NTombo"]);
                }
            }
            return patrimonio;
        }
        public void CadastrarPatrimonio(Patrimonio novopatrimonio)
        {
            using(var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                using(var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"insert into tbPatrimonio
                                        VALUES('"+novopatrimonio.MarcaId+","+novopatrimonio.Nome+","+novopatrimonio.Descricao+
                                        novopatrimonio.NTombo+"')";
                    cmd.Connection = conexao;
                    cmd.ExecuteNonQuery();
                }
            }
        } //cadastra um novo patrimonio
        public void EditarPatrimonio(Patrimonio patrimonioselecionado)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                using(var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"update tbPatrimonio
                    set MarcaId = "+patrimonioselecionado.MarcaId+", set Nome = "+patrimonioselecionado.Nome+",set Descricao = "+
                    patrimonioselecionado.Descricao+" where NTombo = "+ patrimonioselecionado.NTombo;
                    cmd.Connection = conexao;
                    cmd.ExecuteNonQuery();
                }
            }
        } //edita um patrimonio existente
        public void DeletarPatrimonio(int numero)
        {
            using(var conexao = new SqlConnection(_stringConexao))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"delete from tbPatrimonio
                                       where MarcaId = "+ numero;
                    cmd.Connection = conexao;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<Marca> ListarMarca() //lista todas as marcas
        {
            var tabela = new DataTable(); //datatable para jogar o resultado do comando
            var marcas = new List<Marca>(); //lista para jogar as marcar
            using (var conexao = new SqlConnection(_stringConexao)) //declaro a variavel para a conexao
            {
                conexao.Open(); //abro a conexao
                using (var cmd = new SqlCommand()) //declado a variavel para o comando
                {
                    cmd.CommandType = CommandType.Text; //tipo do comando texto
                    cmd.CommandText = "select * from tbMarca"; //comando no sql
                    cmd.Connection = conexao; //qual a conexao
                    using (var da = new SqlDataAdapter()) //dataadapter para jogar o resultado no datatable
                    {
                        da.SelectCommand = cmd;
                        da.Fill(tabela); //joga o resultado no datatable
                    }
                }
                foreach (DataRow linha in tabela.Rows) //para cada linha encontrada no datatable...
                {
                    marcas.Add(new Marca
                    {
                        MarcaId = Convert.ToInt32(linha["MarcaId"].ToString()),
                        Nome = linha["Nome"].ToString(),
                    }); //jogo na lista da marca
                }
            }
            return marcas; //retorna  a lista das marcar
        }
        public Marca MarcaSelecionada(int numero) //lista uma marca selecionada
        {
            var tabela = new DataTable();
            var marca = new Marca();
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from tbMarca where MarcaId = " + numero;
                    cmd.Connection = conexao;
                    using (var da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(tabela);
                    }
                }
                foreach (DataRow linha in tabela.Rows)
                {
                    marca.MarcaId = Convert.ToInt32(linha["MarcaId"]);
                    marca.Nome = linha["Nome"].ToString();
                }
            }
            return marca;
        }
        public void CadastrarMarca(Marca novamarca)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $@"insert into tbMarca
                                        VALUES('" + novamarca.MarcaId + "," + novamarca.Nome + "')";
                    cmd.Connection = conexao;
                    cmd.ExecuteNonQuery();
                }
            }
        } //cadastra uma nova marca
        public void EditarMarca(Marca marcaselecionada)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"update tbMarca
                    set MarcaId = " + marcaselecionada.MarcaId + ", set Nome = " + marcaselecionada.Nome + 
                    " where MarcaId = " + marcaselecionada.MarcaId;
                    cmd.Connection = conexao;
                    cmd.ExecuteNonQuery();
                }
            }
        } //edita uma marca existente
        public void DeletarMarca(int numero)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from tbMarca where MarcaId = " + numero;
                    cmd.Connection = conexao;
                    cmd.ExecuteNonQuery();
                }
            }
        }  //deletar uma marca existente
    }
}