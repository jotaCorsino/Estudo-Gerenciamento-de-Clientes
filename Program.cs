using System;
using System.Collections.Generic;
using Exercicio01.Entities;

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();

        string opcaoMenu;

        menu.MenuStatus = true;
        while (menu.MenuStatus)
        {
            menu.ExibirMenu();                       
        }

        Console.WriteLine("Programa encerrado.");
    }
}
