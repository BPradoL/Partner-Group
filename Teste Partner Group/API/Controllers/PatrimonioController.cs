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
    public class PatrimonioController : ApiController
    {
        
        public IEnumerable<Patrimonio> Get() //seleciona todos os patrimonios
        {
            var _ado = new ADO(); //nova instancia do ADO
            return _ado.ListarPatrimonios(); // metodo na classe ado para listar
        }

        public Patrimonio Get(int numero)
        {
            var _ado = new ADO(); //nova instancia do ADO
            return _ado.PatrimonioSelecionado(numero); //metodo da classe ado para buscar selecionado
        } //seleciona um patrimonio especifico

        public void Post([FromBody] Patrimonio patrimonio)
        {
            var _ado = new ADO(); //nova instancia do ADO
            _ado.CadastrarPatrimonio(patrimonio); //metodo da classe ado para cadastrar
        } //cadastra um patrimonio

        public void Put(int numero,[FromBody]Patrimonio patrimonio)
        {
            var _ado = new ADO(); //nova instancia do ADO
            Patrimonio patrimonioselecionado = _ado.PatrimonioSelecionado(numero); 
            patrimonioselecionado.Nome = patrimonio.Nome;
            patrimonio.NTombo = patrimonio.NTombo;
            patrimonio.Descricao = patrimonio.Descricao;
            _ado.EditarPatrimonio(patrimonio);
        } //edita registros do patrimonio selecionado

        public void Delete(int numero)
        {
            var _ado = new ADO();
            _ado.DeletarPatrimonio(numero);
        } //deleta o patrimonio selecionado
    }
}