using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CreateDietPlanForm : Form
    {
        private int userID;
        private readonly string connectionString;
        private SqlConnection conn;

        public CreateDietPlanForm(int userID, string connarg)
        {
            InitializeComponent();
            this.userID = userID;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        private void CreateDietPlanForm_Load(object sender, EventArgs e)
        {
            LoadMeals();
            LoadAllergens();
        }

        private void LoadMeals()
        {
            try
            {
                conn.Open();
                string query = "SELECT MEALID, MEALNAME FROM MEAL";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstMeals.Items.Add(new ListBoxItem(reader["MEALID"].ToString(), reader["MEALNAME"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void LoadAllergens()
        {
            try
            {
                conn.Open();
                string query = "SELECT ALLERGENID, ALLERGENNAME FROM ALLERGENS";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstAllergens.Items.Add(new ListBoxItem(reader["ALLERGENID"].ToString(), reader["ALLERGENNAME"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string mealList = GetSelectedItems(lstMeals);
                string allergenList = GetSelectedItems(lstAllergens);

                string query = "createDietPlan";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TRAINERID", userID);
                    cmd.Parameters.AddWithValue("@PLANNAME", txtPlanName.Text);
                    cmd.Parameters.AddWithValue("@PLANDESCRIPTION", txtPlanDescription.Text);
                    cmd.Parameters.AddWithValue("@MEALLIST", mealList);
                    cmd.Parameters.AddWithValue("@ALLERGENLIST", allergenList);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Diet Plan Created Successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private string GetSelectedItems(ListBox listBox)
        {
            string selectedItems = "";
            foreach (ListBoxItem item in listBox.SelectedItems)
            {
                selectedItems += item.ID + ",";
            }
            if (!string.IsNullOrEmpty(selectedItems))
            {
                selectedItems = selectedItems.Remove(selectedItems.Length - 1);
            }
            return selectedItems;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ListBoxItem
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public ListBoxItem(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
