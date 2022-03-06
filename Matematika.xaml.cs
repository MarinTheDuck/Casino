namespace Casino;

public partial class Matematika : ContentPage
{
	private static int gogdgovor;

	[Obsolete]
	public Matematika()
    {
        InitializeComponent();
		loadComponents();
    }

    private static Tuple<string, int> Jednakost()
    {
        Random rng = new Random();
        var tupleList = new List<Tuple<string, int>>
        {
             Tuple.Create("1 + 7 = ", 8),
             Tuple.Create("2 + 4 / 2 = ", 4),
             Tuple.Create("2*6=", 12),
             Tuple.Create("7-2=", 5),
             Tuple.Create("2+1=", 3),
             Tuple.Create("6*3-7=", 11),
             Tuple.Create("4*1/2+3=", 5),
             Tuple.Create("4+3*2+8/2=", 14),
             Tuple.Create("4+1+7-4=", 8),
             Tuple.Create("1+4-2=", 3),
             Tuple.Create("6+5-4+3-2+1=", 9),
             Tuple.Create("4*3*2*1=", 24),
             Tuple.Create("6+4-2-5+2=", 5),
             Tuple.Create("23-20+3=", 6),
             Tuple.Create("4*0/2+2/6*0+1=", 1),
             Tuple.Create("2+6/2=", 5),
             Tuple.Create("9+1-2=", 8),
             Tuple.Create("22-22+1=", 1),
             Tuple.Create("100-22-22-33=", 13)
        };
        int r1 = rng.Next(0, 19);
        return tupleList[r1];
    }


	[Obsolete]
	private async void loadComponents()
	{
		string name = (string)Application.Current.Properties["username"];
		User user = await App.Database.GetUserByNameAsync(name);
		Money.Text = $"Na računu imate: {user.Money.ToString()} GOGI Coina";

		Random rng = new Random();
		int r1 = rng.Next(1, 6);
		Tuple<string, int> jednakost = Jednakost();

		Izraz.Text = $"Izraz: [{jednakost.Item1}]";

		gogdgovor = jednakost.Item2 + r1;
	}

	[Obsolete]
	private async void Provjeri_Button_Clicked(object sender, EventArgs e)
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

		if (string.IsNullOrEmpty(Rezultat.Text))
		{
			Rezultat.Text = "";
			return;
		}

		if (!int.TryParse(Rezultat.Text, out _))
		{
			Rezultat.Text = "";
			return;
		}

		Gout.Text = $"Gordan kaže: [{gogdgovor}]";
		

		int rezultat = Math.Abs(Convert.ToInt32(Rezultat.Text));
		if (rezultat == gogdgovor)
		{
			user.Money += ulog*3;
		}
		else
		{
			user.Money -= ulog;
		}
		Ulog.Text = "";

		await App.Database.UpdateUserAsync(user);
		Money.Text = $"Na računu imate: {user.Money.ToString()} GOGI Coina";

		Random rng = new Random();
		int r1 = rng.Next(1, 6);
		Tuple<string, int> jednakost = Jednakost();

		Izraz.Text = $"Izraz: [{jednakost.Item1}]";

		gogdgovor = jednakost.Item2 + r1;

		return;
	}
}