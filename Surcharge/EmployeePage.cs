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

    public partial class EmployeePage : Form
    {
        private void ClearTextBox()
        {
            TextBox[] textBoxArray = new TextBox[] { textBox1, textBox2, textBox4, textBox5, textBox6, textBox8 };

            foreach (TextBox textBox in textBoxArray)
            {
                textBox.Clear();

            }

        }
        public EmployeePage()
        {
            InitializeComponent();
        }

        InteractiveTaxOfficeEntities1 con = new InteractiveTaxOfficeEntities1();
        private void EmployeePage_Load(object sender, EventArgs e)
        {

            comboBox2.Text = "Seçiniz";
            comboBox3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                //Citizen Add - 
                Citizen citizen = new Citizen();
                citizen.NameSurname = textBox1.Text;
                citizen.CitizenshipNo = textBox2.Text;
                citizen.CitizenOccupation = comboBox1.SelectedItem.ToString();
                citizen.CitizenAdress = textBox4.Text;
                citizen.CitizenPhoneNo = textBox5.Text;
                citizen.CitizenMail = textBox6.Text;
                citizen.CitizenPassword = textBox8.Text;


                con.CitizenAdd(citizen.NameSurname, citizen.CitizenshipNo, citizen.CitizenOccupation, citizen.CitizenAdress, citizen.CitizenPhoneNo, citizen.CitizenMail, citizen.CitizenPassword);
                con.SaveChanges();
                MessageBox.Show("Vatandaş Ekleme İşlemi Başarıyla Gerçekleşti");
                dataGridView1.DataSource = con.Citizens.ToList();
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                comboBox3.Items.RemoveAt(comboBox3.SelectedIndex);
                comboBox3.Visible = true;
                //Tax Add
                Tax taxes = new Tax();
                taxes.TaxID = Convert.ToInt32(comboBox3.SelectedValue);
                con.TaxAdd(textBox2.Text,taxes.TaxID);
                con.SaveChanges();
                MessageBox.Show("Vergi Ekleme İşlemi Başarıyla Gerçekleşti");
                dataGridView1.DataSource = con.TaxList().ToList();
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                comboBox3.Items.RemoveAt(comboBox3.SelectedIndex);
                Ministry ms = new Ministry();
                //Ministry Add
                ms.MinistryName = textBox1.Text;
                ms.HeadOfDepartments = textBox8.Text;
                ms.EmployeeID = Form1.empID;
                comboBox3.Visible = true;

                con.MinistriesAdd(ms.MinistryName, ms.HeadOfDepartments, ms.EmployeeID);
                con.SaveChanges();
                MessageBox.Show("Bakanlık İşlemi Başarıyla Gerçekleşti");
                dataGridView1.DataSource = con.MinistriesList();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == 0)
            {
                ClearTextBox();

                string[] meslekler = new string[]
                #region
               {
                  "Doktor",
                "Öğretmen",
                "Mühendis",
                "Avukat",
                "Yazılım Geliştirici",
                "Grafik Tasarımcı",
                "Diş Hekimi",
                "Psikolog",
                "İşletmeci",
                "Eczacı",
                "Mimar",
                "Şef",
                "Fotografçı",
                "Müzisyen",
                "Yazar",
                "Arkeolog",
                "Çevirmen",
                "Veteriner",
                "Oyuncu",
                "Sosyal Medya Yöneticisi",
                "Elektrikçi",
                "Marangoz",
                "Hemşire",
                "Pilot",
                "Tercüman",
                "Terzi",
                "Fitness Antrenörü",
                "Gardırop Danışmanı",
                "Pazarlama Uzmanı",
                "Kimyager",
                "İllüstratör",
                "Odyolog",
                "Ses Mühendisi",
                "Dansçı",
                "Gazeteci",
                "Eğitim Danışmanı",
                "Yatırım Danışmanı",
                "Çiftçi",
                "Jeolog",
                "Meteorolog",
                "Sivil Toplum Lideri",
                "Serbest Dalışçı",
                "Mobilya Tasarımcısı",
                "Jeofizikçi",
                "Zoolog",
                "Araba Yarışçısı",
                "Çikolata Sommelieri"




               };
                #endregion

                AutoCompleteStringCollection meslekCollection = new AutoCompleteStringCollection();
                meslekCollection.AddRange(meslekler);
                comboBox1.AutoCompleteCustomSource = meslekCollection;
                comboBox1.Items.AddRange(meslekler.ToArray());

                //Citizen transactions- Visible

                label1.Text = "Kullanıcı Adı:";
                label2.Text = "T.c No:";
                label8.Text = "Şifre:";
                label4.Text = "Adres:";
                label5.Text = "Telefon:";
                label6.Text = "Mail:";
                label3.Text = "Meslek:";

                
                label1.Visible = true;
                label8.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label3.Visible = true;

                textBox1.Visible = true;
                textBox8.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox8.ReadOnly = false;

                comboBox1.Visible = true;
                comboBox3.Visible = true;

            }
            else if (comboBox2.SelectedIndex == 1)
            {
                ClearTextBox();

                List<Tax> veriler = con.Taxes.ToList();
                comboBox3.DataSource = veriler;
                comboBox3.DisplayMember = "TaxName";
                comboBox3.ValueMember = "TaxID";
                //Tax transactions- Visible 

                label2.Text = "Vergi Adı:";
               

              
                label1.Visible = false;
                label8.Visible = false;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label3.Visible = false;

                textBox1.Visible = false;
                textBox8.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox8.ReadOnly = false;

                comboBox1.Visible = false;
                comboBox3.Visible = true;




            }
            else if (comboBox2.SelectedIndex == 2)
            {
                ClearTextBox();
                //Ministries transactions-visible 

                List<Tax> veriler = con.Taxes.ToList();
                comboBox3.DataSource = veriler;
                comboBox3.DisplayMember = "TaxName";
                comboBox3.ValueMember = "TaxID";

               


                label1.Text = "Bakanlık Adı:";
                label2.Text = "Bakan Adı:";
                label8.Text = "Çalışan ID";
                textBox8.Text = Form1.empID.ToString();
                textBox8.ReadOnly = true;
                label4.Text = "Vergi Adı";

                label1.Visible = true;
                label8.Visible = true;
                label4.Visible = true;
               
                label3.Visible = false;

                textBox1.Visible = true;
                textBox8.Visible = true;
                textBox4.Visible = true;

                comboBox3.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                comboBox1.Visible = false;


            }

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

