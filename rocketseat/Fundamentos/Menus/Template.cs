namespace Fundamentos.Menus;
internal static class Template
{
    internal static string Content =
@"  Answer:_ 
==================================================
        {0}
==================================================
";

    internal static string MainMenu =
@"
    Olá, {0}! Seja muito bem vindo!
    Menu:
        1 - Nome completo
        2 - Operações entre dois números
        3 - Contando letras
        4 - Validando Placas
        5 - Exibindo datas
        0 - Sair
";

    internal static string MenuName =
@"
    Menu:
        1 - Alterar o nome
        2 - Alterar o sobrenome
        0 - Voltar ao menu anterior
";

    internal static string MenuOperacoes =
@"
    Menu:
        1 - Insira os números
        2 - Imprimir operações
        0 - Voltar ao menu anterior
";

    internal static string MenuResultadoOperacoes =
@"
    Resultado:
        '+'     {0} + {1} = {2}
        '-'     {0} - {1} = {3}
        '*'     {0} * {1} = {4}
        '/'     {0} / {1} = {5}
";
    internal static string MenuContagemLetras =
@"
    Menu:
        Escreva para contar 
        0 - Voltar ao menu anterior
";

    internal static string MenuValidaPlacas =
@"
    Menu:
        Escreva a placa para validar
        0 - Voltar ao menu anterior
";

    internal static string MenuDatas =
@"
    Menu:
        1 - Exiba a data atual em diferentes formatos
        0 - Voltar ao menu anterior
";

    internal static string MenuResultadoDatas =
@"
    Exibição:
        Data completa:      {0}
        Somente data:       {1}
        Somente hora:       {2}
        Com mês escrito:    {3}
";
}
