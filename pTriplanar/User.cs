using System;

public class User
{
    public int id { get; set; }
    public string nickname { get; set; }
    public string savestring { get; set; }
    public string email { get; set; }

    public User(int id, string nickname, string savestring, string email) {
        this.id = id;
        this.nickname = nickname;
        this.savestring = savestring;
        this.email = email;
    }



}