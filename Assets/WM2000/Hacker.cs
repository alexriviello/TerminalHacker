using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = ("Type \"menu\" at any time to return to   main menu.");
    string[] level1passwords = { "student", "desk", "test", "pencil", "learn" };
    string[] level2passwords = { "precinct", "arrest", "kneel", "detective", "officer" };
    string[] level3passwords = { "hacking", "freedom", "snowden", "cybersecurity", "communication" };

    // Game State
    int level, randomQuestion;

    string password;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;

    void Awake(){
        randomQuestion = Random.Range(0,5);
    }
      // Start is called before the first frame update
    void Start(){
        
        ShowMainMenu();
    }
    void ShowMainMenu(){
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Script Kiddie Terminal Hacker V2.572\n");
        Terminal.WriteLine("Press 1 to hack local school");
        Terminal.WriteLine("Press 2 to hack a police station");
        Terminal.WriteLine("Press 3 to hack the NSA\n");
    }
    void OnUserInput(string input){

        if(input == "menu"){ // we can always go direct to main menu
            ShowMainMenu();
        } 
        else if(currentScreen == Screen.MainMenu){
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password){
            CheckPassword(input);
        }

        // else if(currentSCreen == Screen.Win){
        // ReplayGame?
        //}
    }

    void RunMainMenu(string input){
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" );
    
        if(isValidLevelNumber){
            level = int.Parse(input);
            AskForPassword();
        }
        else{
            Terminal.WriteLine("Please choose a valid level\n");
            Terminal.WriteLine(menuHint);
        }
        
    }

    void AskForPassword() {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter Password: ");
        Terminal.WriteLine("HINT- " + setRandomPassword());
        
        
    }
string setRandomPassword(){
        switch(level){
            case 1:
                password = level1passwords[randomQuestion];
                break;
            case 2:
                password = level2passwords[randomQuestion];
                break;
            case 3:
                password = level3passwords[randomQuestion];
                break;
        }
    return password.Anagram();
}
    void CheckPassword(string input){
            if(input == password){
                DisplayWinScreen();
            }
            else{
                AskForPassword();
            }
        }   

        void DisplayWinScreen(){
            currentScreen = Screen.Win;
            Terminal.ClearScreen();
            ShowLevelReward();
        }

        void ShowLevelReward(){
            switch(level){
                case 1:
                Terminal.WriteLine("Success! You stole a book from the school!\n");
                break;
            case 2:
                Terminal.WriteLine("Success! You defunded the police!\n");
                break;
            case 3:
                Terminal.WriteLine("Success! You hacked the hackers!\n");
                break;
            default:
                Terminal.WriteLine("Invalid level reached!\n");
                break;
            }
            Terminal.WriteLine(menuHint);
        }

}   
