﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vacuumControl
{
    public partial class LoginPage : Form
    {
        DataModel dm = new DataModel();
        bool yesLogin = false;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_username.Text) && !string.IsNullOrEmpty(tb_password.Text))
            {
                Employee model = dm.personalLogin(tb_username.Text, tb_password.Text);
                if (model != null)
                {
                    if (model.ID != 0)
                    {
                        Form1.LoginUser = model;
                        yesLogin = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Bulunamadı veya silinmiş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bir Hata Oluştu. Lütfen sistem yöneticiniz ile iletişime geçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Ve şifre Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşuna basıldığında btn_login'in Click olayını tetikle
                btn_login.PerformClick();

                // Eğer Enter tuşu ile diğer tuş kombinasyonlarının algılanmasını istemiyorsan
                e.SuppressKeyPress = true;
            }
        }
    }
}
