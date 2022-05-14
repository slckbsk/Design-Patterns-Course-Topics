﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager selcuk = new Manager
            {
                Name = "SELCUK",
                Salary = 5000
            };

            Manager murat = new Manager
            {
                Name = "MURAT",
                Salary = 5000
            };


            Worker ragip = new Worker
            {
                Name = "RAGIP",
                Salary = 4000
            };


            Worker sazan = new Worker
            {
                Name = "SAZAN",
                Salary = 4000
            };

            selcuk.Subordinates.Add(murat);
            murat.Subordinates.Add(ragip);
            murat.Subordinates.Add(sazan);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(selcuk);
            
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();


            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);
            Console.ReadLine();

        }
    }


    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public List<EmployeeBase> Subordinates { get; set; }

        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public List<EmployeeBase> Subordinates { get; set; }

        public Worker()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }


    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} zamlı maaş {1}", worker.Name, (double)worker.Salary * 1.50);

        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} zamlı maaş {1}", manager.Name, (double)manager.Salary * 1.55);

        }
    }
}
