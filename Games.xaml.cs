namespace Casino;

public partial class Games : ContentPage
{
    [Obsolete]
    public Games()
    {
        InitializeComponent();
        loadComponents();
    }

    [Obsolete]
    private async void loadComponents()
    {
        string name = (string)Application.Current.Properties["username"];
        User user = await App.Database.GetUserByNameAsync(name);
        Title.Text = $"Dobar dan, {user.Name.ToString()}!";
        Money.Text = $"Na računu imate: {user.Money.ToString()} GOGI Coina";
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (Title.Text != "Dobar dan!")
        {
#pragma warning disable CS0612 // Type or member is obsolete
            loadComponents();
#pragma warning restore CS0612 // Type or member is obsolete
        }
        base.OnNavigatedTo(args);
    }

    [Obsolete]
    private async void Kockanje_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Kockanje());
    }

    [Obsolete]
    private async void Slots_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Slots());
    }

    [Obsolete]
    private async void BacanjeNovcica_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BacanjeNovcica());
    }

    [Obsolete]
    private async void Matematika_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Matematika());
    }

}