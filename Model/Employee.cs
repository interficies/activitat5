using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Electors
{
    public enum Party {
        Indepentent, Federalist, DemocratRepublican,
    }

    public class Employee : INotifyPropertyChanged
    {
        private static ObservableCollection<Employee> employees = null;

        public Employee()
        {

        }

        public Employee(Employee emp) : this()
        {
            UpdateValuesFromEmployee(emp);
        }

        public void UpdateValuesFromEmployee(Employee emp)
        {
            Name = emp.Name;
            Title = emp.Title;
            WasReElected = emp.WasReElected;
            Affiliation = emp.Affiliation;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value; RaisePropertyChanged();
            }
        }
        private string title; public string Title
        {
            get { return title; }
            set
            {
                title = value; RaisePropertyChanged();
            }
        }
        private bool wasReElected;
        public bool WasReElected
        {
            get { return wasReElected; }
            set
            {
                wasReElected = value; RaisePropertyChanged();
            }
        }

        private Party affiliation;
        public Party Affiliation
        {
            get { return affiliation; }
            set
            {
                affiliation = value; RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        private void RaisePropertyChanged([CallerMemberName]string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public static ObservableCollection<Employee> GetEmployees() {

            if (employees == null)
            {
                employees = new ObservableCollection<Employee>();

                employees.Add(new Employee()
                {
                    Name = "Ali",
                    Title = "Minister",
                    WasReElected = true,
                    Affiliation = Party.Indepentent
                });
                employees.Add(new Employee()
                {
                    Name = "Ahmed",
                    Title = "CM",
                    WasReElected = false,
                    Affiliation = Party.Federalist
                });
                employees.Add(new Employee()
                {
                    Name = "Amjad",
                    Title = "PM",
                    WasReElected = true,
                    Affiliation = Party.DemocratRepublican
                });
                employees.Add(new Employee()
                {
                    Name = "Watias",
                    Title = "Minister",
                    WasReElected = false,
                    Affiliation = Party.Indepentent
                });
                employees.Add(new Employee()
                {
                    Name = "Bilal",
                    Title = "Minister",
                    WasReElected = true,
                    Affiliation = Party.Federalist
                });
                employees.Add(new Employee()
                {
                    Name = "Watiar",
                    Title = "Minister",
                    WasReElected = false,
                    Affiliation = Party.DemocratRepublican
                });
            }

            return employees;
        }
        
    }
}
