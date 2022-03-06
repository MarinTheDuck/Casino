namespace Casino;

public partial class Kockanje : ContentPage
{
	[Obsolete]
	public Kockanje()
	{
		InitializeComponent();
		loadComponents();
	}

	[Obsolete]
	private async void loadComponents()
	{
		string name = (string)Application.Current.Properties["username"];
		User user = await App.Database.GetUserByNameAsync(name);
		Money.Text = $"Na računu imate: {user.Money.ToString()} GOGI Coina";
	}

	[Obsolete]
	private async void BaciKocke_Button_Clicked(object sender, EventArgs e)
    {
		if(!int.TryParse(Ulog.Text, out _))
        {
			Ulog.Text = "";
			return;
        }

		string name = (string)Application.Current.Properties["username"];
		User user = await App.Database.GetUserByNameAsync(name);

		int ulog = Math.Abs(Convert.ToInt32(Ulog.Text));

		if(user.Money < ulog)
		{
			Ulog.Text = "";
			return;
		}

		Random rng = new Random();
		int vk1 = rng.Next(1, 7);
		int vk2 = rng.Next(1, 7);
		int bk1 = rng.Next(1, 7);
		int bk2 = rng.Next(1, 7);

		KockeV.Text = $"Vaše Kocke: [{vk1.ToString()}, {vk2.ToString()}]";
		KockeB.Text = $"Bačene Kocke: [{bk1.ToString()}, {bk2.ToString()}]";
		
		if(vk1+vk2 > bk1 + bk2)
        {
			user.Money += ulog;
		}
		else if (vk1 + vk2 < bk1 + bk2)
        {
			user.Money -= ulog;
		}
		Ulog.Text = "";

		await App.Database.UpdateUserAsync(user);
		Money.Text = $"Na računu imate: {user.Money.ToString()} GOGI Coina";

		return;
	}
}