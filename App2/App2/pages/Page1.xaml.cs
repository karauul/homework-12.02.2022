using App2.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage 
    {
        Class1 class1 = new Class1();
        public Page1()
        {
            InitializeComponent();
            BindingContext = class1;
        }
    }
}