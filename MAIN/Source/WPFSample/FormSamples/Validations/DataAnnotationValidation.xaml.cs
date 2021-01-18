using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;

namespace UIAtoms.WPFSamples.FormSamples.Validations
{
    /// <summary>
    /// Interaction logic for DataAnnotationValidation.xaml
    /// </summary>
    public partial class DataAnnotationValidation : Page
    {
        public DataAnnotationValidation()
        {
            InitializeComponent();

            rootForm.DataContext = new Customer();
            manualForm.DataContext = new Customer();
        }
    }

    public class Customer
    {

        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress, ErrorMessage = "Please Enter Valid Email")]
        public string EmailAddress { get; set; }
    }

}
