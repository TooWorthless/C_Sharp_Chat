namespace Client;



class RoomsPanel : MyPanel
{
    private Size defaultTitleLabelSize = new Size(420, 30);
    private Size defaultButtonCloseSize = new Size(30, 30);

    private Point defaultTitleLabeLocation = new Point(0, 0);
    private Point defaultButtonCloseLocation = new Point(380, 0);

    public RoomsPanel() 
    {

        this.Dock = DockStyle.Fill;
        this.BackColor = Color.FromArgb(255, 13, 22, 33);
        this.setPanelHeader(defaultTitleLabelSize, defaultTitleLabeLocation, defaultButtonCloseSize, defaultButtonCloseLocation);


        connectGeneralChatButton = new Button();
        connectGeneralChatButton.BackColor = Color.FromArgb(255, 36,47,61);
        connectGeneralChatButton.Text = "Enter general chat";
        connectGeneralChatButton.Font = new Font("Arial", 12, FontStyle.Regular);
        connectGeneralChatButton.FlatStyle = FlatStyle.Flat;
        connectGeneralChatButton.FlatAppearance.BorderSize = 0;
        connectGeneralChatButton.Size = new System.Drawing.Size(180, 30);
        connectGeneralChatButton.Location = new System.Drawing.Point(10, 40);
        

        enterRoomNameLabel = new Label();
        enterRoomNameLabel.Text = "Enter room name: ";
        enterRoomNameLabel.Font = new Font("Arial", 13, FontStyle.Regular);
        enterRoomNameLabel.TextAlign = ContentAlignment.MiddleCenter;
        enterRoomNameLabel.Size = new System.Drawing.Size(180, 20);
        enterRoomNameLabel.Location = new System.Drawing.Point(10, 90);
        

        tbRoomName = new TextBox();
        tbRoomName.AutoSize = false;
        tbRoomName.ForeColor = Color.WhiteSmoke;
        tbRoomName.BackColor = Color.FromArgb(255, 36,47,61);
        tbRoomName.BorderStyle = BorderStyle.None;
        tbRoomName.Font = new Font("Arial", 14, FontStyle.Regular);
        tbRoomName.Size = new System.Drawing.Size(180, 25);
        tbRoomName.Location = new System.Drawing.Point(10, 120);
        
        
        enterRoomPasswordLabel = new Label();
        enterRoomPasswordLabel.Text = "Enter password: ";
        enterRoomPasswordLabel.Font = new Font("Arial", 13, FontStyle.Regular);
        enterRoomPasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
        enterRoomPasswordLabel.Size = new System.Drawing.Size(180, 20);
        enterRoomPasswordLabel.Location = new System.Drawing.Point(10, 155);
        
        
        tbRoomPassword = new TextBox();
        tbRoomPassword.AutoSize = false;
        tbRoomPassword.ForeColor = Color.WhiteSmoke;
        tbRoomPassword.BackColor = Color.FromArgb(255, 36,47,61);
        tbRoomPassword.BorderStyle = BorderStyle.None;
        tbRoomPassword.Font = new Font("Arial", 14, FontStyle.Regular);
        tbRoomPassword.Size = new System.Drawing.Size(180, 25);
        tbRoomPassword.Location = new System.Drawing.Point(10, 185);
        

        connectRoomButton = new Button();
        connectRoomButton.BackColor = Color.FromArgb(255, 36,47,61);
        connectRoomButton.Text = "Enter";
        connectRoomButton.FlatStyle = FlatStyle.Flat;
        connectRoomButton.FlatAppearance.BorderSize = 0;
        connectRoomButton.Font = new Font("Arial", 12, FontStyle.Regular);
        connectRoomButton.Size = new System.Drawing.Size(180, 30);
        connectRoomButton.Location = new System.Drawing.Point(10, 225);

        createRoomLabel = new Label();
        createRoomLabel.Text = "Create room: ";
        createRoomLabel.Font = new Font("Arial", 13, FontStyle.Regular);
        createRoomLabel.TextAlign = ContentAlignment.MiddleCenter;
        createRoomLabel.Size = new System.Drawing.Size(180, 20);
        createRoomLabel.Location = new System.Drawing.Point(220, 45);

        createRoomNameLabel = new Label();
        createRoomNameLabel.Text = "Set room name: ";
        createRoomNameLabel.Font = new Font("Arial", 13, FontStyle.Regular);
        createRoomNameLabel.TextAlign = ContentAlignment.MiddleCenter;
        createRoomNameLabel.Size = new System.Drawing.Size(180, 20);
        createRoomNameLabel.Location = new System.Drawing.Point(220, 90);
        // createRoomPasswordLabel

        tbNewRoomName = new TextBox();
        tbNewRoomName.AutoSize = false;
        tbNewRoomName.ForeColor = Color.WhiteSmoke;
        tbNewRoomName.BackColor = Color.FromArgb(255, 36,47,61);
        tbNewRoomName.BorderStyle = BorderStyle.None;
        tbNewRoomName.Font = new Font("Arial", 14, FontStyle.Regular);
        tbNewRoomName.Size = new System.Drawing.Size(180, 25);
        tbNewRoomName.Location = new System.Drawing.Point(220, 120);

        createRoomPasswordLabel = new Label();
        createRoomPasswordLabel.Text = "Set room password: ";
        createRoomPasswordLabel.Font = new Font("Arial", 13, FontStyle.Regular);
        createRoomPasswordLabel.TextAlign = ContentAlignment.MiddleCenter;
        createRoomPasswordLabel.Size = new System.Drawing.Size(180, 20);
        createRoomPasswordLabel.Location = new System.Drawing.Point(220, 155);

        tbNewRoomPassword = new TextBox();
        tbNewRoomPassword.AutoSize = false;
        tbNewRoomPassword.ForeColor = Color.WhiteSmoke;
        tbNewRoomPassword.BackColor = Color.FromArgb(255, 36,47,61);
        tbNewRoomPassword.BorderStyle = BorderStyle.None;
        tbNewRoomPassword.Font = new Font("Arial", 14, FontStyle.Regular);
        tbNewRoomPassword.Size = new System.Drawing.Size(180, 25);
        tbNewRoomPassword.Location = new System.Drawing.Point(220, 185);

        createRoomButton = new Button();
        createRoomButton.BackColor = Color.FromArgb(255, 36,47,61);
        createRoomButton.Text = "Create";
        createRoomButton.FlatStyle = FlatStyle.Flat;
        createRoomButton.FlatAppearance.BorderSize = 0;
        createRoomButton.Font = new Font("Arial", 12, FontStyle.Regular);
        createRoomButton.Size = new System.Drawing.Size(180, 30);
        createRoomButton.Location = new System.Drawing.Point(220, 225);

        this.Controls.Add(enterRoomNameLabel);
        this.Controls.Add(tbRoomName);
        this.Controls.Add(enterRoomPasswordLabel);
        this.Controls.Add(tbRoomPassword);
        this.Controls.Add(connectRoomButton);
        this.Controls.Add(connectGeneralChatButton);
        this.Controls.Add(createRoomLabel);
        this.Controls.Add(createRoomNameLabel);
        this.Controls.Add(tbNewRoomName);
        this.Controls.Add(createRoomPasswordLabel);
        this.Controls.Add(tbNewRoomPassword);
        this.Controls.Add(createRoomButton);
    }


