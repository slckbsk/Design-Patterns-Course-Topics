using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee mudur = new Employee { Name = "Selcuk" };

            Employee deposorumlusu = new Employee { Name = "Tuncay" };
            Employee calisanM = new Employee { Name = "Atilla" };
            
            Employee calisan1 = new Employee { Name = "AliEnder" };
            Employee calisan2 = new Employee { Name = "Rambo" };
            Employee calisan3 = new Employee { Name = "Ömer" };
            Employee calisan4 = new Employee { Name = "Hüseyin" };

            Tasaron disCalisan1 = new Tasaron { Name = "İloş" };
            Tasaron disCalisan2 = new Tasaron { Name = "İhsan" };

            mudur.AddSubordinate(deposorumlusu);
            mudur.AddSubordinate(calisanM);
            calisanM.AddSubordinate(calisan1);
            deposorumlusu.AddSubordinate(calisan2);
            deposorumlusu.AddSubordinate(calisan3);
            deposorumlusu.AddSubordinate(calisan4);
            calisan2.AddSubordinate(disCalisan1);
            calisan2.AddSubordinate(disCalisan2);

            Console.WriteLine(" * " + mudur.Name + " * ");
            foreach (Employee calisan in mudur)
            {
                Console.WriteLine(" - " + calisan.Name);
                foreach (Employee calisanlar in calisan)
                {
                    Console.WriteLine(calisanlar.Name);
                    foreach (IPerson calisanlarD in calisanlar)
                    {
                        Console.WriteLine(calisanlar.Name + " => " +calisanlarD.Name);
                    }
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }


    class Tasaron : IPerson
    {
        public string Name { get; set; }
    }


    class Employee : IPerson, IEnumerable<IPerson>
        {
            List<IPerson> _subordinates = new List<IPerson>();

            public void AddSubordinate(IPerson person)
            {
                _subordinates.Add(person);
            }

            public void RemoveSubordinate(IPerson person)
            {
                _subordinates.Remove(person);
            }


            public IPerson GetSubordinate(int index)
            {
                return _subordinates[index];
            }


            public string Name { get; set; }

            public IEnumerator<IPerson> GetEnumerator()
            {
                foreach (var subordinate in _subordinates)
                {
                    yield return subordinate;
                }
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }




    }
