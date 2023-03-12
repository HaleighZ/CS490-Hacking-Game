using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gadget_Holder : MonoBehaviour
{
    private List<Terminal_Key.KeyType> keyList;
    public TextMeshProUGUI pressesF, continues;    //The text box used to access key.
    private void Awake() {
        keyList = new List<Terminal_Key.KeyType>();
        pressesF = GetComponentInChildren<objectiveScreen>().pressF;  //Grabs component that has the objectiveScreen script with the variable pressF
        continues = GetComponentInChildren<objectiveScreen>().continuing;
    }
    public void addKey(Terminal_Key.KeyType keyType){
        Debug.Log("Added key!");
        pressesF.enabled = false; //When the gadget console is accessed, turns off the text box. Then enables the continues textbox
        continues.enabled = true; 
        keyList.Add(keyType);
    }
    public bool ContainsKey(Terminal_Key.KeyType keyType){
        return keyList.Contains(keyType);
    }
    private void OnTriggerStay2D(Collider2D collider){
        Terminal_Key term_key = collider.GetComponent<Terminal_Key>();
        if(term_key != null){
            if (Input.GetKeyDown("f")){
                addKey(term_key.GetKeyType());
            }
        }

        Key_Door key_door = collider.GetComponent<Key_Door>();
        if (key_door != null){
            if(ContainsKey(key_door.GetKeyType())){
                key_door.OpenDoor();
            }
        }

        Level_Transition level_trans = collider.GetComponent<Level_Transition>();
        if (level_trans != null){
            
            SaveManager saveMan = collider.GetComponent<SaveManager>();
            if (saveMan != null){
            if(level_trans.GetLevelType() == Level_Type.LevelType.Level_1){
                level_trans.ChangeScene("Level_1");
                saveMan.updateLevel("Level_1");
                saveMan.SaveData();
                Debug.Log(saveMan.data.levelName);
                }
            if(level_trans.GetLevelType() == Level_Type.LevelType.Level_2){
                level_trans.ChangeScene("Level_2");
                saveMan.updateLevel("Level_2");
                saveMan.SaveData();
                Debug.Log(saveMan.data.levelName);
                }
            if(level_trans.GetLevelType() == Level_Type.LevelType.Level_3){
                level_trans.ChangeScene("Level_3");
                saveMan.updateLevel("Level_3");
                saveMan.SaveData();
                Debug.Log(saveMan.data.levelName);
                }
            }
        }
        
    }

}