    public Button getConnectRoomButton()
    {
        return this.connectRoomButton;
    }

    public Button getConnectGeneralRoomButton()
    {
        return this.connectGeneralChatButton;
    }
    public string getTbRoomNameValue()
    {
        return this.tbRoomName.Text;
    }
    public string getTbRoomPasswordValue()
    {
        return this.tbRoomPassword.Text;
    }
    public string getTbNewRoomNameValue()
    {
        return this.tbNewRoomName.Text;
    }
    public string getTbNewRoomPasswordValue()
    {
        return this.tbNewRoomPassword.Text;
    }
    public Button getCreateButton()
    {
        return this.createRoomButton;
    }
    public void setTbRoomNameValue(string newValue)
    {
        this.tbRoomName.Text = newValue;
    }
    public void setTbRoomPasswordValue(string newValue)
    {
        this.tbRoomPassword.Text = newValue;
    }

    private Button connectGeneralChatButton;
    private Label enterRoomNameLabel;
    private TextBox tbRoomName;
    private Label enterRoomPasswordLabel;
    private TextBox tbRoomPassword;
    private Button connectRoomButton;
    private Label createRoomLabel;
    private Label createRoomNameLabel;
    private TextBox tbNewRoomName;
    private Label createRoomPasswordLabel;
    private TextBox tbNewRoomPassword;
    private Button createRoomButton;

}