using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hacker : MonoBehaviour {

  // Config Data
  const string menuHint = "Type 'menu' at any time to return to the main menu.";
  string[] level1Passwords = { "books", "aisle", "shelf", "homeless guy watching porn", "font", "borrow" };
  string[] level2Passwords = { "donuts", "handcuffs", "gun", "bacon", "tazer", "uniform" };
  string[] level3Passwords = { "uranus", "space", "nerds", "rockets", "space station" };

  // Game State
  int level;
  enum Screen { MainMenu, Password, Win };
  Screen currentScreen;
  string password;

  // Use this for initialization
  void Start () {
    ShowMainMenu();
  }

  void ShowMainMenu () {
    currentScreen = Screen.MainMenu;
    Terminal.ClearScreen();
    Terminal.WriteLine("What would you like to hack into?");
    Terminal.WriteLine("Press 1 for the local library");
    Terminal.WriteLine("Press 2 for the police station");
    Terminal.WriteLine("Press 3 for NASA");
    Terminal.WriteLine("Enter your selection:");
  }

  void OnUserInput(string input) {
    if (input == "menu") {
        ShowMainMenu();
    }
    else if (currentScreen == Screen.MainMenu) {
      RunMainMenu(input);
    }
    else if (currentScreen == Screen.Password) {
      CheckPassword(input);
    }
    else if (input == "quit" || input == "close" || input == "exit" || input == "stop") {
      Terminal.WriteLine("If on the web, please close the browser tab");
      Application.Quit();
    }
  }

  void RunMainMenu(string input) {
    bool isValidLevel = (input == "1" || input == "2" || input == "3");
    if (isValidLevel) {
      level = int.Parse(input);
      AskForPassword();
    }
    else if (input == "strange") {
      Terminal.WriteLine("Friends don't lie.");
    }
    else {
      Terminal.WriteLine("Not a valid choice, MEATBAG!");
      Terminal.WriteLine(menuHint);
    }
  }

  void AskForPassword() {
    currentScreen = Screen.Password;
    Terminal.ClearScreen();
    SetRandomPassword();
    Terminal.WriteLine("Please enter your password, hint: " + password.Anagram());
    Terminal.WriteLine(menuHint);
  }

  void SetRandomPassword() {
    switch (level) {
      case 1:
        password = level1Passwords[Random.Range(0, level1Passwords.Length)];
        break;
      case 2:
        password = level2Passwords[Random.Range(0, level2Passwords.Length)];
        break;
      case 3:
        password = level3Passwords[Random.Range(0, level3Passwords.Length)];
        break;
      default:
        Debug.LogError("Invalid level number");
        break;
    }
  }

  void CheckPassword(string input) {
    if (input == password) {
      DisplayWinScreen();
    }
    else {
      AskForPassword();
    }
  }

  void DisplayWinScreen() {
    currentScreen = Screen.Win;
    Terminal.ClearScreen();
    ShowLevelReward();
    Terminal.WriteLine(menuHint);
  }

  void ShowLevelReward() {
    switch (level) {
      case 1:
        Terminal.WriteLine("Well Done! You can steal books now.");
        break;
      case 2:
        Terminal.WriteLine("Well Done! You escaped the police station!");
        break;
      case 3:
        Terminal.WriteLine("Well Done! You have pwned NASA!");
        break;
      default:
        Debug.LogError("Invalid level reached");
        break;
    }
  }
}
