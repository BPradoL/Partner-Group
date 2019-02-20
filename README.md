# Teste Partner Group

---------------------------------
API CONTROLE DE PATRIMONIO
---------------------------------
Essa API permite ter o controle dos dados de Patrimonio de uma empresa.
Nela podem ser feitas todas as operações para manipular os dados,
como visualizar, inserir, editar e deletar.

Foi utilizado C#, com Framework .NET 4.5, e inserção no banco de dados SQL SERVER utilizando ADO.

Os metodos para as operações estão divididos em 5 metodos para cada item, 5 para Patrimonio e 5 para Marca:

Listar: lista todos os dados.
ListarSellecionado: lista somente um item.
Cadastrar: cadastra um novo item.
Editar: edita um item escolhido.
Deletar: deleta um item escolhido.

Os metodos para utlização são:

patrimonio/Get - Lista os patrimonios
patrimonio/Get{} - lista um patrimonio especifico
patrimonio/POST - cadastra um novo patrimonio
patrimonio/PUT{} - edita um patrimonio
patrimonio/DELETE{} - deleta um patrimonio

marca/GET- Lista as marcas
marca/Get{} - lista uma marca especifica
marca/POST - cadastra uma nova marca
marca/PUT{} - edita uma marca
marca/DELETE{} - deleta uma marca
patrimonio/Put{} - edita um patrimonio escolhido
