using GameStore;

using (ApplicationContext db = new ApplicationContext())
{
    User user1 = new User { Username ="Puska1337", Email = "gusinica@gmail.com", UserStatus = "Offline", UserGames = "", Balance = 0 };

    db.Users.Add(user1);
    db.SaveChanges();
    Console.WriteLine("Objects save");

    var users = db.Users.ToList();
    Console.WriteLine("Objects list:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Username} - {u.Email} - {u.UserStatus} - {u.UserGames} - {u.Balance}");
    }
}