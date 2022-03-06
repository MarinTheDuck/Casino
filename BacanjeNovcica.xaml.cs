namespace Casino;

public partial class BacanjeNovcica : ContentPage
{
	[Obsolete]
	public BacanjeNovcica()
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
	private async void Pismo_Button_Clicked(object sender, EventArgs e)
    {
		if (!int.TryParse(Ulog.Text, out _))
		{
			Ulog.Text = "";
			return;
		}

		string name = (string)Application.Current.Properties["username"];
		User user = await App.Database.GetUserByNameAsync(name);

		int ulog = Math.Abs(Convert.ToInt32(Ulog.Text));

		if (user.Money < ulog)
		{
			Ulog.Text = "";
			return;
		}

		Random rng = new Random();
		int nv = rng.Next(1, 3);

		if(nv == 1)
			Novcic.Text = "Novčić: [Pismo 📧]";
		else
			Novcic.Text = "Novčić: [Glava 🗣]";

		if (nv == 1)
		{
			user.Money += ulog;
		}
		else
		{
			user.Money -= ulog;
		}
		Ulog.Text = "";

		await App.Database.UpdateUserAsync(user);
		Money.Text = $"Na računu imate: {user.Money.ToString()} GOGI Coina";

		return;
	}

	[Obsolete]
	private async void Glava_Button_Clicked(object sender, EventArgs e)
    {
		if (!int.TryParse(Ulog.Text, out _))
		{
			Ulog.Text = "";
			return;
		}

		string name = (string)Application.Current.Properties["username"];
		User user = await App.Database.GetUserByNameAsync(name);

		int ulog = Math.Abs(Convert.ToInt32(Ulog.Text));

		if (user.Money < ulog)
		{
			Ulog.Text = "";
			return;
		}

		Random rng = new Random();
		int nv = rng.Next(1, 3);

		if (nv == 1)
			Novcic.Text = "Novčić: [Pismo 📧]";
		else
			Novcic.Text = "Novčić: [Glava 🗣]";

		if (nv == 2)
		{
			user.Money += ulog/2;
		}
		else
		{
			user.Money -= ulog;
		}
		Ulog.Text = "";

		await App.Database.UpdateUserAsync(user);
		Money.Text = $"Na računu imate: {user.Money.ToString()} GOGI Coina";

		return;
	}
}