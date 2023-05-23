namespace Client;

using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

partial class Form1
{
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {

        Label titleLabel = new Label();
        titleLabel.Text = "Anonymous chat";
        titleLabel.ForeColor = Color.WhiteSmoke;
        titleLabel.BackColor = Color.FromArgb(255, 23, 33, 43);
        titleLabel.Font = new Font("Arial", 13, FontStyle.Bold);
        titleLabel.Size = new System.Drawing.Size(420, 30);
        // titleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        titleLabel.Location = new System.Drawing.Point(0, 0);
        titleLabel.MouseDown += new MouseEventHandler(MyForm_MouseDown);
        
        // titleLabel.Size = new System.Drawing.Size(200, 40);
        titleLabel.Padding = new Padding(5);
        // titleLabel.TabIndex = 1;
        

        // Создаем кнопку закрытия программы и добавляем ее на панель заголовка
        Button closeButton = new Button();
        closeButton.Text = "✖";
        closeButton.ForeColor = Color.WhiteSmoke;
        closeButton.FlatStyle = FlatStyle.Flat;
        closeButton.FlatAppearance.BorderSize = 0;
        closeButton.BackColor = Color.FromArgb(255, 23, 33, 43);
        closeButton.Font = new Font("Arial", 11, FontStyle.Regular);
        // closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        closeButton.Location = new System.Drawing.Point(390, 0);
        // closeButton.Padding = new Padding(10);
        closeButton.Size = new System.Drawing.Size(30, 30);
        // closeButton.Click += CloseButton_Click;
        closeButton.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        closeButton.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);
        closeButton.MouseEnter += new EventHandler((object sender, EventArgs e) => {
            ((Button)sender).ForeColor = Color.Red;
        });
        closeButton.MouseLeave += new EventHandler((object sender, EventArgs e) => {
            ((Button)sender).ForeColor = Color.WhiteSmoke;
        });
        closeButton.Click += new EventHandler((object sender, EventArgs e) => {
            Form_Closing();
        });
        // this.groupBox.SendToBack();

        // titleLabel.BringToFront();
        // closeButton.BringToFront();

        // this.Controls.Add(groupBox);
        this.Controls.Add(titleLabel);
        this.Controls.Add(closeButton);

        // this.groupBox.SendToBack();

        titleLabel.BringToFront();
        closeButton.BringToFront();



