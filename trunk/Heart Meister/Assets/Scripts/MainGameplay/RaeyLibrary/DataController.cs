using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace MainGameplay
{
    public class DataController : MonoBehaviour
    {
        public string username;

        #region SavedThings
        List<Battler> PartyList;
        List<Battler> EnemyList;
        List<Item> InventoryList;
        #endregion

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // Use this for initialization
        void Start()
        {
            List<Battler> PartyList = new List<Battler>();
            List<Battler> EnemyList = new List<Battler>();
            List<Item> InventoryList = new List<Item>();
            PlayerDataRequest();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void DataWrite()
        {

        }

        void DataRead()
        {

        }

        void PartyRefresh()
        {

        }

        void PlayerDataRequest()
        {

        }
    }
}