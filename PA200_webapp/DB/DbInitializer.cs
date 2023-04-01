using System.Security.Cryptography;
using PA200_webapp.models;
using PA200_webapp.Utils;

namespace PA200_webapp.DB;

public class DbInitializer
{
    public static void Initialize(SocialNetworkContext context)
    {
        if (context.Walls.Any())
        {
            return;
        }

        var admin = new User()
        {
            Name = "admin",
            Lastname = "admin",
            Email = "admin@example.com",
            Role = UserRole.Admin,
            PasswordHash = PasswordHash.MakePasswordHash("AdminPassword1"),
        };

        var Tom = new User()
        {
            Name = "Tom",
            Lastname = "Shelby",
            Email = "tomshelby@example.com",
            Role = UserRole.Teacher,
            PasswordHash = PasswordHash.MakePasswordHash("password1")
        };

        var Arthur = new User()
        {
            Name = "Arthur",
            Lastname = "Shelby",
            Email = "arthurshelby@example.com",
            Role = UserRole.Teacher,
            PasswordHash = PasswordHash.MakePasswordHash("password1")
        };

        var John = new User()
        {
            Name = "John",
            Lastname = "Shelby",
            Email = "johnshelby@example.com",
            Role = UserRole.Student,
            PasswordHash = PasswordHash.MakePasswordHash("password1")
        };

        var Ada = new User()
        {
            Name = "Ada",
            Lastname = "Shelby",
            Email = "adashelby@example.com",
            Role = UserRole.Student,
            PasswordHash = PasswordHash.MakePasswordHash("password1")
        };
        
        var ShelbySchool = new School()
        {
            Name = "ShelbySchool"
        };

        admin.School = ShelbySchool;
        Tom.School = ShelbySchool;
        Arthur.School = ShelbySchool;
        John.School = ShelbySchool;
        Ada.School = ShelbySchool;

        var globalWall = new Wall();

        ShelbySchool.Wall = globalWall;

        var TomPost = new Post()
        {
            Text = "By order of the peaky blinders",
            Created = DateTime.Parse("2023-03-20").ToUniversalTime(),
            User = Tom,
            Wall = globalWall
        };

        var shelbyWall = new Wall()
        {
        };

        var shelbyClass = new Class()
        {
            Name = "8.A",
            Wall = shelbyWall
        };

        shelbyClass.School = ShelbySchool;
        var AccountingWall = new Wall()
        {
        };

        var AccountingSubject = new Subject()
        {
            Name = "Accounting",
            Wall = AccountingWall
        };

        AccountingSubject.Class = shelbyClass;

        var TomsClass = new UserClass()
        {
            Class = shelbyClass,
            User = Tom,
            From = DateTime.Parse("2023-03-01").ToUniversalTime(),
            To = DateTime.Parse("2023-04-01").ToUniversalTime()
        };

        Tom.UserClasses = new List<UserClass>() { TomsClass };

        Arthur.UserClasses = new List<UserClass>()
        {
            new UserClass()
            {
                Class = shelbyClass,
                User = Arthur,
                From = DateTime.Parse("2023-03-01").ToUniversalTime(),
                To = DateTime.Parse("2023-04-01").ToUniversalTime()
            }
        };

        John.UserClasses = new List<UserClass>()
        {
            new UserClass()
            {
                Class = shelbyClass,
                User = John,
                From = DateTime.Parse("2023-03-01").ToUniversalTime(),
                To = DateTime.Parse("2023-04-01").ToUniversalTime()
            }
        };

        John.UserSubjects = new List<UserSubject>()
        {
            new UserSubject()
            {
                Subject = AccountingSubject,
                User = John,
                From = DateTime.Parse("2023-02-01").ToUniversalTime(),
                To = DateTime.Parse("2023-04-01").ToUniversalTime()
            }
        };

        Tom.UserSubjects = new List<UserSubject>()
        {
            new UserSubject()
            {
                Subject = AccountingSubject,
                User = Tom,
                From = DateTime.Parse("2023-02-01").ToUniversalTime(),
                To = DateTime.Parse("2023-04-01").ToUniversalTime()
            }
        };

        var JohnPost = new Post()
        {
            Created = DateTime.Parse("2023-02-03").ToUniversalTime(),
            Text = "LET'S DO THIS",
            Wall = AccountingWall,
            User = John
        };
        
        context.AddRange(ShelbySchool);
        context.AddRange(admin, Tom, Arthur, John, Ada);
        context.AddRange(shelbyClass);
        context.AddRange(AccountingSubject);
        context.AddRange(globalWall, shelbyWall, AccountingWall);
        context.AddRange(TomPost, JohnPost);
        context.SaveChanges();
    }
}