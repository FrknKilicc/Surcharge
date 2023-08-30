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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        InteractiveTaxOfficeEntities1 con = new InteractiveTaxOfficeEntities1();


        public static int empID = 0;
        public static int ctID = 0;
        bool Login(string userrname, string password)
        {
            Citizen ct = new Citizen();  

            var query = from user in con.Citizens where user.NameSurname == userrname && user.CitizenPassword == password select user.CitizenID;

            if (query.Any())
            {
                ctID = query.First();
                return true;
            }
            else
            {
                return false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (Login(textBox1.Text, textBox2.Text))
            {
                CitizenPage cp = new CitizenPage();
                Citizen ct = new Citizen();

                ctID = ctID;


                MessageBox.Show("Giriş Başarılı");

                cp.Show();
                this.Hide();
              
            }
            else
            {
                MessageBox.Show("Giriş Başarısız, Kullanıcı Adı Veya Şifre Hatalı");
                textBox1.Clear();
                textBox2.Clear();

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Location = new Point(291, 97);

            switch (radioButton1.Checked)
            {
                case true:
                    panel1.Visible = false;
                    panel2.Visible = true;
                    break;
                case false:
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;

                default:
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;
            }

        }
       
        private void button4_Click(object sender, EventArgs e)
        {
           Employee emp = new Employee();
           var query =  con.LoginEmployee(textBox3.Text, textBox4.Text).ToList();
            
            if (query.Any())
            {
                foreach (var item in query)
                {
                    empID = item.EmployeeID;
                }
                EmployeePage page = new EmployeePage();
                page.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("selamlar");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

            string[] meslekler = new string[]
            #region meslekler
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
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            switch (radioButton2.Checked)
            {
                case true:
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;
                case false:
                    panel1.Visible = false;
                    panel2.Visible = true;
                    
                    break;

                default:
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Location = new Point(62, 66);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Citizen citizen = new Citizen();
            citizen.NameSurname = textBox5.Text;
            citizen.CitizenPassword = textBox6.Text;
            string occup = comboBox1.SelectedItem.ToString();
            textBox10.Text = citizen.CitizenshipNo = textBox10.Text;
            citizen.CitizenAdress = textBox8.Text;
            citizen.CitizenPhoneNo = textBox9.Text;
            citizen.CitizenMail = textBox11.Text;

            con.CitizenAdd(citizen.NameSurname,citizen.CitizenshipNo,occup,citizen.CitizenAdress,citizen.CitizenPhoneNo,citizen.CitizenMail,citizen.CitizenPassword);
            con.SaveChanges();
            
            MessageBox.Show("Kayıt Başarılı");
           
        }
    }
}
