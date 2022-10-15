using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
using UnityEngine.UI;

namespace SO.UI
{
    public class HandTextUpdate : UIPropertyUpdater
    {
        public StringVariable targetString;
        public Text targetText;
        public CardCalculator calc;

        /// <summary>
        /// Use this to update a text UI element based on the target string variable
        /// </summary>
        public void HandUpdate()
        {
            Debug.Log(calc.playercardtext);
            targetText.text = calc.playerhandtype + "\n" + calc.playercardtext;
        }

        public void Raise(string target)
        {
            targetText.text = target;
        }

        private void Update()
        {
            HandUpdate();
        }
    }
}
