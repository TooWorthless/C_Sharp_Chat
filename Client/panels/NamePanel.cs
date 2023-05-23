namespace Client;



class NamePanel : MyPanel
{
    private Size defaultTitleLabelSize = new Size(420, 30);
    private Size defaultButtonCloseSize = new Size(30, 30);

    private Point defaultTitleLabeLocation = new Point(0, 0);
    private Point defaultButtonCloseLocation = new Point(380, 0);

    public NamePanel() 
    {

        this.Dock = DockStyle.Fill;
        this.BackColor = Color.FromArgb(255, 13, 22, 33);
        this.setPanelHeader(defaultTitleLabelSize, defaultTitleLabeLocation, defaultButtonCloseSize, defaultButtonCloseLocation);

        //
        // labelName
        //
        enterNameLabel = new Label();
        enterNameLabel.Text = "Enter your nickname";
        enterNameLabel.Font = new Font("Arial", 13, FontStyle.Regular);
        enterNameLabel.TextAlign = ContentAlignment.MiddleCenter;
        enterNameLabel.Size = new System.Drawing.Size(420, 20);
        enterNameLabel.Location = new System.Drawing.Point(0, 40);

        // 
        // tbName
        // 
        tbName = new System.Windows.Forms.TextBox();
        tbName.Location = new System.Drawing.Point(130, 75);
        tbName.Name = "tbName";
        tbName.AutoSize = false;
        // tbName.Width = 160;
        tbName.Size = new System.Drawing.Size(160, 25);
        tbName.ForeColor = Color.WhiteSmoke;
        tbName.BackColor = Color.FromArgb(255, 36,47,61);
        tbName.BorderStyle = BorderStyle.None;
        tbName.Font = new Font("Arial", 14, FontStyle.Regular);

        //
        // btnConnect
        //
        setNameButton = new System.Windows.Forms.Button();
        setNameButton.Location = new System.Drawing.Point(180, 115);
        setNameButton.Name = "btnConnect";
        setNameButton.Size = new System.Drawing.Size(60, 25);
        setNameButton.BackColor = Color.FromArgb(255, 36,47,61);
        setNameButton.Text = "Connect";
        setNameButton.FlatStyle = FlatStyle.Flat;
        setNameButton.FlatAppearance.BorderSize = 0;

        this.Controls.Add(enterNameLabel);
        this.Controls.Add(tbName);
        this.Controls.Add(setNameButton);
    }


    public Button getNameButton() 
    {
        return this.setNameButton;
    }

    public string getTbNameValue()
    {
        return this.tbName.Text;
    }


    private Label enterNameLabel;
    private TextBox tbName;
    private Button setNameButton;

}


