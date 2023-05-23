namespace Client;

using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

partial class MainForm
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

    private void InitializeComponent()
    {
        //
        // MainForm
        //
        this.ClientSize = new System.Drawing.Size(420, 380);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MainForm";
        this.BackColor = Color.Black;
        this.ForeColor = Color.WhiteSmoke;
        this.ControlBox = false;
        this.Text = "";
        this.FormBorderStyle = FormBorderStyle.None;
        this.Padding = new Padding(5);


        //
        // forSettingsFunctions
        //
        void setPanelHeaderFunctions(Label TitleLabel, Button CloseButton)
        {
            TitleLabel.MouseDown += new MouseEventHandler(MyForm_MouseDown);

            CloseButton.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
            CloseButton.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);
            CloseButton.MouseEnter += new EventHandler((object sender, EventArgs e) => {
                ((Button)sender).ForeColor = Color.Red;
            });
            CloseButton.MouseLeave += new EventHandler((object sender, EventArgs e) => {
                ((Button)sender).ForeColor = Color.WhiteSmoke;
            });
            CloseButton.Click += new EventHandler((object sender, EventArgs e) => {
                Form_Closing();
            });
        }

        //
        // NamePanel 
        //
        namePanel = new NamePanel();
        setPanelHeaderFunctions(namePanel.getTitleLabel(), namePanel.getCloseButton());
        Button SetNameButton = namePanel.getNameButton();

        SetNameButton.Click += new System.EventHandler(this.Btn_SetName);
        SetNameButton.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        SetNameButton.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);

        //
        // RoomsPanel
        //
        roomsPanel = new RoomsPanel();
        setPanelHeaderFunctions(roomsPanel.getTitleLabel(), roomsPanel.getCloseButton());
        Button connectRoomButton = roomsPanel.getConnectRoomButton();
        Button connectGeneralRoomButton = roomsPanel.getConnectGeneralRoomButton();
        Button createRoomButton = roomsPanel.getCreateButton();

        connectRoomButton.Click += new System.EventHandler(this.Btn_Connect);
        connectRoomButton.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        connectRoomButton.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);

        connectGeneralRoomButton.Click += new System.EventHandler(this.Btn_ConnectGeneral);
        connectGeneralRoomButton.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        connectGeneralRoomButton.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);

        createRoomButton.Click += new System.EventHandler((object sender, EventArgs e) => {
            string name = roomsPanel.getTbNewRoomNameValue();
            string password = roomsPanel.getTbNewRoomPasswordValue();

            if(name != "" && name != null && name.Length > 0) {
                if(password != "") {
                    Connect(name, password+"|new");
                }
                else {
                    password = "none";
                    Connect(name, password+"|new");
                }
            }
            else {
                MessageBox.Show("Incorrect room name!");
            }
        });
        createRoomButton.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        createRoomButton.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);

        //
        // ChatPanel
        //
        chatPanel = new ChatPanel();
        setPanelHeaderFunctions(chatPanel.getTitleLabel(), chatPanel.getCloseButton());
        Button sendButton = chatPanel.getSendButton();
        Button chooseImageButton = chatPanel.getImageInputButton();
        Button sendImageButton = chatPanel.getImageSendButton();

        sendButton.Click += new System.EventHandler(this.Btn_Send);
        sendButton.MouseEnter += new System.EventHandler(this.ChangeCursor_MouseEnter);
        sendButton.MouseLeave += new System.EventHandler(this.ChangeCursor_MouseLeave);

        chooseImageButton.Click += new System.EventHandler(this.btnLoadImage_Click);
        sendImageButton.Click += new System.EventHandler(this.btnSend_Click);

        this.Controls.Add(namePanel);

        this.MouseDown += new MouseEventHandler(MyForm_MouseDown);
        
    }

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


    private NamePanel namePanel;
    private RoomsPanel roomsPanel;
    private ChatPanel chatPanel;
}
