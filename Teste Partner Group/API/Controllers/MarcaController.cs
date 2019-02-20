using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using API.DataAcess;

namespace API.Controllers
{
    public class MarcaController : ApiController
    {
        //seleciona uma marca
        public IEnumerable<Marca> Get()
        {
            var _ado = new ADO(); //nova instancia do ADO
            return _ado.ListarMarca(); // metodo na classe ado para listar
        }

        public Marca Get(int numero)
        {
            var _ado = new ADO(); //nova instancia do ADO
            return _ado.MarcaSelecionada(numero); //metodo da classe ado para buscar selecionado
        }

        public void Post([FromBody] Marca marca)
        {
            var _ado = new ADO(); //nova instancia do ADO
            _ado.CadastrarMarca(marca); //metodo da classe ado para cadastrar
        }

        public void Put(int numero, [FromBody]Marca marca)
        {
            var _ado = new ADO(); //nova instancia do ADO
            Marca marcaselecionada = _ado.MarcaSelecionada(numero);
            marcaselecionada.Nome = marca.Nome;
            _ado.EditarMarca(marca);
        } //edita registros do patrimonio selecionado

        public void Delete(int numero)
        {
            var _ado = new ADO();
            _ado.DeletarMarca(numero);
        }
    }
}