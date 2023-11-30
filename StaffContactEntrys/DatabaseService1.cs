using SQLite;
using StaffContactEntrys;
using System;

public class DatabaseService1
{

    SQLiteAsyncConnection _database1;


    public DatabaseService1()
	{

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Staff_Settings.db");
        _database1 = new SQLiteAsyncConnection(databasePath);
        _database1.CreateTableAsync<StaffUserSettings>().Wait();

    }
    #region


    public async Task SaveSettingsAsync(StaffUserSettings userSettings)
    {

        await _database1.InsertOrReplaceAsync(userSettings);
    }
    public async Task<List<StaffUserSettings>> GetUserSettingsAsync()
    {

        return await _database1.Table<StaffUserSettings>().ToListAsync();
    }

   


}


#endregion




