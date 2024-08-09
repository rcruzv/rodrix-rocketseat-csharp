using Fundamentos.Menus;

namespace Fundamentos.Functions;
internal static partial class Function
{
    internal async static Task<string> ExecutaExibicaoDatas()
    {
        string opcao = "";
        do
        {
            opcao = await Display.ShowMenu(Template.MenuDatas);

            switch (opcao)
            {
                case "0":
                    break;
                case "1":
                    await ExibirDataAtual();
                    break;
                default:
                    break;
            }
        }
        while (opcao != "0");

        return "-1";
    }

    private static async Task ExibirDataAtual()
    {
        var _dataAtual = DateTime.UtcNow;
        await Display.ShowMenu(
            string.Format(Template.MenuResultadoDatas,
                _dataAtual.ToString(),
                _dataAtual.ToString("dd/MM/yyyy"),
                _dataAtual.ToString("HH:mm:ss"),
                _dataAtual.ToString("f")
            )
        );
    }
}
