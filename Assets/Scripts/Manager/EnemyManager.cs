using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemys = new List<Enemy>();
    private static EnemyManager instance = null;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public EnemyManager asdf()
    {
        if (instance == null)
        {
            return null;
        }
        return instance;
    }
    public static EnemyManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
