using Model.Electors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace VistaEmpleado
{
    /// <summary>
    /// Lógica de interacción para EditorEmpleado.xaml
    /// </summary>
    public partial class EditorEmpleado : Window
    {
        #region Variables

        private Employee model = null;

        private bool modifiedAfterSaved = false, notSaved = true;
        public bool ModifiedAfterSaved => modifiedAfterSaved;
        public bool NotSaved => notSaved;

        private Employee empleadoGuardado;
        public Employee EmpleadoGuardado => empleadoGuardado;

        #endregion

        #region listeners

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            notSaved = false;
            modifiedAfterSaved = false;
            empleadoGuardado = new Employee(model);

        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            //Comprobamos si se han guardado o no los cambios
            if (modifiedAfterSaved)
            {
                string msg = "Hay Cambios no guardados. ¿Seguro que quieres cerrar?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Data App",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

      
        public EditorEmpleado(Employee empleado)
        {
            InitializeComponent();

            model = empleado;

            MainViewModel viewModel = new MainViewModel();
            viewModel.MyEmployee = model;
            worker.DataContext = viewModel;

            empleado.PropertyChanged += (o, e) =>
            {
                modifiedAfterSaved = true;
                notSaved = true;
            };
        }
        
    }
}
