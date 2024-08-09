using Fundamentos.Menus;
using System.Text.RegularExpressions;

namespace Fundamentos.Functions;
internal static partial class Function
{
    internal async static Task<string> ExecutaValidacaoPlacas()
    {
        string opcao = "";
        do
        {
            opcao = await Display.ShowMenu(Template.MenuValidaPlacas);

            switch (opcao)
            {
                case "0":
                    break;
                default:
                    await ValidarPlacas(opcao);
                    break;
            }
        }
        while (opcao != "0");

        return "-1";
    }

    private async static Task ValidarPlacas(string opcao)
    {
        var placa = opcao.Trim()?.ToUpper();


        if (!string.IsNullOrEmpty(placa))
        {
            // Remover qualquer caracter inválido
            placa = Regex.Replace(placa, @"[^a-zA-Z0-9]", "");

            // Verifica se a placa é do padrão antigo
            if (Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$"))
            {
                await Display.ShowMenu($"A placa {placa} é válida no padrão brasileiro", false, 2000);
                return;
            }

            // Verifica se a placa é do padrão mercosul
            if (Regex.IsMatch(placa, @"^[A-Z]{3}[0-9][0-9A-Z][0-9]{2}$"))
            {
                await Display.ShowMenu($"A placa {placa} é válida no padrão do Mercosul", false, 2000);
                return;
            }
        }

        await Display.ShowMenu($"O texto {placa} não é uma placa válida", false, 2000);
    }
}
