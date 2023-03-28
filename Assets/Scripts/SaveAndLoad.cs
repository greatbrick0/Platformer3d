using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField]
    List<GameObject> collectables = new List<GameObject>();
    [SerializeField]
    List<GameObject> collectableRefs = new List<GameObject>();
    [SerializeField]
    PlayerMovement playerMovementRef;

    public SaveData workingSaveData;
    private string secretKey = "strongPassWord123+secrets??";

    [System.Serializable]
    public class SaveData
    {
        public Vector3 playerPosition;
        public float playerMoveSpeed;
        public int collectedCoins;
        public List<bool> remainingCollectables;
    }

    public void Save()
    {
        workingSaveData.playerPosition = playerMovementRef.transform.position;
        workingSaveData.playerMoveSpeed = playerMovementRef.GetMoveSpeed();
        workingSaveData.collectedCoins = FindObjectOfType<CoinTracker>().coinCount;
        workingSaveData.remainingCollectables = new List<bool>();
        for(int ii = 0; ii < collectables.Count; ii++)
        {
            workingSaveData.remainingCollectables.Add(collectables[ii] != null);
        }

        string json = JsonUtility.ToJson(workingSaveData);
        string path = Application.persistentDataPath + "/data.json";
        File.WriteAllText(path, XOREncrypt(json, secretKey));
        print(path + " " + File.ReadAllText(path));
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/data.json";
        string json = XORDecrypt(File.ReadAllText(path), secretKey);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        workingSaveData = data;
        playerMovementRef.transform.position = data.playerPosition;
        playerMovementRef.SetMoveSpeed(data.playerMoveSpeed);
        FindObjectOfType<CoinTracker>().coinCount = data.collectedCoins;
        for(int ii = 0; ii < data.remainingCollectables.Count; ii++)
        {
            if(collectables[ii] != null && !data.remainingCollectables[ii])
            {
                Destroy(collectables[ii]);
            }
            else if(collectables[ii] == null && data.remainingCollectables[ii])
            {
                collectables[ii] = Instantiate(collectableRefs[ii]);
                collectables[ii].SetActive(true);
            }
        }

    }

    private string XOREncrypt(string data, string key)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(data);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        int keyLength = keyBytes.Length;
        for (int ii = 0; ii < bytes.Length; ii++)
        {
            bytes[ii] = (byte)(bytes[ii] ^ keyBytes[ii % keyLength]);
        }
        return Convert.ToBase64String(bytes);
    }

    private string XORDecrypt(string encryptedData, string key)
    {
        byte[] bytes = Convert.FromBase64String(encryptedData);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        int keyLength = keyBytes.Length;
        for (int ii = 0; ii < bytes.Length; ii++)
        {
            bytes[ii] = (byte)(bytes[ii] ^ keyBytes[ii % keyLength]);
        }
        return Encoding.UTF8.GetString(bytes);
    }

    private void Start()
    {
        workingSaveData = new SaveData();
        for(int ii = 0; ii < collectables.Count; ii++)
        {
            collectableRefs.Add(Instantiate(collectables[ii]));
            collectableRefs[ii].SetActive(false);
        }
    }
}
