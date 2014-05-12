using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace MainGameplay
{

    public class BattleInitializer : MonoBehaviour
    {

        #region Variable Declaration

        Battler p1;
        Battler p2;
        Battler p3;
        Battler e1;
        Battler e2;
        Battler e3;

        List<Battler> order = new List<Battler>();
        List<Battler> listPlayer = new List<Battler>();
        List<Battler> listEnemy = new List<Battler>();
        List<Battler> listTemp = new List<Battler>();

        public int p1CurrHealth = 0;
        public int p2CurrHealth = 0;
        public int p3CurrHealth = 0;
        public int e1CurrHealth = 0;
        public int e2CurrHealth = 0;
        public int e3CurrHealth = 0;
        public int p1MaxHealth = 0;
        public int p2MaxHealth = 0;
        public int p3MaxHealth = 0;
        public int e1MaxHealth = 0;
        public int e2MaxHealth = 0;
        public int e3MaxHealth = 0;

        public string p1name;
        public string p2name;
        public string p3name;
        public string e1name;
        public string e2name;
        public string e3name;

        public int p1atk = 0;
        public int p2atk = 0;
        public int p3atk = 0;
        public int e1atk = 0;
        public int e2atk = 0;
        public int e3atk = 0;
        public int p1def = 0;
        public int p2def = 0;
        public int p3def = 0;
        public int e1def = 0;
        public int e2def = 0;
        public int e3def = 0;
        public int p1mat = 0;
        public int p2mat = 0;
        public int p3mat = 0;
        public int e1mat = 0;
        public int e2mat = 0;
        public int e3mat = 0;
        public int p1mdf = 0;
        public int p2mdf = 0;
        public int p3mdf = 0;
        public int e1mdf = 0;
        public int e2mdf = 0;
        public int e3mdf = 0;
        public int p1spd = 0;
        public int p2spd = 0;
        public int p3spd = 0;
        public int e1spd = 0;
        public int e2spd = 0;
        public int e3spd = 0;
        public int p1luk = 0;
        public int p2luk = 0;
        public int p3luk = 0;
        public int e1luk = 0;
        public int e2luk = 0;
        public int e3luk = 0;
        public bool p1isMagic = false;
        public bool p2isMagic = false;
        public bool p3isMagic = false;
        public bool e1isMagic = false;
        public bool e2isMagic = false;
        public bool e3isMagic = false;
        public bool p1isEnemy = false;
        public bool p2isEnemy = false;
        public bool p3isEnemy = false;
        public bool e1isEnemy = false;
        public bool e2isEnemy = false;
        public bool e3isEnemy = false;
        public int p1Type = 0;
        public int p2Type = 0;
        public int p3Type = 0;
        public int e1Type = 0;
        public int e2Type = 0;
        public int e3Type = 0;
        //type: 0 = humanoid, 1 = cool, 2 = cute

        //tempelan Unity; m = maxHealth, c = currHealth, announce = system message dibawah
        public GUIText p1m;
        public GUIText p2m;
        public GUIText p3m;
        public GUIText p1c;
        public GUIText p2c;
        public GUIText p3c;
        public GUIText e1m;
        public GUIText e2m;
        public GUIText e3m;
        public GUIText e1c;
        public GUIText e2c;
        public GUIText e3c;

        public GUIText announce;
        public GUIText announceSpc;

        //Counter untuk timer penunggu update
        private float counterUpdate = 0;
        //penentu giliran siapa
        private int turn = 0;
        //damage
        private int damage = 0;

        #endregion

        // Use this for initialization
        void Start()
        {
            FetchFromDB();
            AssignStatus();
            BattleOrderInitialization();
            InitialGUI();
            //pengumuman bahwa battle siap dimulai
            announce.text = "Battle Start!";
            announceSpc.text = "IT'S TIME TO DUEL!!";
        }

        // Update is called once per frame
        void Update()
        {
            counterUpdate += Time.deltaTime;
            if (counterUpdate >= 3)
            {
                HealthGUIUpdater();
                counterUpdate = 0;
                EndChecker();
                //StartCoroutine("Battle");
                Battle();
                turn++;
                if (turn > 5)
                {
                    turn = 0;
                }
            }
        }

        void FetchFromDB()
        {
            //Gets Status from Database
            p1MaxHealth = 73;
            p1CurrHealth = p1MaxHealth;
            p2MaxHealth = 99;
            p2CurrHealth = p2MaxHealth;
            p3MaxHealth = 23;
            p3CurrHealth = p3MaxHealth;
            e1MaxHealth = 20;
            e1CurrHealth = e1MaxHealth;
            e2MaxHealth = 44;
            e2CurrHealth = e2MaxHealth;
            e3MaxHealth = 84;
            e3CurrHealth = e3MaxHealth;

            p1name = "Lily Rain EVE";
            p2name = "Rance";
            p3name = "Hello Kyubey";
            e1name = "Zero Saber";
            e2name = "Grapig";
            e3name = "Taihou KAI";

            p1isMagic = true;
            p2isMagic = false;
            p3isMagic = true;
            e1isMagic = false;
            e2isMagic = false;
            e3isMagic = false;

            p1isEnemy = false;
            p2isEnemy = false;
            p3isEnemy = false;
            e1isEnemy = true;
            e2isEnemy = true;
            e3isEnemy = true;

            p1Type = 0;
            p2Type = 0;
            p3Type = 2;
            e1Type = 1;
            e2Type = 2;
            e3Type = 0;

            p1atk = 30;
            p1def = 37;
            p1mat = 50;
            p1mdf = 48;
            p1spd = 40;
            p1luk = 25;

            p2atk = 70;
            p2def = 47;
            p2mat = 10;
            p2mdf = 28;
            p2spd = 30;
            p2luk = 45;

            p3atk = 10;
            p3def = 77;
            p3mat = 10;
            p3mdf = 74;
            p3spd = 100;
            p3luk = 95;

            e1atk = 27;
            e1def = 34;
            e1mat = 5;
            e1mdf = 4;
            e1spd = 37;
            e1luk = 15;

            e2atk = 10;
            e2def = 7;
            e2mat = 3;
            e2mdf = 3;
            e2spd = 7;
            e2luk = 10;

            e3atk = 70;
            e3def = 97;
            e3mat = 22;
            e3mdf = 31;
            e3spd = 27;
            e3luk = 40;
        }

        void AssignStatus()
        {
            p1 = new Battler(p1name, p1MaxHealth, p1CurrHealth, p1atk, p1def, p1mat, p1mdf, p1spd, p1luk, p1isMagic, p1isEnemy, p1Type);
            p2 = new Battler(p2name, p2MaxHealth, p2CurrHealth, p2atk, p2def, p2mat, p2mdf, p2spd, p2luk, p2isMagic, p2isEnemy, p2Type);
            p3 = new Battler(p3name, p3MaxHealth, p3CurrHealth, p3atk, p3def, p3mat, p3mdf, p3spd, p3luk, p3isMagic, p3isEnemy, p3Type);
            e1 = new Battler(e1name, e1MaxHealth, e1CurrHealth, e1atk, e1def, e1mat, e1mdf, e1spd, e1luk, e1isMagic, e1isEnemy, e1Type);
            e2 = new Battler(e2name, e2MaxHealth, e2CurrHealth, e2atk, e2def, e2mat, e2mdf, e2spd, e2luk, e2isMagic, e2isEnemy, e2Type);
            e3 = new Battler(e3name, e3MaxHealth, e3CurrHealth, e3atk, e3def, e3mat, e3mdf, e3spd, e3luk, e3isMagic, e3isEnemy, e3Type);
        }

        void BattleOrderInitialization()
        {
            //Memasukan para battler kedalam list urutan battle
            order = new List<Battler>();
            order.Add(p1);
            order.Add(p2);
            order.Add(p3);
            order.Add(e1);
            order.Add(e2);
            order.Add(e3);

            listPlayer.Add(p1);
            listPlayer.Add(p2);
            listPlayer.Add(p3);

            listEnemy.Add(e1);
            listEnemy.Add(e2);
            listEnemy.Add(e3);
            //Sort order berdasarkan speed
            order = order.OrderByDescending(o => o.spd).ToList();
        }

        void InitialGUI()
        {
            p1m.text = p1.maxHP.ToString();
            p2m.text = p2.maxHP.ToString();
            p3m.text = p3.maxHP.ToString();
            p1c.text = p1.currHP.ToString();
            p2c.text = p2.currHP.ToString();
            p3c.text = p3.currHP.ToString();
            e1m.text = e1.maxHP.ToString();
            e2m.text = e2.maxHP.ToString();
            e3m.text = e3.maxHP.ToString();
            e1c.text = e1.currHP.ToString();
            e2c.text = e2.currHP.ToString();
            e3c.text = e3.currHP.ToString();
        }

        void HealthGUIUpdater()
        {
            p1c.text = listPlayer[0].currHP.ToString();
            p2c.text = listPlayer[1].currHP.ToString();
            p3c.text = listPlayer[2].currHP.ToString();
            e1c.text = listEnemy[0].currHP.ToString();
            e2c.text = listEnemy[1].currHP.ToString();
            e3c.text = listEnemy[2].currHP.ToString();
        }

        void Battle()
        {
            //Implementasi Random Battle sementara
            Battler attacker = order[turn];
            //Pengecekan apakah turn battler masih hidup atau tidak
            if (attacker.currHP == 0)
            {
                return;
            }
            Debug.Log("attacker = " + attacker.name);
            Battler target = null;
            int randomTarget = 0;
            listTemp = new List<Battler>();
            //menentukan target serangnnya musuh atau player
            if (!attacker.isEnemy)
            {
                //Meng add isi listEnemy ke listTemporary
                foreach (var obj in listEnemy)
                {
                    if (obj.currHP != 0)
                    {
                        listTemp.Add(obj);
                    }
                }
                randomTarget = Random.Range(0, listTemp.Count);
                target = listTemp[randomTarget];
            }
            else
            {
                //Meng add isi listPlayer ke listTemporary
                foreach (var obj in listPlayer)
                {
                    if (obj.currHP != 0)
                    {
                        listTemp.Add(obj);
                    }
                }
                randomTarget = Random.Range(0, listTemp.Count);
                target = listTemp[randomTarget];
            }
            Debug.Log("randomTarget = " + randomTarget);
            Debug.Log("Target = " + target.name);
            damage = damageCalculator(attacker, target);
            target.currHP = target.currHP - damage;
            if (target.currHP < 0)
            {
                target.currHP = 0;
            }
            announce.text = attacker.name + " attacks " + target.name + " for " + damage + " damage!!";
            announceSpc.text = "Cortical Hit is not yet implemented ;p";
            //memasukan musuh kembali ke habitatnya
            int returnTarget = 0;
            if (!attacker.isEnemy)
            {
                returnTarget = listEnemy.FindIndex(item => item.name.Equals(target.name));
                listEnemy[returnTarget] = target;
            }
            else
            {
                returnTarget = listPlayer.FindIndex(item => item.name.Equals(target.name));
                listPlayer[randomTarget] = target;
            }
        }

        int damageCalculator(Battler attacker, Battler target)
        {
            float damage = 0;
            int result = 0;
            float atk = 0;
            float def = 0;
            //Magic Attack or not
            if (!attacker.isMagic)
            {
                atk = attacker.atk;
                def = target.def;
            }
            else
            {
                atk = attacker.mat;
                def = target.mdf;
            }
            //Base damage calculation
            damage = atk * (100 / (100 + def));
            //Type advantage
            if ((target.type - attacker.type) == 1 || (target.type - attacker.type) == -2)
            {
                damage = damage * 150 / 100;
            }
            else if ((target.type - attacker.type) == 2 || (target.type - attacker.type) == -1)
            {
                damage = damage * 75 / 100;
            }
            result = (int)damage;
            return result;
        }

        void EndChecker()
        {
            int winCheck = 0;
            int totalHealth = 0;
            totalHealth = p1.currHP + p2.currHP + p3.currHP;
            if (totalHealth == 0)
            {
                announce.text = "YOU LOSE!!";
                winCheck = 1;
            }
            if (winCheck == 1)
            {
                Application.LoadLevel("Home");
            }
            totalHealth = e1.currHP + e2.currHP + e3.currHP;
            if (totalHealth == 0)
            {
                announce.text = "YOU WIN!!";
                winCheck = 2;
            }
            if (winCheck == 2)
            {
                Application.LoadLevel("Dungeon-HootunForest");
            }
        }
    }
}