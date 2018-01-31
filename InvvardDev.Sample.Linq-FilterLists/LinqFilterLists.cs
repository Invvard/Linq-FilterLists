using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace InvvardDev.Sample.Linq_FilterLists
{
    internal class LinqFilterLists
    {
        private struct Employee
        {
            public int Index { get; }
            public string Name { get; }

            public Employee(int index, string name)
            {
                Index = index;
                Name = name;
            }
        }

        private readonly List<Employee> _localDatabase;
        private readonly List<Employee> _updatedList;

        public LinqFilterLists()
        {
            _localDatabase = new List<Employee>
            {
                new Employee(0, "Enployee 0"),
                new Employee(1, "Enployee 1"),
                new Employee(3, "Enployee 3")
            };

            Console.WriteLine("Local 'database' :");
            DisplayList(_localDatabase);

            _updatedList = new List<Employee>
            {
                new Employee(0, "Enployee 0"),
                new Employee(1, "Enployee 1"),
                new Employee(2, "Enployee 2")
            };

            Console.WriteLine("Updated file :");
            DisplayList(_updatedList);

            CommonItems();
            AddedItems();
            RemovedItems();
        }

        private void CommonItems()
        {
            var filteredList = _localDatabase.Where(f => _updatedList.Any(s => s.Index == f.Index)).ToList();

            Console.WriteLine("Common item list :");
            DisplayList(filteredList);
        }

        private void AddedItems()
        {
            var filteredList = _updatedList.Where(s => _localDatabase.All(f => f.Index != s.Index)).ToList();

            Console.WriteLine("Added item list :");
            DisplayList(filteredList);
        }

        private void RemovedItems()
        {
            var filteredList = _localDatabase.Where(f => _updatedList.All(s => s.Index != f.Index)).ToList();

            Console.WriteLine("Removed item list :");
            DisplayList(filteredList);
        }

        private static void DisplayList(List<Employee> filteredList)
        {
            foreach (var item in filteredList)
            {
                Console.WriteLine($"{item.Index} - {item.Name}");
            }
            Console.WriteLine();
        }
    }
}