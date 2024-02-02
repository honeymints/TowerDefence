using UnityEngine;
using UnityEngine.UI;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject[] turretArray = new GameObject[5];
    [SerializeField] private Button _buttonToSpawn;

    private int counter=0;
 
    void Start()
    {
        _buttonToSpawn.onClick.AddListener(SpawnTurrets);
    }

    public void SpawnTurrets()
    {
        turretArray[counter].gameObject.SetActive(true);
        counter++;
    }
}
