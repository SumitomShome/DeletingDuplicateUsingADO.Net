using System;

namespace DuplicateRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to Employee Payroll!");
            DeletingDuplicate deletingDuplicate = new DeletingDuplicate();
            Model model = new Model();
            deletingDuplicate.GetAllEmployee();
            deletingDuplicate.DeleteDuplicateRecord();
            deletingDuplicate.GetAllEmployee();
            Console.ReadKey();
        }
    }
}
