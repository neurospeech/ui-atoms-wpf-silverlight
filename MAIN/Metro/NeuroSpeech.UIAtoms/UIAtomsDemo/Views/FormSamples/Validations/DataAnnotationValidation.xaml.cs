using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;

namespace UIAtomsDemo.Views.FormSamples.Validations
{
    public partial class DataAnnotationValidation : Page
    {
        public DataAnnotationValidation()
        {
            InitializeComponent();

            this.Loaded += (s, e) => {
                rootForm.DataContext = new Customer();
                manualForm.DataContext = new Customer();
            };
        }
    }

    public class Customer
    {

        [DisplayAttribute(
            Prompt="Firstname",
            ShortName="Firstname"
            )]
        [Required(ErrorMessage="Firstname is required")]
        public string Firstname { get; set; }

        [DisplayAttribute(
            Prompt = "Lastname",
            ShortName = "Lastname"
            )]
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }


        [Required(ErrorMessage="Email is required")]
        [DataType( System.ComponentModel.DataAnnotations.DataType.EmailAddress , ErrorMessage="Please Enter Valid Email")]
        [DisplayAttribute(
            Prompt = "Email",
            ShortName = "Email"
            )]
        public string EmailAddress { get; set; }
    }
}
