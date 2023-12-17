using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.CloudSave;
using Unity.Services.Authentication;
using TMPro;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

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
        var data = new Dictionary<string, object> { { subject, value } };
        await client.ForceSaveAsync(data);
        print("Data saved");
    }

    public async void RetrieveAllKeys()
    {
        List<string> allKeys = await CloudSaveService.Instance.Data.RetrieveAllKeysAsync();

        for (int i = 0; i < allKeys.Count; i++)
        {
            print("key " + i + ":" + allKeys[i]);
        }
    }

    public async Task<int> LoadData(string subject)
    {
        Dictionary<string, string> serverData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { subject });

        if (serverData.ContainsKey(subject))
        {
            print(subject + " values: " + serverData[subject]);
            int.TryParse(serverData[subject], out int result);
            return result;
        }
        else
        {
            print("Key is not found, initialising new key");
            SaveData(subject, 1);
            return 1;
        }

    }

}

