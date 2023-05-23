namespace Client;



class ChatPanel : MyPanel
{
    private Size defaultTitleLabelSize = new Size(940, 30);
    private Size defaultButtonCloseSize = new Size(30, 30);

    private Point defaultTitleLabeLocation = new Point(0, 0);
    private Point defaultButtonCloseLocation = new Point(900, 0);

    public ChatPanel() 
    {

        this.Dock = DockStyle.Fill;
        this.BackColor = Color.FromArgb(255, 13, 22, 33);
        this.setPanelHeader(defaultTitleLabelSize, defaultTitleLabeLocation, defaultButtonCloseSize, defaultButtonCloseLocation);
        
        lbMessages = new ListBox();
        lbMessages.FormattingEnabled = true;
        lbMessages.Location = new System.Drawing.Point(10, 45);
        lbMessages.Name = "lbMessages";
        lbMessages.Font = new Font("Arial", 15, FontStyle.Bold);
        lbMessages.Size = new System.Drawing.Size(560, 365);
        lbMessages.BackColor = Color.FromArgb(255, 36,47,61);
        lbMessages.BorderStyle = BorderStyle.None;
        lbMessages.ForeColor = Color.WhiteSmoke;
        lbMessages.SelectionMode = SelectionMode.None;

        bgTbMessage = new Label();
        bgTbMessage.Size = new System.Drawing.Size(300, 38);
        bgTbMessage.Location = new System.Drawing.Point(200, 417);
        bgTbMessage.BackColor = Color.FromArgb(255, 36,47,61);

        tbMessage = new TextBox();
        tbMessage.Location = new System.Drawing.Point(210, 426);
        tbMessage.Name = "tbMessage";
        tbMessage.Width = 280;
        tbMessage.AutoSize = true;
        tbMessage.ForeColor = Color.WhiteSmoke;
        tbMessage.BackColor = Color.FromArgb(255, 36,47,61);
        tbMessage.BorderStyle = BorderStyle.None;
        tbMessage.Multiline = true;
        tbMessage.Font = new Font("Arial", 13, FontStyle.Regular);

        chooseImageButton = new Button();
        chooseImageButton.Location = new System.Drawing.Point(10, 417);
        chooseImageButton.Size = new System.Drawing.Size(60, 38);
        chooseImageButton.Text = "Choose Image";
        chooseImageButton.FlatStyle = FlatStyle.Flat;
        chooseImageButton.FlatAppearance.BorderSize = 0;
        chooseImageButton.UseVisualStyleBackColor = true;
        chooseImageButton.BackColor = Color.FromArgb(255, 36,47,61);

        sendImageButton = new Button();
        sendImageButton.Location = new System.Drawing.Point(80, 417);
        sendImageButton.Size = new System.Drawing.Size(60, 38);
        sendImageButton.Text = "Send Image";
        sendImageButton.FlatStyle = FlatStyle.Flat;
        sendImageButton.FlatAppearance.BorderSize = 0;
        sendImageButton.UseVisualStyleBackColor = true;
        sendImageButton.BackColor = Color.FromArgb(255, 36,47,61);

        sendButton = new Button();
        sendButton.Location = new System.Drawing.Point(510, 417);
        sendButton.Size = new System.Drawing.Size(60, 38);
        sendButton.Text = "Send";
        sendButton.FlatStyle = FlatStyle.Flat;
        sendButton.FlatAppearance.BorderSize = 0;
        sendButton.UseVisualStyleBackColor = true;
        sendButton.BackColor = Color.FromArgb(255, 36,47,61);
        


        ListBox lbEmojis = new ListBox();
        lbEmojis.AutoSize = false;
        
        lbEmojis.Size = new System.Drawing.Size(40, 40);
        lbEmojis.ForeColor = Color.WhiteSmoke;
        lbEmojis.BackColor = Color.FromArgb(255, 36,47,61);
        lbEmojis.BorderStyle = BorderStyle.None;
        lbEmojis.Padding = new Padding(5);
        lbEmojis.Location = new System.Drawing.Point(150, 417);
        lbEmojis.Font = new Font("Arial", 13, FontStyle.Regular);
        string[] emojis = { "😀", "😊", "😂", "😍", "🤔" };

        lbEmojis.Items.AddRange(emojis);

        lbEmojis.SelectedIndexChanged += (s, e) =>
        {
            var selectedEmoji = lbEmojis.SelectedItem;
            if(selectedEmoji != null) tbMessage.Text += selectedEmoji.ToString();
        };

        lastImageBox = new PictureBox();
        lastImageBox.BackColor = Color.FromArgb(255, 36,47,61);
        lastImageBox.Width = 335;
        lastImageBox.Height = 380;
        lastImageBox.Location = new Point(585, 75);
        lastImageBox.SizeMode = PictureBoxSizeMode.Zoom;

        imageUsernameLabel = new Label();
        imageUsernameLabel.Text = "Image sender name: ";
        imageUsernameLabel.Font = new Font("Arial", 13, FontStyle.Regular);
        // imageUsernameLabel.TextAlign = ContentAlignment.MiddleCenter;
        imageUsernameLabel.Size = new System.Drawing.Size(335, 25);
        imageUsernameLabel.Location = new System.Drawing.Point(590, 45);


        this.Controls.Add(lbMessages);
        this.Controls.Add(tbMessage);
        this.Controls.Add(sendButton);
        this.Controls.Add(bgTbMessage);
        this.Controls.Add(chooseImageButton);
        this.Controls.Add(sendImageButton);
        this.Controls.Add(lbEmojis);
        this.Controls.Add(lastImageBox);
        this.Controls.Add(imageUsernameLabel);
        tbMessage.BringToFront();
    }


    public Button getSendButton()
    {
        return this.sendButton;
    }

    public ListBox getMessages()
    {
        return this.lbMessages;
    }

    public TextBox getInputField()
    {
        return this.tbMessage;
    }

    public Button getImageInputButton()
    {
        return this.chooseImageButton;
    }

    public Button getImageSendButton()
    {
        return this.sendImageButton;
    }

    public PictureBox getLastImageBox() 
    {
        return this.lastImageBox;
    }


    public void setImageSenderName(string name)
    {
        imageUsernameLabel.Text = "Image sender name: " + name;
    }


    private ListBox lbMessages;
    private TextBox tbMessage;
    private Button sendButton;
    private Label bgTbMessage;
    private Button chooseImageButton;
    private Button sendImageButton;
    private PictureBox lastImageBox;

    private Label imageUsernameLabel;
}