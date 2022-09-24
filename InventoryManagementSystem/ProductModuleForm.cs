using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ProductModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\mak hitam\Desktop\aplikasi pengolahan data\InventoryManagementSystem\Tutorial Database\dbIMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
    
        public ProductModuleForm()
        {
            InitializeComponent();
           
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbProduct(pid,pname,pcode,pprice,pshift,pdate)VALUES(@pid,@pname,@pcode,@pprice,@pshift,@pdate)", con);
                    cm.Parameters.AddWithValue("@pid", txtPid.Text);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pcode", Convert.ToInt16(txtPCode.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPrice.Text));
                    cm.Parameters.AddWithValue("@pshift", Convert.ToInt16(txtPShift.Text));        
                    cm.Parameters.AddWithValue("@pdate",Convert.ToString(txtPDate1.Text));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        public void Clear()
        {
            txtPid.Clear();
            txtPName.Clear();
            txtPCode.Clear();
            txtPShift.Clear();
            txtPrice.Clear();
            txtPDate1.Clear();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
            
                if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    
                {

                    cm = new SqlCommand("UPDATE tbProduct SET pid = @pid, pname=@pname, pcode=@pcode, pprice=@pprice, pshift=@pshift, pdate=@pdate WHERE pid LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pid", txtPid.Text);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pcode", Convert.ToInt16(txtPCode.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPrice.Text));
                    cm.Parameters.AddWithValue("@pshift", Convert.ToInt16(txtPShift.Text));
                    cm.Parameters.AddWithValue("@pdate", Convert.ToString(txtPDate1.Text));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully updated!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comboCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPid_Click(object sender, EventArgs e)
        {

        }
    }
}
