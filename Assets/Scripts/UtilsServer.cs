using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

 
public class UtilsServer : MonoBehaviour {

    static string address = "http://localhost:3000/dades";

    static string currentLvlString, currentXPString;
    static int currentLvl, currentXP;
    void Start() {
        
    }

    public static void post() {
        //StartCoroutine(Upload());
    }
     
    public static IEnumerator Upload() {
        WWWForm form = new WWWForm();
        form.AddField("type", "login");
        form.AddField("user", "Erik");
        form.AddField("password", "test");
     
        UnityWebRequest www = UnityWebRequest.Post(address, form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            string[] textSplit = www.downloadHandler.text.Split(","[0]);
            getString(www.downloadHandler.text, "\"result\"");
        }
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
        WWWForm form = new WWWForm();
        form.AddField("type", "login");
        form.AddField("user", username);
        form.AddField("password", password);
     
        UnityWebRequest www = UnityWebRequest.Post(address, form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            GameData.userId = getString(www.downloadHandler.text, "\"userID\"");
            Debug.Log("userId " + GameData.userId);
            yield return getUnitData("nightborne", GameData.userId);
            yield return getUnitData("necromancer", GameData.userId);
            Debug.Log(GameData.Party_ActiveParty.Count);
            SceneManager.LoadScene("MapScene");
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
        form.AddField("type", "getUnitData");
        form.AddField("name", name);
        form.AddField("id", id);
        form.AddField("currentLvl", LVL);
        form.AddField
     
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
}