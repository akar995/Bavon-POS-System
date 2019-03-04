using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bavon_POS_System
{
    
     class Row :Panel
    {
        TextBox barcodeText;
    TextBox LoactionText;
    TextBox quantityText;
    TextBox nameText;
    TextBox priceText;
    Button deleteButton;
   public  Row(string barcode, string location, string quantity, string name, string price)
    {
            this.SetBounds(0, 0, 1000, 1000);
        barcodeText = new TextBox();
        LoactionText = new TextBox();
        quantityText = new TextBox();
        nameText = new TextBox();
        priceText = new TextBox();

        deleteButton = new Button();
        deleteButton.Text = "delete";

        barcodeText.Text = barcode;
        LoactionText.Text = location;
        quantityText.Text = quantity;
        nameText.Text = name;
        priceText.Text = price;




        // this.Controls.Add(barcodeText);
        //this.Controls.Add(LoactionText);
        //this.Controls.Add(quantityText);
        //this.Controls.Add(nameText);
        // this.Controls.Add(priceText);

    }

}

}
