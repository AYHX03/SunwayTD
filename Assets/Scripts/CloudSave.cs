using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;

public class CloudSave : MonoBehaviour
{
    public string subject;
    public int value;
    

   
    public async void Start()
    {
        await UnityServices.InitializeAsync();
        Debug.Log("Cloud save script runned!");

    }

    
    public async void SaveData(string subject, int value)
    {
        var client = CloudSaveService.Instance.Data;
        print("client: " + client);
        print("subject: " + subject);
        var data = new Dictionary<string, object> { {subject,value} };
        await client.ForceSaveAsync(data);
        print("Data saved");
    }

}
