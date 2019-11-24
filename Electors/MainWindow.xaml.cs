using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Model.Electors;
using VistaEmpleado;

namespace Electors
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource  =  Employee.GetEmployees();
        }

        #region Métodos

        private void NuevoEmpleado_ClickViejo(object sender, RoutedEventArgs e)
        {
            Employee.GetEmployees().Add(
                new Employee()
                {
                    Name = "Arturo Candela",
                    Title = "The Fucking Professor",
                    WasReElected = true,
                    Affiliation = Party.Indepentent
                });
        }

        private void NuevoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            EditorEmpleado editor = new EditorEmpleado(emp);
            editor.Show();

            editor.Closed += (o, ev) =>
            {
                if (!editor.NotSaved)
                {
                    Employee.GetEmployees().Add(editor.EmpleadoGuardado);
                }
                else
                {
                    MessageBox.Show("No se guardó el Empleado!");
                }
            };

        }




        #endregion

        private void MiEditarTextGrid_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = dataGrid.SelectedItem as Employee;

            if (emp != null)
            {
                Employee copia = new Employee(emp);

                EditorEmpleado editor = new EditorEmpleado(copia);
                editor.Show();

                editor.Closed += (o, ev) =>
                      {
                          
                          if (!editor.NotSaved)
                          {
                              emp.UpdateValuesFromEmployee(copia);
                          }

                      };
            }
            else
            {
                MessageBox.Show("El registro era nulo");
            }

        }
    }
}
