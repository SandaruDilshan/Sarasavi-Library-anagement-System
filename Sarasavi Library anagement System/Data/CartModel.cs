using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasavi_Library_anagement_System.Data
{
    public partial class CartModel : ObservableObject
    {
        [ObservableProperty]
        public string image;

        [ObservableProperty]
        public string bookISBN;

        [ObservableProperty]
        public string  title;

        [ObservableProperty]
        public string? statusBorR;

        [ObservableProperty]
        private int quantity;

    }
}
