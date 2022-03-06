namespace Casino;

public partial class Slots : ContentPage
{
	[Obsolete]
	public Slots()
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
	private async void Roll_Button_Clicked(object sender, EventArgs e)
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
		List<string> list = new List<string>();
		list.Add("💎");
		list.Add("💎");
		list.Add("💲");
		list.Add("💯");
		list.Add("🥇");
		list.Add("💰");
		int r1 = rng.Next(0, 6);
		int r2 = rng.Next(0, 6);
		int r3 = rng.Next(0, 6);

		Rolled.Text = $"Slots: [{list[r1]}] [{list[r2]}] [{list[r3]}]";

		if (r1 == r2 && r2 == r3)
		{
			if(r1 == 0)
				user.Money += ulog*5;
			else if(r1 == 1)
				user.Money += ulog*2;
			else
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
}