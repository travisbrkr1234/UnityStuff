using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { cell, mirror, cell_mirror, stuff_0, stuff_1, lock_0, lock_1, freedom };
    private States myState;
    float timeLeft = 60.0f;

    // this for initialization
    void Start() {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update() {
        print(myState);
        if (myState == States.cell) { state_cell(); } else if (myState == States.stuff_0) { state_stuff_0(); } else if (myState == States.stuff_1) { state_stuff_1(); } else if (myState == States.lock_0) { state_lock_0(); } else if (myState == States.lock_1) { state_lock_1(); } else if (myState == States.mirror) { state_mirror(); } else if (myState == States.cell_mirror) { state_cell_mirror(); } else if (myState == States.freedom) { state_freedom(); }
    }
    void state_cell() {
        text.text = "Escape the room, time starts now \n\n" +
        "Press the S key to view Stuff \nM to view Mirror \nL to view Lock";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.stuff_0; } 
        else if (Input.GetKeyDown(KeyCode.M)) { myState = States.mirror; } 
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_0; }
    }
    void state_mirror() {
        text.text = "In the mirrors reflection, you see a bobby pin in your shirt pocket \n\n" +
        "Press T to Take the bobby pin or R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.T)) { myState = States.cell_mirror; } 
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void state_stuff_0() {
        text.text = "Oh! Whats this? A bag full of tools!?! \n\n" +
        "Press R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void state_stuff_1() {
        text.text = "You have discovered a hammer and screwdriver in your bag of tools." +
        "Press R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
    }
    void state_lock_0() {
        text.text = "This lock requires some kind of combination, check around for clues \n\n" +
        "Press the R key to your cell";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
    }
    void state_lock_1() {
        text.text = "Using the bobby pin and some ingenuity, you are able to pick the lock!" +
        "Press O to Open, or R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.O)) { myState = States.freedom; } 
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell_mirror; }
    }
    void state_cell_mirror() {
        text.text = "You are still in your cell, and you STILL want to escape! There is a " +
        "sheet of folded paper on the floor, \nPress S to grab the Sheet" +
        "\nPress S to view Sheets, or L to view Lock";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.stuff_1; } 
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_1; }
    }
    void state_freedom() {
        text.text = "You are FREE!\n\n" +
        "Press P to Play again";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }
}