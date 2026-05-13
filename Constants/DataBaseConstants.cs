using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Proyecto_Evently.Constants;

public static class DataBaseConstants
{
    public const string DatabaseName = "Evently.db";

    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseName);

    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

}
