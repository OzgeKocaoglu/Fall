﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public class Character: MonoBehaviour
    {
        public bool IsHave;
        public GameObject _ob;
        public string name;

       public Character(bool ıshave, GameObject _object, string _name)
       {
        IsHave = ıshave;
        _ob = _object;
        name = _name;
        
       }


}

