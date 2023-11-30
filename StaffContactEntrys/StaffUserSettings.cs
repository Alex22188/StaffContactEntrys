

using SQLite;


namespace StaffContactEntrys
{

    public class StaffUserSettings
    {

        [PrimaryKey, AutoIncrement]

        public bool lightOrDark { get; set; }
        public int SavedFontSize { get; set; }
        public float SavedBrightness { get; set; }
        public string SavedFontFamily { get; set; }




    }
}
