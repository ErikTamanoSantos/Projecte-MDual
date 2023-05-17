using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class UtilsServer : MonoBehaviour {
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
     
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/dades", form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            string[] textSplit = www.downloadHandler.text.Split(","[0]);
            getString(www.downloadHandler.text, "\"result\"");
        }
    }

    static void getString(string JSON, string key) {
        string trimmedJSON = JSON.Substring(1, JSON.Length-2);
        Debug.Log(trimmedJSON);

        string[] JSONlist = JSON.Split(","[0]);
        for (int i = 0; i < JSONlist.Length; i++) {
            string[] splitItem = JSONlist[i].Split(":"[0]);
            if (splitItem[0] == key) {
                Debug.Log(splitItem[1]);
            }
        }
    }
}