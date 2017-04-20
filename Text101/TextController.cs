using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { cell, mirror, cell_mirror, stuff_0, stuff_1, lock_0, lock_1, 
    corridor_0
        };
    private States myState;
    float timeLeft = 60.0f;

    // this for initialization
    void Start() {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update() {
        print(myState);
        if      (myState == States.cell) 		{ cell(); } 
        else if (myState == States.stuff_0) 	{ stuff_0(); } 
        else if (myState == States.stuff_1) 	{ stuff_1(); } 
        else if (myState == States.lock_0) 		{ lock_0(); } 
        else if (myState == States.lock_1) 		{ lock_1(); } 
        else if (myState == States.mirror) 		{ mirror(); } 
        else if (myState == States.cell_mirror) { cell_mirror(); } 
        else if (myState == States.corridor_0) 	{ corridor_0(); }
    }
    void cell() {
        text.text = "Escape the room, time starts now \n\n" +
        "Press the S key to view Stuff \nM to view Mirror \nL to view Lock";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.stuff_0; } 
        else if (Input.GetKeyDown(KeyCode.M)) { myState = States.mirror; } 
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_0; }
    }
    void mirror() {
        text.text = "In the mirrors reflection, you see a bobby pin in your shirt pocket \n\n" +
        "Press T to Take the bobby pin or R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.T)) { myState = States.cell_mirror; } 
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void stuff_0() {
        text.text = "Oh! Whats this? A bag full of tools!?! \n\n" +
        "Press R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void stuff_1() {
        text.text = "You have discovered a hammer and screwdriver in your bag of tools." +
        "\nPress R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
    }
    void lock_0() {
        text.text = "This lock requires some kind of combination, check around for clues \n\n" +
        "Press the R key to your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void lock_1() {
        text.text = "Using the bobby pin and some ingenuity, you are able to pick the lock!" +
        "Press O to Open, or R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.O)) { myState = States.corridor_0; } 
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
    }
    void cell_mirror() {
        text.text = "You are still in your cell, and you STILL want to escape! There is a " +
        "sheet of folded paper on the floor \nPress S to grab the Sheet" +
        "\nL to view Lock";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.stuff_1; } 
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_1; }
    }
    void corridor_0() {
        text.text = "You are now in the corridor, with a door on the right and left and one " +
            "directly ahead. \nHow would you like to proceed \n\n" +
        "Press P to Play again";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }
}