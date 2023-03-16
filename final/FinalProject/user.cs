public class User
{
    private string _name;
    private string _email;
    private string _password;

    public User(string name, string email, string password)
    {
        setName(name);
        setEmail(email);
        setPassword(password);
    }

    public string getName(){
        return _name;
    }
    public string getEmail(){
        return _email;
    }
    public string getPassword(){
        return _password;
    }
    public void setName(string name){
        _name = name;
    }
    public void setEmail(string email){
        _email = email;
    }
    public void setPassword(string password){
        _password = password;
    }

    public bool Authenticate(string email, string password)
    {
        if (getEmail() == email && getPassword() == password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}