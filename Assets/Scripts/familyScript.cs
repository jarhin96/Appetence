using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class familyScript : MonoBehaviour
{

    [SerializeField] public int[] FamilyFoodState;
    [SerializeField] public int[] FamilyHealthState;
    [SerializeField] public int[] FamilyDeathList;
    [SerializeField] public string[] FamilyNames;
    public string[] HealthValues { get; } = { "Healthy", "Sick", "Bedridden", "Dead" };
    public string[] HungerValues { get; } = { "Fine", "Hungry", "Starving", "Dead" };

    public static familyScript Instance { get; private set; }

    public int day = 0;

    void Awake()
    {
        if (Instance != null)
        {
            //Debug.LogError("There is more than one instance!");
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void DayUpdate(bool[] foodList, bool[] medList){
        for(int i = 0; i < foodList.Length; i++){
            if(FamilyDeathList[i] != 1){
                //food logic
                if(foodList[i] == true && FamilyFoodState[i] > 0){
                    FamilyFoodState[i] = FamilyFoodState[i] - 1;
                }
                else if(foodList[i] == false){
                    FamilyFoodState[i] = FamilyFoodState[i] + 1;
                }
                //health logic
                
                if(FamilyFoodState[i] > 0){
                    if((Random.Range(0f, 10.0f)) > 8f && day > 1){
                        FamilyHealthState[i] = FamilyHealthState[i] + 1;
                    }
                }
                if(medList[i]== true && FamilyHealthState[i] > 0){
                    FamilyHealthState[i] = FamilyHealthState[i] - 1;
                }
                
                if(FamilyFoodState[i] == 4 || FamilyHealthState[i] == 4){
                    FamilyDeathList[i] = 1;
                }
            }
        }
        day++;
    }

    int getHealth(int i){
        return FamilyHealthState[i];
    }
}