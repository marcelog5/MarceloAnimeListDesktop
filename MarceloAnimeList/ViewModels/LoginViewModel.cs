using ReactiveUI;
using System;
using System.Reactive;

namespace MarceloAnimeList.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    private string _password;
    private ReactiveCommand<Unit, Unit> _loginCommand;

    public LoginViewModel()
    {
        _loginCommand = ReactiveCommand.Create(ExecuteLogin);
    }

    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public ReactiveCommand<Unit, Unit> LoginCommand => _loginCommand;

    private void ExecuteLogin()
    {
        // Add your authentication logic here
        if (AuthenticateUser(Username, Password))
        {
            Console.WriteLine("Login successful!");
        }
        else
        {
            Console.WriteLine("Login failed. Please check your credentials.");
        }
    }

    private bool AuthenticateUser(string username, string password)
    {
        // Add your authentication logic here
        // For simplicity, we'll consider any non-empty username/password as a successful login
        return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
    }
}
