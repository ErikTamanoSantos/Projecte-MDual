using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class UtilsServer : MonoBehaviour {
    void Start() {
        StartCoroutine(Upload());
    }
     
    IEnumerator Upload() {
        WWWForm form = new WWWForm();
        form.AddField("type", "login");
        form.AddField("user", "Erik");
     
        UnityWebRequest www = UnityWebRequest.Post("https://neighborly-sand-production.up.railway.app:443/dades", form);
        yield return www.SendWebRequest();
     
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log(www.result);
        }
    }
}