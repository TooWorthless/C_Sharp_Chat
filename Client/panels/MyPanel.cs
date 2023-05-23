namespace Client;




class MyPanel : Panel
{

    private string titleText = "Anonymous chat";
    public MyPanel() 
    {
        titleLabel = new Label();
        closeButton = new Button();
    }


    public void setPanelHeader(Size labelSize, Point labelLocation, Size btnSize, Point btnLocation)
    {
        // mainPanelLabel
        titleLabel.Text = titleText;
        titleLabel.ForeColor = Color.WhiteSmoke;
        titleLabel.BackColor = Color.FromArgb(255, 23, 33, 43);
        titleLabel.Font = new Font("Arial", 13, FontStyle.Bold);
        titleLabel.Padding = new Padding(3);
        titleLabel.Size = labelSize;
        titleLabel.Location = labelLocation;
        

        // mainPanelCloseBtn
        closeButton.Text = "✖";
        closeButton.ForeColor = Color.WhiteSmoke;
        closeButton.FlatStyle = FlatStyle.Flat;
        closeButton.FlatAppearance.BorderSize = 0;
        closeButton.BackColor = Color.FromArgb(255, 23, 33, 43);
        closeButton.Font = new Font("Arial", 11, FontStyle.Regular);
        closeButton.Size = btnSize;
        closeButton.Location = btnLocation;
        
        this.Controls.Add(titleLabel);
        this.Controls.Add(closeButton);

        titleLabel.BringToFront();
        closeButton.BringToFront();
    }


    public Label getTitleLabel() 
    {
        return this.titleLabel;
    }


    public Button getCloseButton() 
    {
        return this.closeButton;
    }


    public void setTitleText(string newTitle)
    {
        titleLabel.Text = newTitle;
        titleText = newTitle;
    }

    public string getTitleText() 
    {
        return titleText;
    }


    private Label titleLabel;
    private Button closeButton;
}