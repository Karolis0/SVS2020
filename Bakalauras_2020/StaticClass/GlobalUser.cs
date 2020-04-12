using Bakalauras_2020.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakalauras_2020.StaticClass
{
    static class GlobalUser
    {
        public static string Username { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static int UserLevel { get; set; }
        public static int UserId { get; set; }
        public static bool SuperUser { get; set; }
        public static int CurrentWarehouseId { get; set; }
        public static string CurrentWarehouseName { get; set; }

        public static string GetFullNameSurname()
        {
            return $"{Name} {Surname}";
        }

        public static void ParseDataTable(DataTable data)
        {
            Username = NullCheck.IsNullString(data.Rows[0][nameof(Username)]);
            Name = NullCheck.IsNullString(data.Rows[0][nameof(Name)]);
            Surname = NullCheck.IsNullString(data.Rows[0][nameof(Surname)]);
            UserLevel = NullCheck.IsNullInt(data.Rows[0][nameof(UserLevel)]);
            UserId = NullCheck.IsNullInt(data.Rows[0][nameof(UserId)]);
            SuperUser = NullCheck.IsNullBoolean(data.Rows[0][nameof(SuperUser)]);
            LogLogin();
        }

        private static void LogLogin()
        {
            Sql.LogAction(new object[] {
                "@Procedure", "GetUserData",
                "@Obj1", Username,
                "@Obj1Name", nameof(Username),
                "@Obj2", Name,
                "@Obj2Name", nameof(Name),
                "@Obj3", Surname,
                "@Obj3Name", nameof(Surname),
                "@Obj4", UserLevel,
                "@Obj4Name", nameof(UserLevel),
                "Obj5", DateTime.Now.ToString(),
                "Obj5Name", "Login date"
            });
        }

        public static void SetWarehouseId(int whid)
        {
            CurrentWarehouseName = Sql.GetString($"SELECT dbo.GetWarehouseName({whid})");
            CurrentWarehouseId = whid;
        }
    }
}
