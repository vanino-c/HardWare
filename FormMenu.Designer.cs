namespace Hardware
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSellers = new System.Windows.Forms.Button();
            this.buttonItems = new System.Windows.Forms.Button();
            this.buttonCategories = new System.Windows.Forms.Button();
            this.buttonDeals = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSellers
            // 
            this.buttonSellers.Enabled = false;
            this.buttonSellers.Location = new System.Drawing.Point(12, 32);
            this.buttonSellers.Name = "buttonSellers";
            this.buttonSellers.Size = new System.Drawing.Size(248, 48);
            this.buttonSellers.TabIndex = 0;
            this.buttonSellers.Text = "Управление продавцами";
            this.buttonSellers.UseVisualStyleBackColor = true;
            this.buttonSellers.Click += new System.EventHandler(this.buttonSellers_Click);
            // 
            // buttonItems
            // 
            this.buttonItems.Location = new System.Drawing.Point(12, 86);
            this.buttonItems.Name = "buttonItems";
            this.buttonItems.Size = new System.Drawing.Size(248, 48);
            this.buttonItems.TabIndex = 0;
            this.buttonItems.Text = "Товары";
            this.buttonItems.UseVisualStyleBackColor = true;
            this.buttonItems.Click += new System.EventHandler(this.buttonPhones_Click);
            // 
            // buttonCategories
            // 
            this.buttonCategories.Location = new System.Drawing.Point(12, 140);
            this.buttonCategories.Name = "buttonCategories";
            this.buttonCategories.Size = new System.Drawing.Size(248, 48);
            this.buttonCategories.TabIndex = 0;
            this.buttonCategories.Text = "Категории";
            this.buttonCategories.UseVisualStyleBackColor = true;
            this.buttonCategories.Click += new System.EventHandler(this.buttonProviders_Click);
            // 
            // buttonDeals
            // 
            this.buttonDeals.Location = new System.Drawing.Point(12, 194);
            this.buttonDeals.Name = "buttonDeals";
            this.buttonDeals.Size = new System.Drawing.Size(248, 48);
            this.buttonDeals.TabIndex = 0;
            this.buttonDeals.Text = "Сделки";
            this.buttonDeals.UseVisualStyleBackColor = true;
            this.buttonDeals.Click += new System.EventHandler(this.buttonDeals_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUser.Location = new System.Drawing.Point(12, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(80, 20);
            this.labelUser.TabIndex = 2;
            this.labelUser.Text = "labelUser";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 248);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.buttonDeals);
            this.Controls.Add(this.buttonCategories);
            this.Controls.Add(this.buttonItems);
            this.Controls.Add(this.buttonSellers);
            this.MaximumSize = new System.Drawing.Size(288, 287);
            this.MinimumSize = new System.Drawing.Size(288, 287);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стройтовары";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSellers;
        private System.Windows.Forms.Button buttonItems;
        private System.Windows.Forms.Button buttonCategories;
        private System.Windows.Forms.Button buttonDeals;
        private System.Windows.Forms.Label labelUser;
    }
}

