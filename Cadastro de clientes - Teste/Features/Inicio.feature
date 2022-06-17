# language: pt
# encode: UTF-8

Funcionalidade: Automatizar Cadastro de clientes

@teste_inicio
Cenário: Teste de acesso a aba de cadastro de clientes
	Dado que acesso o fluxo "Fluxo inicio"
	E clico no botao novo
	Então valido que fui direcionado para o fluxo "Cadastrar cliente"

@teste_cadastral
Cenário: Teste de cadastro de cliente
	Dado que acesso o fluxo "Cadastrar cliente"
	Quando preencho os campos com os dados solicitados
	Então valido que fui direcionado para o fluxo "Inicio"

@teste_erro
Cenário: Teste de cadastro de cliente ja cadastrado
	Dado que acesso o fluxo "Cadastrar cliente"
	E preencho os campos com os dados de um cliente ja cadastrado previamente
	Então valido que fui direcionado para o fluxo "Erro"

@teste_email
Cenário: Teste de inserção de email em cadastro existente
	Dado que acesso o fluxo "Fluxo inicio"
	E seleciono o cadastro mais recente para edição
	E valido que fui direcionado para o fluxo "Editar cliente" e clico no botão novo para adicionar um email
	Quando apos preencher os dados solicitados clico no botão cadastrar em seguida clico no botão editar
	Então valido que fui direcionado para o fluxo "Inicio"

@teste_email_alertas
Cenário: Teste de alertas da area de edição de emails
	Dado que acesso o fluxo "Fluxo emails"
	E clico na aba nome e email validando que as mesmas apresentas as mensagens de alerta necessário
	Quando clico na opcao fechar em seguida clicando em voltar
	Então valido que fui direcionado para o fluxo "Inicio"


