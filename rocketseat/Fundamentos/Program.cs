
using Fundamentos;
using Fundamentos.Functions;
using Fundamentos.Menus;

Display.data = new()
{
    Nome = await Display.ShowMenu("Qual o seu nome?"),
    Sobrenome = string.Empty
};

string opcao = "";
do
{
    opcao = await Display.ShowMenu(
        string.Format(Template.MainMenu, string.Concat(Display.data.Nome," ", Display.data.Sobrenome))
    );

    switch (opcao)
    {
        case "0":
            break;
        case "1":
            opcao = await Function.ExecutaNomeSobrenome();
            break;
        case "2":
            opcao = await Function.ExecutaOperacoesAritmeticas();
            break;
        case "3":
            opcao = await Function.ExecutaContagemLetras();
            break;
        case "4":
            opcao = await Function.ExecutaValidacaoPlacas();
            break;
        case "5":
            opcao = await Function.ExecutaExibicaoDatas();
            break;
        default:
            await Display.ShowMenu("Opção inválida, tente novamente", false);
            break;
    }
}
while (opcao != "0");