        this.tbName = new System.Windows.Forms.TextBox();
        this.btnConnect = new System.Windows.Forms.Button();
        this.lbMessages = new System.Windows.Forms.ListBox();
        this.tbMessage = new System.Windows.Forms.TextBox();
        this.btnSend = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // label name
        //
        this.enterNameLabel = new Label();
        this.enterNameLabel.Text = "Enter your nickname: ";
        this.enterNameLabel.Font = new Font("Arial", 10, FontStyle.Regular);
        this.enterNameLabel.Size = new System.Drawing.Size(140, 15);
        this.enterNameLabel.Location = new System.Drawing.Point(16, 40);
        this.Controls.Add(enterNameLabel);
        // 
        // tbName
        // 
        this.tbName.Location = new System.Drawing.Point(16, 65);
        this.tbName.Name = "tbName";
        this.tbName.AutoSize = false;
        this.tbName.Size = new System.Drawing.Size(125, 20);
        this.tbName.TabIndex = 0;
        this.tbName.ForeColor = Color.WhiteSmoke;
        this.tbName.BackColor = Color.FromArgb(255, 36,47,61);
        this.tbName.BorderStyle = BorderStyle.None;
        this.tbName.Font = new Font("Arial", 13, FontStyle.Regular);
        //
        // btnConnect
        //
        this.btnConnect.Location = new System.Drawing.Point(151, 65);
        this.btnConnect.Name = "btnConnect";
        this.btnConnect.Size = new System.Drawing.Size(60, 20);
        this.btnConnect.TabIndex = 4;
        this.btnConnect.BackColor = Color.FromArgb(255, 36,47,61);
        this.btnConnect.Text = "Connect";
        this.btnConnect.FlatStyle = FlatStyle.Flat;
        this.btnConnect.FlatAppearance.BorderSize = 0;
        // SetRoundedRegion(this.btnConnect, 10);
        // this.btnConnect.UseVisualStyleBackColor = true;
        this.btnConnect.Click += new System.EventHandler(this.Btn_Connect);
        this.btnConnect.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        this.btnConnect.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);
        // 
        // lbMessages
        // 
        this.lbMessages.FormattingEnabled = true;
        this.lbMessages.Location = new System.Drawing.Point(16, 105);
        this.lbMessages.Name = "lbMessages";
        this.lbMessages.Font = new Font("Arial", 15, FontStyle.Bold);
        this.lbMessages.Size = new System.Drawing.Size(388, 195);
        this.lbMessages.BackColor = Color.FromArgb(255, 36,47,61);
        this.lbMessages.BorderStyle = BorderStyle.None;
        this.lbMessages.ForeColor = Color.WhiteSmoke;
        this.lbMessages.TabIndex = 1;
        this.lbMessages.SelectionMode = SelectionMode.None;
        //
        //
        //
        Label enterMessageLabel = new Label();
        enterMessageLabel.Text = "Enter message: ";
        enterMessageLabel.Font = new Font("Arial", 10, FontStyle.Regular);
        enterMessageLabel.Size = new System.Drawing.Size(140, 15);
        enterMessageLabel.Location = new System.Drawing.Point(16, 310);
        this.Controls.Add(enterMessageLabel);
        //
        //
        //
        Label bgTbMessage = new Label();
        bgTbMessage.Size = new System.Drawing.Size(271, 34);
        bgTbMessage.Location = new System.Drawing.Point(65, 340);
        bgTbMessage.BackColor = Color.FromArgb(255, 36,47,61);
        this.Controls.Add(bgTbMessage);
        // 
        // tbMessage
        // 
        this.tbMessage.Location = new System.Drawing.Point(68, 348);
        this.tbMessage.Name = "tbMessage";
        this.tbMessage.Width = 266;
        this.tbMessage.AutoSize = true;
        this.tbMessage.TabIndex = 2;
        this.tbMessage.ForeColor = Color.WhiteSmoke;
        this.tbMessage.BackColor = Color.FromArgb(255, 36,47,61);
        this.tbMessage.BorderStyle = BorderStyle.None;
        this.tbMessage.Multiline = true;
        this.tbMessage.Font = new Font("Arial", 13, FontStyle.Regular);
        // 
        // btnSend
        // 
        this.btnSend.Location = new System.Drawing.Point(344, 340);
        this.btnSend.Name = "btnSend";
        this.btnSend.Size = new System.Drawing.Size(60, 34);
        this.btnSend.TabIndex = 3;
        this.btnSend.Text = "Send";
        this.btnSend.FlatStyle = FlatStyle.Flat;
        this.btnSend.FlatAppearance.BorderSize = 0;
        this.btnSend.UseVisualStyleBackColor = true;
        this.btnSend.BackColor = Color.FromArgb(255, 36,47,61);
        this.btnSend.Click += new System.EventHandler(this.Btn_Send);
        this.btnSend.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        this.btnSend.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(420, 380);
        // this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "Form1";
        // this.Text = "Chat App";
        // this.BackColor = Color.FromArgb(255, 36,47,61);
        this.BackColor = Color.FromArgb(255, 13, 22, 33);
        // this.TransparencyKey = Color.FromArgb(255, 51, 51, 51);
        this.ForeColor = Color.WhiteSmoke;
        this.ControlBox = false; // Скрываем кнопки управления окном (минимизировать, восстановить, закрыть)
        this.Text = ""; // Скрываем заголовок окна
        this.FormBorderStyle = FormBorderStyle.None;

        // this.FormClosing += new FormClosingEventHandler(Form_Closing);
        this.KeyPreview = true;

        // Привязываем обработчик события KeyDown к форме
        this.KeyDown += new KeyEventHandler((object sender, KeyEventArgs e) => {
            if (e.KeyCode == Keys.Enter)
            {
                if(this.username != "") 
                {
                    this.message = this.tbMessage.Text;
                }
            }
        });

        ListBox lbEmojis = new ListBox();
        lbEmojis.AutoSize = false;
        
        lbEmojis.Size = new System.Drawing.Size(40, 40);
        lbEmojis.ForeColor = Color.WhiteSmoke;
        lbEmojis.BackColor = Color.FromArgb(255, 36,47,61);
        lbEmojis.BorderStyle = BorderStyle.None;
        lbEmojis.Padding = new Padding(5);
        lbEmojis.Location = new System.Drawing.Point(16, 340);
        lbEmojis.Font = new Font("Arial", 13, FontStyle.Regular);
        string[] emojis = { "😀", "😊", "😂", "😍", "🤔" };
        lbEmojis.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        lbEmojis.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);

        // Добавляем смайлики в ListBox
        lbEmojis.Items.AddRange(emojis);

        // Привязываем обработчик события SelectedIndexChanged к ListBox
        lbEmojis.SelectedIndexChanged += (s, e) =>
        {
            // Получаем выбранный смайлик
            string selectedEmoji = lbEmojis.SelectedItem as string;

            // Добавляем выбранный смайлик в Label
            tbMessage.Text += selectedEmoji;
        };

        this.Controls.Add(this.btnSend);
        this.Controls.Add(this.btnConnect);
        this.Controls.Add(this.tbMessage);
        this.Controls.Add(this.lbMessages);
        this.Controls.Add(this.tbName);
        
        this.Controls.Add(lbEmojis);
        
        this.ResumeLayout(false);
        this.PerformLayout();

        this.tbMessage.BringToFront();

        this.MouseDown += new MouseEventHandler(MyForm_MouseDown);
    }

    #endregion

    private void MyForm_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }

    private void ChangeCursor_MouseEnter(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Hand;
    }

    private void ChangeCursor_MouseLeave(object sender, EventArgs e)
    {
        this.Cursor = Cursors.Default;
    }
    private System.Windows.Forms.Label enterNameLabel;
    private System.Windows.Forms.TextBox tbName;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.ListBox lbMessages;
    private System.Windows.Forms.TextBox tbMessage;
    private System.Windows.Forms.Button btnSend;
}
