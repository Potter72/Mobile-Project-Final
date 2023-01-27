using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private string savedString;
    public GameObject currentCheckpoint;    //reference to the current gameobject
    public int currentCheckpointLevelIndex; //the level index in which the current checkpoint exists
    private int saveDataLenght;     //the amount of variables saved

    private void Awake()
    {
        //sets the instance 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        //subscribes to events
        SceneManager.sceneLoaded += OnSceneLoaded;
        EventManager.PlayerDied += LoadCheckpoint;
    }

    private void OnDisable()
    {
        //unsubscribes to events
        SceneManager.sceneLoaded -= OnSceneLoaded;
        EventManager.PlayerDied -= LoadCheckpoint;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //places the player at the checkpoint position if the checkpoint is in the current scene
        int checkpointLevelIndex = GetSavedCheckpointLevelIndex();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        //resets the timescale
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
            if(player)
            {
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }  
        }
        //when a scene is loaded check if a checkpoint exists and place the player at said checkpoint
        if (SceneManager.GetActiveScene().buildIndex == checkpointLevelIndex)
        {
            if (player != null)
            {
                player.transform.position = GetSavedCheckpoint();
            }
        }
    }

    //can be called by other classes
    public void ReloadActiveScene()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //reloads the active scene
    }

    //loads the last checkpoint
    public void LoadCheckpoint()
    {
        SceneManager.LoadScene(GetSavedCheckpointLevelIndex()); //loads the level with level index of the current saved checkpoint
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //find the player
        if (player != null)
        {
            player.transform.position = GetSavedCheckpoint();   //if the player was found place it at the checkpoint position
        }
    }

    //Save game function creates a string containing all the save data and writes it to a Save.sav file
    public void SaveGame()
    {
        //creates a save directory if none exists
        Debug.Log("Saving Game");
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
            Debug.Log("Creating save path: " + Application.persistentDataPath);
        }
        if (!File.Exists(Application.persistentDataPath + "/Save.sav"))
        {
            using (StreamWriter sw = File.CreateText(Application.persistentDataPath + "/Save.sav")) ;
            Debug.Log("Creating file: " + Application.persistentDataPath + "/Save.sav");
        }


        //
        //  BELOW ARE THE SAVED VARIABLES
        //
        saveDataLenght = 0; //the amount of saved variables
        string saveString = "";

        //saving checkpoint level index at data position 0
        saveString += currentCheckpointLevelIndex.ToString() + ";";
        saveDataLenght++;

        //saving checkpoint position at data position 1
        string checkpointPosString;
        Vector3 checkpointPos = currentCheckpoint.transform.position;
        checkpointPosString = checkpointPos.x.ToString() + "," + checkpointPos.y.ToString() + "," + checkpointPos.z.ToString();
        saveString += checkpointPosString + ";";
        saveDataLenght++;

        //writes the save data to the Save.sav text file
        File.WriteAllText(Application.persistentDataPath + "/Save.sav", saveString);
    }

    //reads the saved checkpoint position
    private Vector3 GetSavedCheckpoint()
    {
        string saveData = File.ReadAllText(Application.persistentDataPath + "/Save.sav");
        string[] saveDataArray = saveData.Split(";");   //the save data variables are split up by ;
        string[] checkpointArray = saveDataArray[1].Split(","); //the vector3 floats are split up by ,
        Vector3 position = new Vector3(
            float.Parse(checkpointArray[0]),
            float.Parse(checkpointArray[1]),
            float.Parse(checkpointArray[2]));
        return position;
    }

    //reads the saved checkpoint level index
    private int GetSavedCheckpointLevelIndex()
    {
        string saveData = File.ReadAllText(Application.persistentDataPath + "/Save.sav");
        string[] saveDataArray = saveData.Split(";");
        return int.Parse(saveDataArray[0]);         //the checkpoint level index is saved on position 0 and is always an integer
    }
}