using UnityEngine;
using System.Collections;
namespace MainGameplay
{

    public class Battler
    {
        public string name;
        public int maxHP;
        public int currHP;
        public int atk;
        public int def;
        public int mat;
        public int mdf;
        public int spd;
        public int luk;
        public bool isMagic;
        public bool isEnemy;
        public int type;

        public Battler(string n, int mHP, int cHP, int at, int df, int ma, int md, int sp, int lk, bool isM, bool isE, int tp)
        {
            this.name = n;
            this.maxHP = mHP;
            this.currHP = cHP;
            this.atk = at;
            this.def = df;
            this.mat = ma;
            this.mdf = md;
            this.spd = sp;
            this.luk = lk;
            this.isMagic = isM;
            this.isEnemy = isE;
        }
    }

}