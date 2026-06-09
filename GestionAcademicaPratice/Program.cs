using GestionAcademicaPratice.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        MenuService menu = new MenuService();
        menu.Iniciar();
    }
}