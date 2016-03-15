using Xamarin.Forms;
using AppLar.Droid.Model.DAO;

[assembly: Dependency(typeof(MedicamentoDAO))]
namespace AppLar.Droid.Model.DAO
{
    using System;
	using AppLar.Core.Data;
    using SQLite.Net.Async;
    using System.IO;
    using SQLite.Net.Platform.XamarinAndroid;
    using SQLite.Net;

    public class MedicamentoDAO : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "cache.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                            platform,
                                            new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}