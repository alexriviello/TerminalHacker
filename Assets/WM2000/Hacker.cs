using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;

    void OnUserInput(string input){

        if(input == "menu"){ // we can always go direct to main menu
            ShowMainMenu();
        } 
        else if(currentScreen==Screen.MainMenu){
            RunMainMenu(input);
        }
    }

    void RunMainMenu(string input){
        level = int.Parse(input);
        if(input =="1"){
            StartGame();
        }
        else if(input =="2"){
            StartGame();
        }
        else if(input =="3"){
            StartGame();
        }

        else {
            Terminal.WriteLine("Please choose a valid level"); 
        }
    }

    void StartGame() {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
    }

    void ShowMainMenu(){

        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Script Kiddie Terminal Hacker V2.572\n");
        Terminal.WriteLine("Press 1 to hack local school");
        Terminal.WriteLine("Press 2 to hack local police station");
        Terminal.WriteLine("Press 3 to hack the NSA\n");

    }

    // Start is called before the first frame update
    void Start(){
        ShowMainMenu();
    }

}
