 //using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour{

    // Array/Game configuration data. Use when creating multiple strings
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow"}; // 0, 1, 2, 3, 4, 5
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    //game state
    int level; //member variable, which is available everywhere

    enum Screen { MainMenu, Password, Win };//create a new type called "Screen". This is an enumerator (enum). Defines a list of possible states

    Screen currentScreen; //declare a variable of this new type called currentScreen

    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu(); //we are calling this method otherwise the function below will not work     
    }

    void Update()
    {
        //int index = Random.Range(0, level1Passwords.Length);
        //print(index);
    }

    void ShowMainMenu()//this is a formal parameter 
    {
        currentScreen = Screen.MainMenu; //assigning the value of currentScreen to MainMenu
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input) //this decides how to handle the input, not actually do it. 
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }

        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input); //extracted new function/method by highlight RunMainMenu(input), right click, quick fix, and selecting Extract Method
        }

        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2"); // "||" stands for "or". So in this case, if the input is equal to 1 OR 2.

        if (isValidLevelNumber)
        {
            level = int.Parse(input); //This simplifies having to write each out each level individually. Converts string to integer
            StartGame();
        }
           
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr. Bond.");
        }

        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();

        switch (level) //this is basically the same as an if statement
        {
            case 1:
                //int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords [Random.Range(0, level1Passwords.Length)];
                break;

            case 2:
                //int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords [Random.Range(0, level2Passwords.Length)];
                break;             

            default:
                Debug.LogError("Invalid level number");
                break;
        }

        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }

        else
        {
            Terminal.WriteLine("You suck!");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Fuckin nerd!");
                Terminal.WriteLine(@"
     _________
    /        //
   / Book of//
  / NERDS  //
 /________//
(________(/
"
                );
                break;
            case 2:
                Terminal.WriteLine("Fuckin bird!");
                break;
        }
        
    }
}
