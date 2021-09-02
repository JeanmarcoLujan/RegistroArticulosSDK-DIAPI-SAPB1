using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenturaArticulos.Connection;

namespace VenturaArticulos
{
    public partial class Articulos : Form
    {

        public SAPbobsCOM.Company oCompany = null;
        public SAPbobsCOM.Items oItem = null;

        public string user = "manager";
        public string pass = "1336";
        public Articulos()
        {
           
            InitializeComponent();
            AccessToB1Async();
        }

        private void Articulos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string numero, nombre;

            numero = txtNum.Text.Trim();
            nombre = txtNom.Text.Trim();

            if(numero.Equals(""))


            oItem = null;
            oItem = (SAPbobsCOM.Items)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oItems);

            if (string.IsNullOrEmpty(numero))
            {
                MessageBox.Show("Por favor, ingrese el número de articulo");
            }else if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre del articulo");
            }
            else
            {
                oItem.ItemCode = numero;
                oItem.ItemName = nombre;



                var result = oItem.Add();
                if (result == 0)
                {
                    MessageBox.Show("El articulo ha sido creado correctamente");
                    txtNum.Text = "";
                    txtNom.Text = "";
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccessToB1Async()
        {


            string strMessage = string.Empty;
            int iServerType = 0;
            string sServer, sLicenseSever, sUserBD, sPassBD, sCompanyName, sUserB1, sPassB1;
            try
            {
                /*
                iServerType = comboBox1.SelectedIndex;
                sServer = textBox1.Text;
                sLicenseSever = textBox4.Text;
                sUserBD = textBox2.Text;
                sPassBD = textBox3.Text;
                sCompanyName = textBox5.Text;
                sUserB1 = textBox6.Text;
                sPassB1 = textBox7.Text;
                */

                var SDSD = iServerType;
                iServerType = 0;
                sServer = "LUJAN";
                sLicenseSever = "LUJAN";
                sUserBD = "sa";
                sPassBD = "seidor";
                sCompanyName = "SBO_BONAPHARM";
                sUserB1 = user;
                sPassB1 = pass;



                SBOConnection cn = new SBOConnection();
                cn.ConnectCompany(iServerType, sServer, sLicenseSever, sUserBD, sPassBD, sUserB1, sPassB1, sCompanyName, out strMessage);


                if (cn != null && cn.IsConnected)
                {
                    this.oCompany = cn.companyObject;
                }
                else
                {
                    MessageBox.Show("A ocurrido un error en la conexión, ingrese nuevamente la información");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

       
    }
}
