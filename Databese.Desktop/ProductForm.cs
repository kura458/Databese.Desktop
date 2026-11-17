
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Databese.Desktop.Models;
using Databese.Desktop.Services;

namespace Databese.Desktop
{
    public partial class ProductForm : Form
    {
        // Textboxes
        private TextBox txtProductName = null!;
        private TextBox txtPrice = null!;
        private TextBox txtQuantity = null!;
        private TextBox txtSearch = null!;

        // Buttons
        private Button btnAdd = null!;
        private Button btnUpdate = null!;
        private Button btnDelete = null!;
        private Button btnSearch = null!;
        private Button btnRefresh = null!;

        // DataGridView
        private DataGridView dgvProducts = null!;

        // API Client
        private readonly ApiClient _apiClient = new ApiClient();

        // Selected Product ID
        private int selectedProductId = 0;

        // Keep all products for local searching
        private List<ProductDto> allProducts = new List<ProductDto>();

        public ProductForm()
        {
            InitializeComponent();

            CreateProductInterface();

            this.Load += ProductForm_Load;
            this.Click += ProductForm_Click;
        }

        // CREATE PRODUCT INTERFACE
        private void CreateProductInterface()
        {
            this.Text = "Product Management";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Product Name Label
            Label lblProductName = new Label();
            lblProductName.Text = "Product Name:";
            lblProductName.Location = new Point(30, 30);
            lblProductName.AutoSize = true;
            this.Controls.Add(lblProductName);

            // Product Name TextBox
            txtProductName = new TextBox();
            txtProductName.Location = new Point(150, 25);
            txtProductName.Width = 200;
            this.Controls.Add(txtProductName);

            // Price Label
            Label lblPrice = new Label();
            lblPrice.Text = "Price:";
            lblPrice.Location = new Point(30, 75);
            lblPrice.AutoSize = true;
            this.Controls.Add(lblPrice);

            // Price TextBox
            txtPrice = new TextBox();
            txtPrice.Location = new Point(150, 70);
            txtPrice.Width = 200;
            this.Controls.Add(txtPrice);

            // Quantity Label
            Label lblQuantity = new Label();
            lblQuantity.Text = "Quantity:";
            lblQuantity.Location = new Point(30, 120);
            lblQuantity.AutoSize = true;
            this.Controls.Add(lblQuantity);

            // Quantity TextBox
            txtQuantity = new TextBox();
            txtQuantity.Location = new Point(150, 115);
            txtQuantity.Width = 200;
            this.Controls.Add(txtQuantity);

            // Add Product Button
            btnAdd = new Button();
            btnAdd.Text = "Add Product";
            btnAdd.Location = new Point(400, 25);
            btnAdd.Size = new Size(120, 35);
            btnAdd.Click += btnAdd_Click;
            this.Controls.Add(btnAdd);

            // Update Product Button
            btnUpdate = new Button();
            btnUpdate.Text = "Update Product";
            btnUpdate.Location = new Point(400, 70);
            btnUpdate.Size = new Size(120, 35);
            btnUpdate.Click += btnUpdate_Click;
            this.Controls.Add(btnUpdate);

            // Delete Product Button
            btnDelete = new Button();
            btnDelete.Text = "Delete Product";
            btnDelete.Location = new Point(400, 115);
            btnDelete.Size = new Size(120, 35);
            btnDelete.Click += btnDelete_Click;
            this.Controls.Add(btnDelete);

            // Search Label
            Label lblSearch = new Label();
            lblSearch.Text = "Search by Name or ID:";
            lblSearch.Location = new Point(30, 175);
            lblSearch.AutoSize = true;
            this.Controls.Add(lblSearch);

            // Search TextBox
            txtSearch = new TextBox();
            txtSearch.Location = new Point(180, 170);
            txtSearch.Width = 200;
            this.Controls.Add(txtSearch);

            // Search Button
            btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Location = new Point(400, 168);
            btnSearch.Size = new Size(90, 30);
            btnSearch.Click += btnSearch_Click;
            this.Controls.Add(btnSearch);

            // Refresh Button
            btnRefresh = new Button();
            btnRefresh.Text = "Show All";
            btnRefresh.Location = new Point(500, 168);
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.Click += btnRefresh_Click;
            this.Controls.Add(btnRefresh);

            // DataGridView
            dgvProducts = new DataGridView();
            dgvProducts.Name = "dgvProducts";
            dgvProducts.Location = new Point(30, 220);
            dgvProducts.Size = new Size(820, 350);
            dgvProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.CellClick += dgvProducts_CellClick;
            this.Controls.Add(dgvProducts);
        }

