using Cadastro_de_cliente.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_cliente.Maps
{
    class Cadastro_maps : Utils

    {
        public string btnNovo = "//a[@class='btn btn-xs btn-success']";
        public string campoInscricao = "//input[@id='inscricao']";
        public string campoApelido = "//input[@id='Apelido']";
        public string campoNome = "//input[@id='nome']";
        public string campoFoto = "//input[@id='foto']";
        public string btnCadastrar = "//input[@type='submit']";
        public string cabecalhoInicio = "//h1[text()='Clientes']";
        public string btnVoltar = "//a[@class='btn btn-default']";
        public string cabecalhoCadastro = "//h1[text()='Cadastrar cliente']";
        public string dropdownStatus = "//select[@id='status']";
        public string aba46 = "//a[text()='46']";
        public string editarEmail = "//a[@href='/clientes/editar/429']";
        public string nomeEmail = "//div[@class='custom-modal-content']/div/div/input[@id='nome']";
        public string enderecoEmail = "//input[@id='email']";
        public string categoriaEmail = "//select[@id='categoria']";
        public string btnFechar = "//div[@class='form-group']/a[@class='btn btn-default']";
        public string btnCadastraremail = "//input[@value='Cadastrar']";
        public string btnAtualizar = "//input[@value='Editar']";
        public string edicaoCliente = "//h1[text()='Editar cliente']";
    }
}
