using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surcharge
{
    public partial class CitizenPage : Form
    {
        public CitizenPage()
        {
            InitializeComponent();
        }

        InteractiveTaxOfficeEntities1 con = new InteractiveTaxOfficeEntities1();
        decimal balance = 0;
        private void CitizenPage_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
           
            comboBox1.Text = "Seçiniz";

            int id = Convert.ToInt32(Form1.ctID);
            
            var query = from userr in con.Citizens where userr.CitizenID == id select userr;
            if (query.Any())
            {
                foreach (var item in query)
                {

                    textBox1.Text = item.NameSurname;
                    textBox2.Text = item.CitizenshipNo;
                    textBox3.Text = item.CitizenOccupation;
                    textBox4.Text = item.CitizenAdress;
                    textBox5.Text = item.CitizenPhoneNo;
                    textBox6.Text = item.CitizenMail;
                    textBox7.Text = item.CitizenBalance.ToString();
                    balance = Convert.ToDecimal(item.CitizenBalance) ;

                    textBox2.ReadOnly = true;
                    textBox2.Cursor = Cursors.No;

                }

            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Citizen citizen = new Citizen();
            if (textBox8.Text == "")
            {
                MessageBox.Show("Lütfen Bir Değer Giriniz");
            }
            else
            {
                con.AddBalance(decimal.Parse(textBox8.Text), Form1.ctID);
                MessageBox.Show("Bakiyeni Başarıyla Yüklendi " + textBox8.Text + "TL");
                refreshBalance();
                dataGridView1.DataSource = con.CitizenList().ToList();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView1.DataSource = con.totalDebt(Form1.ctID).ToList();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //MessageBox.Show(con.RemainingDebt(Form1.ctID).ToString());

                dataGridView1.DataSource = con.RemDebbt(Form1.ctID).ToList();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;

            List<Tax> veriler = con.Taxes.ToList();
            veriler.Insert(0, new Tax() { TaxID = 0, TaxName = "Lütfen Seçiniz!" });
            comboBox2.DataSource = veriler;
            comboBox2.DisplayMember = "TaxName";
            comboBox2.ValueMember = "TaxID";
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex <= 0)
                return;

            //List<Tax> veriler = from x in con.Taxes 
            //                    where x.TaxID == Convert.ToInt32(comboBox2.SelectedValue) 
            //                    select x;

            List<Tax> veriler = con.Taxes.ToList().Where(x => x.TaxID == Convert.ToInt32(comboBox2.SelectedValue)).ToList();


            foreach (Tax item in veriler)
            {
                decimal TaxAmountt = Convert.ToDecimal(item.TaxAmount);
                textBox9.Text = TaxAmountt.ToString();
                textBox10.Text = (TaxAmountt * 7 / 100).ToString();
                textBox10.Tag = item.TaxID;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {

            PaymentDetail pd = new PaymentDetail();

            pd.TaxAmount = Convert.ToDecimal(textBox9.Text);
            pd.Interest = Convert.ToDecimal(textBox10.Text);
            pd.TotalPayment = Convert.ToDecimal(textBox11.Text);
            pd.CitizenID = Form1.ctID;
            pd.TaxID = Convert.ToInt32(textBox10.Tag);
            pd.PaymentDate = Convert.ToDateTime(dateTimePicker1.Value);



            if (balance >= pd.TotalPayment)
            {
                if (pd.TaxAmount + pd.Interest > pd.TotalPayment || pd.TaxAmount + pd.Interest - pd.TotalPayment == 0)
                {
                    string value = "";
                    string indexesofPDetails = "";
                    int intValue = 0;

                    var query = from x in con.PaymentDetails where x.TaxID == pd.TaxID && x.CitizenID == Form1.ctID select x;


                    foreach (var item in query)
                    {
                        indexesofPDetails = item.PaymentDetailID.ToString(); ;
                        value = item.PaymentDetailID.ToString();


                    }
                    if (!string.IsNullOrEmpty(value) && indexesofPDetails != null)
                    {
                        intValue = Convert.ToInt32(value);
                        con.UpPaymentDetails(intValue, pd.TaxAmount, pd.Interest, pd.TotalPayment, pd.CitizenID, pd.TaxID, pd.PaymentDate);
                        

                        textBox9.Clear();
                        textBox10.Clear();
                        textBox11.Clear();
                        refreshBalance();
                        comboBox2.SelectedIndex = 0;

                        MessageBox.Show("Ödeme Başarılı");
                        dataGridView1.DataSource = con.AfterPayment(Form1.ctID);

                    }
                    else if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(indexesofPDetails))
                    {

                        con.PaymentDetailAdd(pd.TaxAmount, pd.Interest, pd.TotalPayment, pd.CitizenID, pd.TaxID, pd.PaymentDate);


                        textBox7.Clear();
                        textBox9.Clear();
                        textBox10.Clear();
                        textBox11.Clear();
                        refreshBalance();
                        comboBox2.SelectedIndex = 0;
                        MessageBox.Show("Ödeme Başarılı");
                        dataGridView1.DataSource = con.AfterPayment(Form1.ctID);


                    }
                }
                else
                {
                    MessageBox.Show("Ödenecek Tutar Vergi Tutarın Büyük, Lütfen Tutarı Revize Edin.");
                }

            }
            else
            {
                MessageBox.Show("Bakiyeniz Yetersiz,Lütfen Bakiye Yükleyiniz");
            }


        }

        public void refreshBalance()
        {
            

            var refresh = from userr in con.Citizens where userr.CitizenID == Form1.ctID select userr;

            if (refresh.Any())
            {
                foreach (var item in refresh)
                {

                    textBox7.Text = item.CitizenBalance.ToString();
                    balance = Convert.ToDecimal(item.CitizenBalance);

                }


            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
