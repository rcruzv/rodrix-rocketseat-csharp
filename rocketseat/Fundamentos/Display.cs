using Fundamentos.Menus;

namespace Fundamentos;
internal static class Display
{
    internal static Data? data;

    internal async static Task<string> ShowMenu(
        string menu = null!, 
        bool waitInput = true,
        int delay = 1000
    )
    {
        //Clear the previous
        Console.Clear();

        if (menu is not null)
        {
            //Show current menu
            Console.Write(
                string.Format(Template.Content, menu)
            );

            // Set the cursor after the menu
            Console.SetCursorPosition(12, 0);

            await Task.Delay(delay);

            if (waitInput)
                //Read the user input
                return Console.ReadLine()?.Trim()!;
        }

        return string.Empty;
    }
}
