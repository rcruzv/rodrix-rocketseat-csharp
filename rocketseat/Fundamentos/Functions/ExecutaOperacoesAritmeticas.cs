using Fundamentos.Menus;

namespace Fundamentos.Functions;
internal static partial class Function
{
    internal async static Task<string> ExecutaOperacoesAritmeticas()
    {
        string opcao = "";
        do
        {
            opcao = await Display.ShowMenu(Template.MenuOperacoes);

            switch (opcao)
            {
                case "0":
                    break;
                case "1":
                    string num1, num2;
                    bool valid = false;
                    do
                    {
                        num1 = await Display.ShowMenu("Insira o primeiro numero:");
                        num2 = await Display.ShowMenu("Insira o segundo numero:");

                        if (long.TryParse(num1, out long l1) && long.TryParse(num2, out long l2))
                        {
                            if(Display.data is not null)
                            {
                                Display.data.Numero01 = l1;
                                Display.data.Numero02 = l2;
                            }
                            valid = true;
                        }
                        else
                        {
                            await Display.ShowMenu($"Não seja expertinho {Display.data?.Nome ?? ""}, digite números válidos. Por favor!", false);
                        }  
                    }
                    while (!valid);

                    break;
                case "2":
                    if (Display.data is not null && Display.data?.Numero01 is not null && Display.data?.Numero02 is not null)
                        await Display.ShowMenu(
                            string.Format(Template.MenuResultadoOperacoes,
                                Display.data?.Numero01,
                                Display.data?.Numero02,
                                (Display.data?.Numero01 + Display.data?.Numero02),
                                (Display.data?.Numero01 - Display.data?.Numero02),
                                (Display.data?.Numero01 * Display.data?.Numero02),
                                (Display.data?.Numero01 / Display.data?.Numero02)
                            )
                        );
                    else
                        await Display.ShowMenu("Escolha a outra opção primeiro. Por favor!", false);
                    break;
                default:
                    break;
            }
        }
        while (opcao != "0");

        return "-1";
    }
}
