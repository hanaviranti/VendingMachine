using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VendingMachine.DTO;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            getDynamicButton();

            ResetButton();
        }

        private void getDynamicButton()
        {
            Repository repo = new Repository();
            var barang = repo.GetAllBarang();

            int nextlocation = 186;
            int i = 0;
            foreach (var item in barang)
            {
                Button dynamicButton = new Button();

                dynamicButton.Height = 175;
                dynamicButton.Width = 180;
                dynamicButton.Text = item.nama_barang + Environment.NewLine + "Rp " + String.Format("{0:N0}", item.harga);
              
                dynamicButton.Location = new System.Drawing.Point(12 + (nextlocation * i), 12);
                

                dynamicButton.Tag = item.harga;
                dynamicButton.Click += new EventHandler(OnButtonClick);
                dynamicButton.Name = item.nama_barang;

                dynamicButton.BackgroundImage = Image.FromFile(item.image);
                dynamicButton.BackgroundImageLayout = ImageLayout.Stretch;
                dynamicButton.TextAlign = ContentAlignment.TopCenter;
                flowLayoutPanel1.Controls.Add(dynamicButton);
                i++;
            }
        }

        private void getDynamicButtonCheckOut(barang item)
        {
            int nextlocation = 116;
            int i = 0;
            Button dynamicButton = new Button();

            dynamicButton.Height = 100;
            dynamicButton.Width = 100;
            dynamicButton.Text = item.nama_barang + Environment.NewLine + "Rp " + String.Format("{0:N0}", item.harga);
            
            dynamicButton.Location = new System.Drawing.Point(9 + (nextlocation * i), 32);
            

            dynamicButton.Tag = item.harga;
            dynamicButton.Click += new EventHandler(OnButtonCheckOutClick);
            dynamicButton.Name = item.nama_barang;

            dynamicButton.BackgroundImage = Image.FromFile(item.image);
            dynamicButton.BackgroundImageLayout = ImageLayout.Stretch;
            dynamicButton.TextAlign = ContentAlignment.TopCenter;
            flowLayoutPanel2.Controls.Add(dynamicButton);
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            
            Repository repo = new Repository();
            var barang = repo.GetBarang(temp.Name);
            if (barang.stock>0)
            {
                getDynamicButtonCheckOut(barang);

                var nominal = (decimal.Parse(label2.Text) + decimal.Parse(temp.Tag.ToString()));
                label2.Text = String.Format("{0:N0}", nominal.ToString());
                repo.setStokmin(temp.Name);
            }
            else
            {
                MessageBox.Show("Maaf Stock Habis");
            }

        }

        private void OnButtonCheckOutClick(object sender, EventArgs e)
        {
            Repository repo = new Repository();
            Button temp = (Button)sender;
            temp.Visible = false;
            var nominal = (decimal.Parse(label2.Text) - decimal.Parse(temp.Tag.ToString()));
            label2.Text = String.Format("{0:N0}", nominal.ToString());
            repo.setStokplus(temp.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nominal = (decimal.Parse(label3.Text) + 2000);
            label3.Text = String.Format("{0:N0}", nominal.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var nominal = (decimal.Parse(label3.Text) + 5000);
            label3.Text = String.Format("{0:N0}", nominal.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var nominal = (decimal.Parse(label3.Text) + 10000);
            label3.Text = String.Format("{0:N0}", nominal.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var nominal = (decimal.Parse(label3.Text) + 20000);
            label3.Text = String.Format("{0:N0}", nominal.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nominal = (decimal.Parse(label3.Text) + 50000);
            label3.Text = String.Format("{0:N0}", nominal.ToString());
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            var harga = decimal.Parse(label2.Text);
            var bayar = decimal.Parse(label3.Text);
            if (harga > 0 && bayar >= harga)
            {
                if (bayar - harga > 0)
                {
                    MessageBox.Show("Pesanan Selesai, silahkan ambil kembalian anda Rp " + (bayar - harga));

                }
                else
                {
                    MessageBox.Show("Pesanan Selesai");

                }
                ResetForm();
            }
        }

        private void ResetForm()
        {
            label2.Text = "0";
            label3.Text = "0";
            flowLayoutPanel2.Controls.Clear();
        }

        private void ResetButton()
        {
            button1.Enabled = decimal.Parse(label2.Text) > 0;
            button2.Enabled = decimal.Parse(label2.Text) > 0;
            button3.Enabled = decimal.Parse(label2.Text) > 0;
            button4.Enabled = decimal.Parse(label2.Text) > 0;
            button5.Enabled = decimal.Parse(label2.Text) > 0;
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            ResetButton();
        }
    }
}
