using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    //private int selectedClass;

    public TMP_Text description;
    public TMP_Text statsOverview;
    public TMP_Text pros;
    public TMP_Text cons;

    void Start(){
        SelectTraditional();
    }

    public void StartGame(){
        SceneManager.LoadScene("DesktopTestLevel");
    }
    
    public void SelectTraditional(){
        description.text = "The classic paradigm. A vanilla playthrough.";
        statsOverview.text = "Max HP: 10\nAttack Power: 5\nAttack Speed: 1.0";
        pros.text = "- Simple";
        cons.text = "- Simple";
    }

    public void SelectBrute(){
        description.text = "Just keep throwing things to the wall and see what sticks. This unsophisticated approach lets";
        statsOverview.text = "Max HP: 20\nAttack Power: 10\nAttack Speed: 0.8";
        pros.text = "- Higher base stats\n- Modules have higher values[NOT IMPLEMENTED]";
        cons.text = "- One less component slot\n- One less slot per module";
    }

    public void SelectDivide(){
        description.text = "[NOT IMPLEMENTED]Hitting the problem from multiple sides. You divide yourself up and attack with clones.";
        statsOverview.text = "Max HP: 7\nAttack Power: 3\nAttack Speed: 1.0";
        pros.text = "- Unique module types designed around strengthening or increasing the number of your clones[NOT IMPLEMENTED]\n- Clones are invincible";
        cons.text = "- Much weaker at the start";
    }

    public void SelectDynamic(){
        description.text = "Avoid redundancies by storing past data. This results in a more robust algorithm in the long run. Getting there might be a challenge, however.";
        statsOverview.text = "Max HP: 5\nAttack Power: 2\nAttack Speed: 1.0";
        pros.text = "- Two more component slots\n- Two more slots per module\n- More modules can be salvaged at the end of a level[NOT IMPLEMENTED]";
        cons.text = "- Much weaker at the start";
    }
}
