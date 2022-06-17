using OpenQA.Selenium;
using Cadastro_de_cliente.Maps;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace Cadastro_de_cliente.Steps
{
   
    [Binding]
    class Inicio : Cadastro_maps
    {
        public string inscricao = "";
        public string nome = "";
        public string apelido = "";
        public string foto = "";
        public string status = "";
        public string nomeUsuario = "";
        public string emailUsuario = "";
        public string emailCategoria = "";

        [Given(@"que acesso o fluxo ""(.*)""")]
            public void AcessoaoSite(string opcao)
            {
            string url = "https://teste-omie.vercel.app/clientes/listar";
                switch (opcao)
            {
                    case "Fluxo inicio":
                        abrirPagina(url);
                        screenshot();
                    break;

                    case "Cadastrar cliente":
                        abrirPagina(url);
                        clicar_Elemento(btnNovo, 10);
                        screenshot();
                        
                    break;

                    case "Fluxo emails":
                        abrirPagina(url);
                        clicar_Elemento(aba46, 10);
                        clicar_Elemento(editarEmail, 10);
                        clicar_Elemento(btnNovo, 10);
                        screenshot();
                        
                    break;

                default:
                    break;

            }
            }

        [Given(@"clico no botao novo")]
            public void clicaBotao()
            {
                 clicar_Elemento(btnNovo, 10);
                 screenshot();
            }

        [Then(@"valido que fui direcionado para o fluxo ""(.*)""")]
            public void validacaoFluxo(string opcao)
            {
            string inicio = "Clientes";
            string cadastro = "Cadastrar cliente";
            switch (opcao)
            {
                case "Inicio":
                    string texto = ArmazenaTexto(cabecalhoInicio, 10);
                    string cabecalho = itemvalidacao(texto);
                    validarFluxo(cabecalho, inicio, 10);
                    screenshot();
                    
                    encerraNavegador();
                    break;

                case "Cadastrar cliente":
                    texto = ArmazenaTexto(cabecalhoCadastro, 10);
                    cabecalho  = itemvalidacao(texto);
                    validarFluxo(cabecalho, cadastro, 10);
                    screenshot();
                    
                    encerraNavegador();
                    break;
                 

                case "Erro":
                    screenshot();
                    
                    Console.WriteLine("Sem pagina de erro");
                    encerraNavegador();
                    break;

                default :
                    break;
            }

            }


        [When(@"preencho os campos com os dados solicitados")]

        public void preencherCampos()
        {
            inscricao = "00192362000121";
            apelido = "Padaria do João";
            nome = "João Silva";
            foto = "https://imgur.com/a/mGFoVGB";
            status = "ATIVADO";

            Preencher_elemento(campoInscricao, inscricao, 10);
            Preencher_elemento(campoApelido, apelido, 10);
            Preencher_elemento(campoNome, nome, 10);
            Preencher_elemento(campoFoto, foto, 10);
            selecionarOpcao(dropdownStatus, status, 10);
            clicar_Elemento(btnCadastrar, 10);
            screenshot();
            
        }

        [Given(@"preencho os campos com os dados de um cliente ja cadastrado previamente")]

        public void preencherCamposrepetidos()
        {
            inscricao = "99014821000144";
            apelido = "TesteQA";
            nome = "TesteQA";
            foto = "https://www.kindpng.com/picc/m/11-110595_qa-icon-software-quality-assurance-icon-hd-png.png";
            status = "ATIVADO";

            Preencher_elemento(campoInscricao, inscricao, 10);
            Preencher_elemento(campoApelido, apelido, 10);
            Preencher_elemento(campoNome, nome, 10);
            Preencher_elemento(campoFoto, foto, 10);
            selecionarOpcao(dropdownStatus, status, 10);
            clicar_Elemento(btnCadastrar, 10);
            screenshot();
        }

        [Given(@"seleciono o cadastro mais recente para edição")]
            public void cadastroExistente()
        {
            clicar_Elemento(aba46, 10);
            clicar_Elemento(editarEmail, 10);
            screenshot();
        }

        [Given(@"valido que fui direcionado para o fluxo ""(.*)"" e clico no botão novo para adicionar um email")]
        public void validarAbaemail(string opcao)
        {
            string texto = ArmazenaTexto(edicaoCliente, 10);
            string cabecalho = itemvalidacao(texto);
            validarFluxo(cabecalho, opcao , 10);            
            clicar_Elemento(btnNovo, 10);
            screenshot();
        }

        [When(@"apos preencher os dados solicitados clico no botão cadastrar em seguida clico no botão editar")]

        public void cadastrarEmail()
        {
            nomeUsuario = "teste-QA";
            emailUsuario = "testeqa@teste.com.br";
            emailCategoria = "TESTE_PROPRIETARIO";
            Thread.Sleep(500);
            Preencher_elemento(nomeEmail, nomeUsuario, 10);
            Preencher_elemento(enderecoEmail, emailUsuario, 10);
            selecionarOpcao(categoriaEmail, emailCategoria, 10);
            screenshot();
            clicar_Elemento(btnCadastrar, 10);
            clicar_Elemento(btnAtualizar, 10);

        }

        [Given(@"clico na aba nome e email validando que as mesmas apresentas as mensagens de alerta necessário")]

        public void validarAlertas()
        {
            string Nome = "O nome deve conter ao menos 3 caracteres.";
            string Email = "O email deve ser válido.";
            clicar_Elemento(nomeEmail, 10);
            Preencher_elemento(nomeEmail, "a", 10);
            validarTexto(Nome, nomeEmail, 10);
            clicar_Elemento(enderecoEmail, 10);
            Preencher_elemento(enderecoEmail, "a", 10);
            validarTexto(Email, enderecoEmail, 10);
            screenshot();

        }

        [When(@"clico na opcao fechar em seguida clicando em voltar")]

        public void clicarVoltar()
        {
            clicar_Elemento(btnFechar, 10);
            clicar_Elemento(btnVoltar, 10);
            screenshot();
        }
    }
}