        // FORM LOAD
        private async void ProductForm_Load(object? sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        // LOAD ALL PRODUCTS FROM API
        private async System.Threading.Tasks.Task LoadProductsAsync()
        {
            try
            {
                allProducts = await _apiClient.GetAllProductsAsync();

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = allProducts.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load products.\n" + ex.Message,
                    "API Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ADD PRODUCT
        private async void btnAdd_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!ValidateProductInputs(
                    out string productName,
                    out decimal price,
                    out int quantity))
                    return;

                ProductDto product = new ProductDto
                {
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                };

                var result = await _apiClient.CreateProductAsync(product);

                if (result != null)
                {
                    MessageBox.Show("Product added successfully!");

                    ClearFields();
                    txtSearch.Clear();
                    await LoadProductsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add product: " + ex.Message);
            }
        }

        // UPDATE PRODUCT
        private async void btnUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (selectedProductId == 0)
                {
                    MessageBox.Show("Please select a product first.");
                    return;
                }

                if (!ValidateProductInputs(
                    out string productName,
                    out decimal price,
                    out int quantity))
                    return;

                ProductDto product = new ProductDto
                {
                    Id = selectedProductId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                };

                var result = await _apiClient.UpdateProductAsync(
                    selectedProductId, product);

                if (result != null)
                {
                    MessageBox.Show("Product updated successfully!");

                    ClearFields();
                    txtSearch.Clear();
                    await LoadProductsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update product: " + ex.Message);
            }
        }

        // DELETE PRODUCT
        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                if (selectedProductId == 0)
                {
                    MessageBox.Show("Please select a product first.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                bool deleted = await _apiClient.DeleteProductAsync(
                    selectedProductId);

                if (deleted)
                {
                    MessageBox.Show("Product deleted successfully!");

                    ClearFields();
                    txtSearch.Clear();
                    await LoadProductsAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete product: " + ex.Message);
            }
        }

        // SEARCH PRODUCT BY NAME OR ID
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a product name or ID.");
                return;
            }

            var filteredProducts = allProducts
                .Where(p =>
                    p.ProductName.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase)
                    ||
                    p.Id.ToString().Contains(searchText))
                .ToList();

            dgvProducts.DataSource = null;
            dgvProducts.DataSource = filteredProducts;

            ClearFields();

            if (filteredProducts.Count == 0)
            {
                MessageBox.Show("No matching products found.");
            }
        }

        // SHOW ALL PRODUCTS
        private async void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            ClearFields();
            await LoadProductsAsync();
        }

        // SELECT PRODUCT FROM TABLE
        private void dgvProducts_CellClick(
            object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProducts.Rows[e.RowIndex];

                selectedProductId = Convert.ToInt32(
                    row.Cells["Id"].Value);

                txtProductName.Text =
                    row.Cells["ProductName"].Value?.ToString() ?? "";

                txtPrice.Text =
                    row.Cells["Price"].Value?.ToString() ?? "";

                txtQuantity.Text =
                    row.Cells["Quantity"].Value?.ToString() ?? "";
            }
        }

        // VALIDATE INPUTS
        private bool ValidateProductInputs(
            out string productName,
            out decimal price,
            out int quantity)
        {
            productName = txtProductName.Text.Trim();
            price = 0;
            quantity = 0;

            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Please enter product name.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative price.");
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out quantity) ||
                quantity < 0)
            {
                MessageBox.Show("Please enter a valid non-negative quantity.");
                return false;
            }

            return true;
        }

        // CLEAR INPUT FIELDS
        private void ClearFields()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();

            selectedProductId = 0;
            dgvProducts.ClearSelection();
        }

        // FORM CLICK EVENT
        private void ProductForm_Click(object? sender, EventArgs e)
        {
        }
    }
}
