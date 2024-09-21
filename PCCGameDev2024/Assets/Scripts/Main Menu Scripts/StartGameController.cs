using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    private int classNumber;

    public TMP_Text description;
    public TMP_Text statsOverview;
    public TMP_Text pros;
    public TMP_Text cons;
    public RectTransform moduleDeck;

    [SerializeField]
    private GameObject modulePrefab;
    [SerializeField]
    private GameObject blockPrefab;

    private GameObject[][] moduleList = new GameObject[6][];

    public static Block startingBlock;

    void Start(){
        SelectTraditional();
    }

    public void StartGame(){
        if(classNumber == 0){
            PlayerStats.SetBases(100, 5, 1.0f);
        }
        else if(classNumber == 1){
            PlayerStats.SetBases(200, 10, 0.8f);
        }
        else if(classNumber == 2){
            PlayerStats.SetBases(70, 3, 1.0f);
        }
        else if(classNumber == 3){
            PlayerStats.SetBases(50, 2, 1.0f);
        }
        if(startingBlock != null) Inventory.blockList.Add(startingBlock);
        SceneManager.LoadScene("DesktopTestLevel");
    }
    
    private void ResetDeck(int classNumber, int modulesToGenerate){
        while(moduleDeck.childCount > 0){
            moduleDeck.GetChild(0).gameObject.SetActive(false);
            moduleDeck.GetChild(0).SetParent(null);  
        }

        if(moduleList[classNumber] != null){
            for(int i = 0; i < modulesToGenerate; i++){
                moduleList[classNumber][i].transform.SetParent(moduleDeck);
                moduleList[classNumber][i].SetActive(true);
            }
        }
        else{
            for(int i = 0; i < modulesToGenerate; i++){
                //For the start, we should only generate blocks.
                //We will keep the code here for the generation in levelEnd;
                if(moduleList[classNumber] == null) moduleList[classNumber] = new GameObject[modulesToGenerate];

                int seed = 1;
                GameObject module;

                if(seed == 0){
                    module = Instantiate(modulePrefab);
                    GenerateModule.Generate(module.GetComponent<Module>(), moduleDeck);
                }
                else{
                    module = Instantiate(blockPrefab);   
                    GenerateBlock.Generate(module.GetComponent<Block>(), moduleDeck);
                }  
                moduleList[classNumber][i] = module;
            }
        }
    }

    public void SelectTraditional(){
        classNumber = 0;
        description.text = "The classic paradigm. A vanilla playthrough.";
        statsOverview.text = "Max HP: 100\nAttack Power: 5\nAttack Speed: 1.0";
        pros.text = "- Simple";
        cons.text = "- Simple";
        ResetDeck(classNumber, 3);
    }

    public void SelectBrute(){
        classNumber = 1;
        description.text = "Just keep throwing things to the wall and see what sticks. This unsophisticated approach lets";
        statsOverview.text = "Max HP: 200\nAttack Power: 10\nAttack Speed: 0.8";
        pros.text = "- Higher base stats\n- Modules have higher values[NOT IMPLEMENTED]";
        cons.text = "- One less component slot\n- One less slot per module";
        ResetDeck(classNumber, 2);
    }

    public void SelectDivide(){
        classNumber = 2;
        description.text = "[NOT IMPLEMENTED]Hitting the problem from multiple sides. You divide yourself up and attack with clones.";
        statsOverview.text = "Max HP: 70\nAttack Power: 3\nAttack Speed: 1.0";
        pros.text = "- Unique module types designed around strengthening or increasing the number of your clones[NOT IMPLEMENTED]\n- Clones are invincible";
        cons.text = "- Much weaker at the start";
        ResetDeck(classNumber, 3);
    }

    public void SelectDynamic(){
        classNumber = 3;
        description.text = "Avoid redundancies by storing past data. This results in a more robust algorithm in the long run. Getting there might be a challenge, however.";
        statsOverview.text = "Max HP: 50\nAttack Power: 2\nAttack Speed: 1.0";
        pros.text = "- Two more component slots\n- Two more slots per module\n- More modules can be salvaged at the end of a level[NOT IMPLEMENTED]";
        cons.text = "- Much weaker at the start";
        ResetDeck(classNumber, 3);
    }
}
