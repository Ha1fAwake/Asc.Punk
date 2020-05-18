using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using UnityEngine;
using GameSystem.FightSystem.Skill;

namespace GameSystem.FightSystem.CommonInterface
{
    public abstract class  OperationModule
    {
        protected int maxCharacterCount;
        protected int curCharacterCount;
        protected int MaxCharacterCount { get => maxCharacterCount;}
        protected int CurCharacterCount { get => curCharacterCount;}
        private static string configurePath = "XML\\FightXML";
        public OperationModule()
        {
            LoadConfigureXML();
        }

        public abstract void ExecuteRound();

        private void LoadConfigureXML()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Application.streamingAssetsPath + configurePath);
            var root = xml.FirstChild;
            maxCharacterCount = int.Parse(root.SelectSingleNode("MaxCharacterCount").InnerText);
            curCharacterCount = 0;
        }        

    }
}
