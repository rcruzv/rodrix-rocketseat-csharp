using Fundamentos.Menus;

namespace Fundamentos.Functions;
internal static partial class Function
{
    internal async static Task<string> ExecutaContagemLetras()
    {
        string opcao = "";
        do
        {
            opcao = await Display.ShowMenu(Template.MenuContagemLetras);

            switch (opcao)
            {
                case "0":
                    break;
                default:
                    var palavras = opcao.Split(" ").Where(x => !string.IsNullOrEmpty(x));
                    foreach (var palavra in palavras)
                    {
                        await Display.ShowMenu($"{palavra} tem o total de {palavra.Length} letras", false, 2000);
                    }
                    break;
            }
        }
        while (opcao != "0");

        return "-1";
    }
}
