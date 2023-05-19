using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

 
public class UtilsServer : MonoBehaviour {

    static string address = "http://localhost:3000/dades";
    // static string address = "https://neighborly-sand-production.up.railway.app:443/dades";

    static string currentLvlString, currentXPString;
    static int currentLvl, currentXP;
    void Start() {
        
    }

    public static void post() {
        //StartCoroutine(Upload());
    }

    static string getString(string JSON, string key) {
        string trimmedJSON = JSON.Substring(1, JSON.Length-2);
        Debug.Log(trimmedJSON);

        string[] JSONlist = trimmedJSON.Split(","[0]);
        for (int i = 0; i < JSONlist.Length; i++) {
            string[] splitItem = JSONlist[i].Split(":"[0]);
            if (splitItem[0] == key) {
                return splitItem[1];
            }
        }
        return "";
    }

    public static IEnumerator login(string username, string password) {
        LoginController.Instance.errorText.enabled = false;
        WWWForm form = new WWWForm();
        form.AddField("type", "login");
        form.AddField("user", username);
        form.AddField("password", password);
     
        UnityWebRequest www = UnityWebRequest.Post(address, form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            if (www.error == "Cannot connect to destination host") {
                LoginController.Instance.errorText.text = "ERROR: Cannot connect to server";
                LoginController.Instance.errorText.enabled = true;   
            }
        }
        else {
            if (getString(www.downloadHandler.text, "\"status\"") == "\"OK\"") {
                GameData.userId = getString(www.downloadHandler.text, "\"userID\"");
                Debug.Log("userId " + GameData.userId);
                yield return getUnitData("nightborne", GameData.userId);
                yield return getUnitData("necromancer", GameData.userId);
                Debug.Log(GameData.Party_ActiveParty.Count);
                GameObject.FindGameObjectWithTag("MapScreenMusic").GetComponent<MusicPlayer>().playMusic();
                SceneManager.LoadScene("MapScene");
            } else {
                LoginController.Instance.errorText.text = "ERROR: Please check your credentials";
                LoginController.Instance.errorText.enabled = true;
            }
        }
    }
    public static IEnumerator register(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("type", "register");
        form.AddField("user", username);
        form.AddField("password", password);
     
        UnityWebRequest www = UnityWebRequest.Post(address, form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            if (www.error == "Cannot connect to destination host") {
                RegisterController.Instance.errorText.text = "ERROR: Cannot connect to server";
                RegisterController.Instance.errorText.enabled = true;   
            }
        }
        else {
            if (getString(www.downloadHandler.text, "\"status\"") == "\"OK\"") {
                yield return login(username, password);
            } else {
                RegisterController.Instance.errorText.text = "ERROR: User already exists";
                RegisterController.Instance.errorText.enabled = true;
            }
        }
    }

    public static IEnumerator getUnitData(string name, string id) {
        WWWForm form = new WWWForm();
        form.AddField("type", "getUnitData");
        form.AddField("name", name);
        form.AddField("id", id);
     
        UnityWebRequest www = UnityWebRequest.Post(address, form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            currentLvlString = getString(www.downloadHandler.text, "\"currentLVL\"");
            Debug.Log(currentLvlString);
            currentLvl = Int32.Parse(currentLvlString);
            currentXPString = getString(www.downloadHandler.text, "\"currentXP\"");
            currentXP = Int32.Parse(currentXPString);
            GameData.Party_ActiveParty.Add(new CharacterData(name, currentLvl, currentXP));
        }
    }

     public static IEnumerator saveUnitData(string name, string id, int XP, int LVL) {
        WWWForm form = new WWWForm();
        form.AddField("type", "saveUnitData");
        form.AddField("name", name);
        form.AddField("id", id);
        form.AddField("currentLvl", LVL);
        form.AddField("currentXP", XP);
     
        UnityWebRequest www = UnityWebRequest.Post(address, form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            if (getString(www.downloadHandler.text, "\"status\"") == "\"OK\"") {
            }
        }
    }
}