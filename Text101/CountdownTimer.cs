using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {
    public Text timerText;
    float timeLeft = 60;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
    }

    private void OnGUI() {
        if (timeLeft > 0) {
            timerText.text = "Time Remaining: " + string.Format("{0:0}", timeLeft);
        } else {
            timerText.text = "Time's up!";
        }
    }
}