
using SQLite;

namespace StaffContactEntrys;

public partial class StaffSettings : ContentPage
{

    private SQLiteAsyncConnection _database1;

    


    public StaffSettingsViewModel ViewModel { get; set; }

    private StaffUserSettings _userSettings;

    public StaffSettings(StaffUserSettings userSettings)
	{
		InitializeComponent();

      

        _userSettings = userSettings;
        
        ViewModel = new StaffSettingsViewModel();
        BindingContext = ViewModel;



        string dbPath1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Staff_Settings.db");
        _database1 = new SQLiteAsyncConnection(dbPath1);
        _database1.CreateTableAsync<StaffUserSettings>().Wait();



       

        LoadUserSettings();

     


    }

   
  
    

    private async void SaveSettings_Clicked(object sender, EventArgs e)
    {


        bool theme = togTheme.IsToggled;


        int fontSize = (int)fontSizeSlider.Value;
        float brightness = (float)brightnessSlider.Value;
        string selectedFont = fontFamilyPicker.SelectedItem.ToString()!;





        var userSettings = new StaffUserSettings
        {

            lightOrDark = theme,

            SavedFontSize = fontSize,
            SavedBrightness = brightness,
            SavedFontFamily = selectedFont,




        };



        await _database1.InsertOrReplaceAsync(userSettings);

        // Show a confirmation message
        await DisplayAlert("Success", "Staff settings saved", "OK");
    }


    private async void LoadUserSettings()
    {




        // Check if the user settings already exist in the database
        var existingSettings = await _database1.Table<StaffUserSettings>().FirstOrDefaultAsync();
        if (existingSettings != null)
        {
           


            fontSizeSlider.Value = (double)existingSettings.SavedFontSize;
            brightnessSlider.Value = (double)existingSettings.SavedBrightness;
            fontFamilyPicker.SelectedItem = existingSettings.SavedFontFamily;


            if (existingSettings.lightOrDark)
            {
                togTheme.IsToggled = true;
            }
            else
            {
                togTheme.IsToggled = false;
            }

            var currentTheme = existingSettings.lightOrDark;
            if (currentTheme)
                Application.Current.UserAppTheme = AppTheme.Dark;
            else
                Application.Current.UserAppTheme = AppTheme.Light;



        }
    }


    private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
    {
        bool isDarkTheme = e.Value;
        Preferences.Set("DarkThemeOn", isDarkTheme ? "Dark" : "Light");

        // Apply the theme
        if (isDarkTheme)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;





    }

}





