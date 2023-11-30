namespace StaffContactEntrys;

public partial class StaffDetails : ContentPage
{
    public StaffDetails(People people)
    {
        InitializeComponent();
        BindingContext = people;


    }

    private async void OnBack_Clicked(object sender, EventArgs e)
    {






        bool result = await DisplayAlert("Return to staff contact page", "Are you sure you want to go back?", "Yes", "No");

        if (result)
        {
            await Navigation.PopAsync();
        }

    }
}