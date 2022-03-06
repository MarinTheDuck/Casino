namespace Casino;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void Register_Button_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(UsernameInput.Text))
        {
            await App.Database.SaveUserAsync(
                new User
                {
                    Name = UsernameInput.Text,
                    Password = PasswordInput.Text,
                    Money = 1000
                });
        }

        UsernameInput.Text = "";
        PasswordInput.Text = "";
    }

    [Obsolete]
    private async void Login_Button_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(UsernameInput.Text))
        {
            var users = await App.Database.GetUsersAsync();
            foreach (var user in users)
            {
                if (user.Name == UsernameInput.Text && user.Password == PasswordInput.Text)
                {
                    Application.Current.Properties["username"] = user.Name;
                    await Navigation.PushAsync(new NavigationPage(new Games()));
                    break;
                }
            }
        }

        UsernameInput.Text = "";
        PasswordInput.Text = "";
    }
}

