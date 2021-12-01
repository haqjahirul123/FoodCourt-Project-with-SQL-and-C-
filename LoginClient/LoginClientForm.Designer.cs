namespace LoginClient
{
    partial class LoginClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordRestaurantLabel = new System.Windows.Forms.Label();
            this.emailRestaurantLabel = new System.Windows.Forms.Label();
            this.loginRestaurantButton = new System.Windows.Forms.Button();
            this.restaurantPasswordTextBox = new System.Windows.Forms.TextBox();
            this.restaurantEmailTextBox = new System.Windows.Forms.TextBox();
            this.customerGroupBox = new System.Windows.Forms.GroupBox();
            this.restaurantGroupBox = new System.Windows.Forms.GroupBox();
            this.AdminGroupBox = new System.Windows.Forms.GroupBox();
            this.AdminEmailLabel = new System.Windows.Forms.Label();
            this.AdminEmailTextBox = new System.Windows.Forms.TextBox();
            this.AdminPasswordLabel = new System.Windows.Forms.Label();
            this.AdminPasswordTextBox = new System.Windows.Forms.TextBox();
            this.AdminLoginButton = new System.Windows.Forms.Button();
            this.customerGroupBox.SuspendLayout();
            this.restaurantGroupBox.SuspendLayout();
            this.AdminGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(36, 40);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(100, 23);
            this.EmailTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(36, 87);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(48, 116);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(69, 19);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(36, 15);
            this.emailLabel.TabIndex = 3;
            this.emailLabel.Text = "Email";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(57, 66);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(57, 15);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // passwordRestaurantLabel
            // 
            this.passwordRestaurantLabel.AutoSize = true;
            this.passwordRestaurantLabel.Location = new System.Drawing.Point(57, 66);
            this.passwordRestaurantLabel.Name = "passwordRestaurantLabel";
            this.passwordRestaurantLabel.Size = new System.Drawing.Size(57, 15);
            this.passwordRestaurantLabel.TabIndex = 9;
            this.passwordRestaurantLabel.Text = "Password";
            // 
            // emailRestaurantLabel
            // 
            this.emailRestaurantLabel.AutoSize = true;
            this.emailRestaurantLabel.Location = new System.Drawing.Point(69, 19);
            this.emailRestaurantLabel.Name = "emailRestaurantLabel";
            this.emailRestaurantLabel.Size = new System.Drawing.Size(36, 15);
            this.emailRestaurantLabel.TabIndex = 8;
            this.emailRestaurantLabel.Text = "Email";
            // 
            // loginRestaurantButton
            // 
            this.loginRestaurantButton.Location = new System.Drawing.Point(48, 116);
            this.loginRestaurantButton.Name = "loginRestaurantButton";
            this.loginRestaurantButton.Size = new System.Drawing.Size(75, 23);
            this.loginRestaurantButton.TabIndex = 7;
            this.loginRestaurantButton.Text = "Login";
            this.loginRestaurantButton.UseVisualStyleBackColor = true;
            this.loginRestaurantButton.Click += new System.EventHandler(this.LoginRestaurantButton_Click);
            // 
            // restaurantPasswordTextBox
            // 
            this.restaurantPasswordTextBox.Location = new System.Drawing.Point(36, 87);
            this.restaurantPasswordTextBox.Name = "restaurantPasswordTextBox";
            this.restaurantPasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.restaurantPasswordTextBox.TabIndex = 6;
            // 
            // restaurantEmailTextBox
            // 
            this.restaurantEmailTextBox.Location = new System.Drawing.Point(36, 40);
            this.restaurantEmailTextBox.Name = "restaurantEmailTextBox";
            this.restaurantEmailTextBox.Size = new System.Drawing.Size(100, 23);
            this.restaurantEmailTextBox.TabIndex = 5;
            // 
            // customerGroupBox
            // 
            this.customerGroupBox.Controls.Add(this.emailLabel);
            this.customerGroupBox.Controls.Add(this.EmailTextBox);
            this.customerGroupBox.Controls.Add(this.PasswordTextBox);
            this.customerGroupBox.Controls.Add(this.loginButton);
            this.customerGroupBox.Controls.Add(this.passwordLabel);
            this.customerGroupBox.Location = new System.Drawing.Point(53, 96);
            this.customerGroupBox.Name = "customerGroupBox";
            this.customerGroupBox.Size = new System.Drawing.Size(181, 155);
            this.customerGroupBox.TabIndex = 10;
            this.customerGroupBox.TabStop = false;
            this.customerGroupBox.Text = "Customer";
            // 
            // restaurantGroupBox
            // 
            this.restaurantGroupBox.Controls.Add(this.emailRestaurantLabel);
            this.restaurantGroupBox.Controls.Add(this.restaurantEmailTextBox);
            this.restaurantGroupBox.Controls.Add(this.passwordRestaurantLabel);
            this.restaurantGroupBox.Controls.Add(this.restaurantPasswordTextBox);
            this.restaurantGroupBox.Controls.Add(this.loginRestaurantButton);
            this.restaurantGroupBox.Location = new System.Drawing.Point(287, 96);
            this.restaurantGroupBox.Name = "restaurantGroupBox";
            this.restaurantGroupBox.Size = new System.Drawing.Size(181, 155);
            this.restaurantGroupBox.TabIndex = 11;
            this.restaurantGroupBox.TabStop = false;
            this.restaurantGroupBox.Text = "Restaurant";
            // 
            // AdminGroupBox
            // 
            this.AdminGroupBox.Controls.Add(this.AdminEmailLabel);
            this.AdminGroupBox.Controls.Add(this.AdminEmailTextBox);
            this.AdminGroupBox.Controls.Add(this.AdminPasswordLabel);
            this.AdminGroupBox.Controls.Add(this.AdminPasswordTextBox);
            this.AdminGroupBox.Controls.Add(this.AdminLoginButton);
            this.AdminGroupBox.Location = new System.Drawing.Point(508, 96);
            this.AdminGroupBox.Name = "AdminGroupBox";
            this.AdminGroupBox.Size = new System.Drawing.Size(181, 155);
            this.AdminGroupBox.TabIndex = 12;
            this.AdminGroupBox.TabStop = false;
            this.AdminGroupBox.Text = "Admin";
            // 
            // AdminEmailLabel
            // 
            this.AdminEmailLabel.AutoSize = true;
            this.AdminEmailLabel.Location = new System.Drawing.Point(69, 19);
            this.AdminEmailLabel.Name = "AdminEmailLabel";
            this.AdminEmailLabel.Size = new System.Drawing.Size(36, 15);
            this.AdminEmailLabel.TabIndex = 8;
            this.AdminEmailLabel.Text = "Email";
            // 
            // AdminEmailTextBox
            // 
            this.AdminEmailTextBox.Location = new System.Drawing.Point(36, 40);
            this.AdminEmailTextBox.Name = "AdminEmailTextBox";
            this.AdminEmailTextBox.Size = new System.Drawing.Size(100, 23);
            this.AdminEmailTextBox.TabIndex = 5;
            // 
            // AdminPasswordLabel
            // 
            this.AdminPasswordLabel.AutoSize = true;
            this.AdminPasswordLabel.Location = new System.Drawing.Point(57, 66);
            this.AdminPasswordLabel.Name = "AdminPasswordLabel";
            this.AdminPasswordLabel.Size = new System.Drawing.Size(57, 15);
            this.AdminPasswordLabel.TabIndex = 9;
            this.AdminPasswordLabel.Text = "Password";
            // 
            // AdminPasswordTextBox
            // 
            this.AdminPasswordTextBox.Location = new System.Drawing.Point(36, 87);
            this.AdminPasswordTextBox.Name = "AdminPasswordTextBox";
            this.AdminPasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.AdminPasswordTextBox.TabIndex = 6;
            // 
            // AdminLoginButton
            // 
            this.AdminLoginButton.Location = new System.Drawing.Point(48, 116);
            this.AdminLoginButton.Name = "AdminLoginButton";
            this.AdminLoginButton.Size = new System.Drawing.Size(75, 23);
            this.AdminLoginButton.TabIndex = 7;
            this.AdminLoginButton.Text = "Login";
            this.AdminLoginButton.UseVisualStyleBackColor = true;
            this.AdminLoginButton.Click += new System.EventHandler(this.AdminLoginButton_Click);
            // 
            // LoginClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 340);
            this.Controls.Add(this.AdminGroupBox);
            this.Controls.Add(this.restaurantGroupBox);
            this.Controls.Add(this.customerGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginClientForm";
            this.Text = "Food Rescue Login";
            this.customerGroupBox.ResumeLayout(false);
            this.customerGroupBox.PerformLayout();
            this.restaurantGroupBox.ResumeLayout(false);
            this.restaurantGroupBox.PerformLayout();
            this.AdminGroupBox.ResumeLayout(false);
            this.AdminGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label emailLabel;
        private Label passwordLabel;
        private TextBox EmailTextBox;
        private TextBox PasswordTextBox;
        private Label passwordRestaurantLabel;
        private Label emailRestaurantLabel;
        private Button loginRestaurantButton;
        private TextBox restaurantPasswordTextBox;
        private TextBox restaurantEmailTextBox;
        private GroupBox customerGroupBox;
        private GroupBox restaurantGroupBox;
        private GroupBox AdminGroupBox;
        private Label AdminEmailLabel;
        private TextBox AdminEmailTextBox;
        private Label AdminPasswordLabel;
        private TextBox AdminPasswordTextBox;
        private Button AdminLoginButton;
    }
}