using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication3
{
    [Serializable]
    public class ArmorType
    {
        public string Type { get; set; }
    }
    
    [Serializable]
    public class WeaponType
    {
        public string Type { get; set; }
    }
    
    [Serializable]
    public class Artifact
    {
        public string Name { get; set; }
    }

    [Serializable]
    public class Equipment
    {
        public ArmorType ArmorType { get; set; }

        public WeaponType WeaponType { get; set; }
        
        public List<Artifact> Artifacts = new List<Artifact>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (ArmorType != null)
                sb.Append(ArmorType.Type + "\n");
            if (WeaponType != null)
                sb.Append(WeaponType.Type + "\n");
            if (Artifacts != null)
            {
                foreach (var i in Artifacts)
                    sb.Append("Артифакт: " + i.Name + " \n");
            }
            sb.Append("\n");
            return sb.ToString();
        }
    }
    [Serializable]
    abstract class EquipmentBuilder
    {
        public Equipment Equipment { get; private set; }
        public void CreateEquipment()
        {
            Equipment = new Equipment();
        }
        public abstract void SetArmor();
        public abstract void SetWeapon();
        public abstract void SetArtifacts();
    }
    class Blacksmith
    {
        public Equipment Assemble(EquipmentBuilder equipmentBuilder)
        {
            equipmentBuilder.CreateEquipment();
            equipmentBuilder.SetArmor();
            equipmentBuilder.SetWeapon();
            equipmentBuilder.SetArtifacts();
            return equipmentBuilder.Equipment;
        }
    }
    class ElfEquipmentBuilder : EquipmentBuilder
    {
        public override void SetArmor()
        {
            this.Equipment.ArmorType = new ArmorType { Type = "Легкая кожаная броня" };
        }
 
        public override void SetWeapon()
        {
            this.Equipment.WeaponType = new WeaponType { Type = "Арбалает из великого дерева" };
        }
 
        public override void SetArtifacts() { }
    }
    class WariorEquipmentBuilder : EquipmentBuilder
    {
        public override void SetArmor()
        {
            this.Equipment.ArmorType = new ArmorType { Type = "Латная броня" };
        }
 
        public override void SetWeapon()
        {
            this.Equipment.WeaponType = new WeaponType { Type = "Длинный меч" };
        }
 
        public override void SetArtifacts()
        {
            this.Equipment.Artifacts.Add(new Artifact { Name = "Амулет защиты" });
            this.Equipment.Artifacts.Add(new Artifact { Name = "Малое зелье исцеления" });
        }
    }
}