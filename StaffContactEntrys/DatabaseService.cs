
using SQLite;
using StaffContactEntrys;
using System;

public class DatabaseService
{

    SQLiteAsyncConnection _database;


    public DatabaseService()
	{
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Staff_Contact.db");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<StaffUserSettings>().Wait();


    }


    #region C R U D Operations
    public async Task AddPeopleAsync(People people)
    {


        await _database.InsertAsync(people);
    }

    public async Task<List<People>> GetPeopleAsync()
    {
        return await _database.Table<People>().ToListAsync();
    }
    public async Task UpdatePeopleAsync(People people)
    {
        await _database.UpdateAsync(people);
    }

    public async Task DeletePeopleAsync(People people)
    {
        await _database.DeleteAsync(people);

    }


}

    #endregion



