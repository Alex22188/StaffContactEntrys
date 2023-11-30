

using System;


namespace StaffContactEntrys
{

    public partial class MainPage : ContentPage
    {


       
        
        private DatabaseServiceCSV _databaseServiceCSV;


        private List<People> _peoples;





        public MainPage()
        {
            InitializeComponent();


            
            
            _databaseServiceCSV = new DatabaseServiceCSV();

            


            LoadPeopleAsync();







        }


       



        protected override void OnAppearing()
        {
            base.OnAppearing();


            LoadPeopleAsync();





        }

        private async void UpdatePeople_Clicked(object sender, EventArgs e)
        {
            var selectedPeople = (People)((Button)sender).BindingContext;


            await Navigation.PushAsync(new UpdatePeople(selectedPeople, _databaseServiceCSV));
        }

        private async void DeletePeople_Clicked(object sender, EventArgs e)
        {
            var selectedPeople = (People)((Button)sender).BindingContext;
            bool result = await DisplayAlert("Delete Staff", "Are you sure you want to delete this staff member?", "Yes", "No");

            if (result)
            {


                await _databaseServiceCSV.DeletePeopleAsync(selectedPeople);

             

                LoadPeopleAsync();
            }
        }

        private async void ViewPeopleDetails_Clicked(object sender, EventArgs e)
        {
            var selectedPeople = (People)((Button)sender).BindingContext;
            await Navigation.PushAsync(new StaffDetails(selectedPeople));
        }
        
        private async void LoadPeopleAsync()
        {             
            
            try
            {

                _peoples = await _databaseServiceCSV.GetPeopleAsync();

                PeopleListView.ItemsSource = _peoples;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }


        private async void AddPeople_Clicked(object sender, EventArgs e)
        {
            var newPeople = new People
            {
                Id = int.Parse(IdEntry.Text),
                Name = NameEntry.Text,
                Phone = int.Parse(PhoneEntry.Text),
                Department = int.Parse(DepartmentEntry.Text),
                AddressStreet = AddressStreetEntry.Text,
                AddressCity = AddressCityEntry.Text,
                AddressState = AddressStateEntry.Text,
                AddressZIP = int.Parse(AddressZIPEntry.Text),
                AddressCountry = AddressCountryEntry.Text


            };




            await _databaseServiceCSV.AddPeopleAsync(newPeople);



            IdEntry.Text = NameEntry.Text = PhoneEntry.Text = DepartmentEntry.Text = AddressStreetEntry.Text = AddressCityEntry.Text = AddressStateEntry.Text = AddressZIPEntry.Text = AddressCountryEntry.Text = string.Empty;
            LoadPeopleAsync();



        }

        private async void OnSettings_Clicked(object sender, EventArgs e)

        {

            var userSettings = (StaffUserSettings)((Button)sender).BindingContext;
            await Navigation.PushAsync(new StaffSettings(userSettings));
        }









    }


}
    


    


    

    
    
    
    
    
    

