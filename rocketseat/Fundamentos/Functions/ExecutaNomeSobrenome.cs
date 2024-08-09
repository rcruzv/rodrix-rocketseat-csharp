using Fundamentos.Menus;

namespace Fundamentos.Functions;
internal static partial class Function
{
    internal async static Task<string> ExecutaNomeSobrenome()
    {
        string opcao = "";
        do
        {
            opcao = await Display.ShowMenu(Template.MenuName);

            switch (opcao)
            {
                case "0":
                    break;
                case "1":
                    if (Display.data is not null)
                        Display.data.Nome = await Display.ShowMenu("Qual o seu nome?");
                    break;
                case "2":
                    if (Display.data is not null)
                        Display.data.Sobrenome = await Display.ShowMenu("Qual o seu sobrenome?");
                    break;
                default:
                    await Display.ShowMenu("Opção inválida, tente novamente", false);
                    break;
            }
        }
        while (opcao != "0");

        return "-1";
    }
}
