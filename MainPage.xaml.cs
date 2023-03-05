namespace Interactive_Quiz_By_Gurvir_Singh;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        BindingContext = new QuizViewModel();
    }
}

